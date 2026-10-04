using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.Seguridad
{
    /// <summary>Roles y permisos: el administrador crea roles y marca qué permisos tiene cada uno; el menú y las acciones del sistema se adaptan al rol.</summary>
    public partial class frmRoles : FormBase
    {
        private DataTable _roles, _permisos;
        private bool _cargando;

        public frmRoles()
        {
            InitializeComponent();
            Load += (s, e) => Cargar();
        }

        

        private void Cargar()
        {
            try
            {
                _cargando = true;
                _permisos = RolDatos.ListarPermisos();
                clbPermisos.Items.Clear();
                foreach (DataRow p in _permisos.Rows) clbPermisos.Items.Add(p["descripcion"] + "  [" + p["codigo"] + "]");
                CargarRoles(null);
            }
            catch (Exception ex) { Mensajes.Error("Roles", ex, "cargar los roles"); }
            finally { _cargando = false; }
            if (lstRoles.Items.Count > 0) lstRoles.SelectedIndex = 0;
        }

        private void CargarRoles(int? seleccionar)
        {
            bool previo = _cargando;
            _cargando = true;
            _roles = RolDatos.Listar();
            lstRoles.DataSource = null;
            lstRoles.DisplayMember = "nombre";
            lstRoles.ValueMember = "idRol";
            lstRoles.DataSource = _roles;
            if (seleccionar.HasValue) lstRoles.SelectedValue = seleccionar.Value;
            _cargando = previo;
        }

        private int? RolSeleccionado()
        {
            DataRowView v = lstRoles.SelectedItem as DataRowView;
            return v == null ? (int?)null : (int)v["idRol"];
        }

        private void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            DataRowView v = lstRoles.SelectedItem as DataRowView;
            if (v == null) return;
            try
            {
                int id = (int)v["idRol"];
                errores.Clear();
                txtNombre.Text = v["nombre"].ToString();
                txtDescripcion.Text = v["descripcion"] == DBNull.Value ? "" : v["descripcion"].ToString();
                txtNombre.Enabled = id != 1;                 // el nombre del rol Administrador no se cambia
                btnEliminarRol.Enabled = id != 1;
                lblDescripcionRol.Text = txtDescripcion.Text;
                lblPermisosTitulo.Text = "Permisos del rol: " + v["nombre"];

                HashSet<int> asignados = RolDatos.PermisosDelRol(id);
                for (int i = 0; i < _permisos.Rows.Count; i++)
                    clbPermisos.SetItemChecked(i, asignados.Contains((int)_permisos.Rows[i]["idPermisoSistema"]));
            }
            catch (Exception ex) { Mensajes.Error("Roles", ex, "cargar los permisos"); }
        }

        private void NuevoRol()
        {
            errores.Clear();
            _cargando = true;
            lstRoles.ClearSelected();
            _cargando = false;
            txtNombre.Enabled = true;
            txtNombre.Clear();
            txtDescripcion.Clear();
            btnEliminarRol.Enabled = false;
            lblPermisosTitulo.Text = "Permisos del rol seleccionado";
            lblDescripcionRol.Text = "Guarde el rol y luego asigne sus permisos.";
            for (int i = 0; i < clbPermisos.Items.Count; i++) clbPermisos.SetItemChecked(i, false);
            txtNombre.Focus();
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            errores.Clear();
            string error = Validaciones.Requerido(txtNombre.Text, "Nombre del rol") ?? Validaciones.Letras(txtNombre.Text, "Nombre del rol");
            if (error != null) { errores.SetError(txtNombre, error); Mensajes.Invalido(error, txtNombre); return; }
            error = Validaciones.LongitudMaxima(txtDescripcion.Text, 200, "Descripción");
            if (error != null) { errores.SetError(txtDescripcion, error); Mensajes.Invalido(error, txtDescripcion); return; }

            try
            {
                int? id = RolSeleccionado();
                Rol rol = new Rol { Nombre = txtNombre.Text.Trim(), Descripcion = txtDescripcion.Text.Trim() };
                if (id.HasValue) { rol.IdRol = id.Value; RolDatos.Actualizar(rol); }
                else RolDatos.Insertar(rol);
                Logger.Info("Roles", "Rol '" + rol.Nombre + "' " + (id.HasValue ? "actualizado" : "creado"));
                Mensajes.Exito("El rol se guardó correctamente.");
                _cargando = true;
                CargarRoles(id);
                _cargando = false;
                if (!id.HasValue) lstRoles.SelectedIndex = lstRoles.Items.Count - 1;
                else lstRoles_SelectedIndexChanged(this, EventArgs.Empty);
            }
            catch (Exception ex) { Mensajes.Error("Roles", ex, "guardar el rol"); }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            int? id = RolSeleccionado();
            if (!id.HasValue) { Mensajes.Advertencia("Seleccione primero el rol que desea eliminar."); return; }
            if (!Mensajes.Confirmar("¿Eliminar el rol seleccionado? Se eliminarán también sus permisos asignados.")) return;
            try
            {
                RolDatos.Eliminar(id.Value);
                Logger.Info("Roles", "Rol eliminado (id " + id + ")");
                Mensajes.Exito("El rol se eliminó correctamente.");
                Cargar();
            }
            catch (Exception ex) { Mensajes.Error("Roles", ex, "eliminar el rol"); }
        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            int? id = RolSeleccionado();
            if (!id.HasValue) { Mensajes.Advertencia("Seleccione primero un rol."); return; }
            try
            {
                List<int> ids = new List<int>();
                foreach (int indice in clbPermisos.CheckedIndices) ids.Add((int)_permisos.Rows[indice]["idPermisoSistema"]);
                RolDatos.GuardarPermisos(id.Value, ids);
                Logger.Info("Roles", "Permisos actualizados para el rol id " + id + " (" + ids.Count + " permisos)");
                Mensajes.Exito("Los permisos del rol se guardaron correctamente.\nLos usuarios con este rol verán los cambios la próxima vez que inicien sesión.");
            }
            catch (Exception ex) { Mensajes.Error("Roles", ex, "guardar los permisos"); }
        }
    }
}
