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
    public class frmRoles : FormBase
    {
        private ListBox lstRoles;
        private CheckedListBox clbPermisos;
        private CajaTexto txtNombre, txtDescripcion;
        private BotonModerno btnNuevo, btnGuardarRol, btnEliminarRol, btnGuardarPermisos, btnMarcarTodos;
        private Label lblDescripcionRol, lblPermisosTitulo;
        private ToolTip tip;
        private ErrorProvider errores;
        private DataTable _roles, _permisos;
        private bool _cargando;

        public frmRoles()
        {
            InicializarControles();
            Load += (s, e) => Cargar();
        }

        private void InicializarControles()
        {
            tip = new ToolTip();
            errores = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            Text = "Roles y permisos";
            BackColor = Tema.Fondo;
            ClientSize = new Size(1000, 640);

            Label titulo = new Label { Text = "Roles y permisos", Dock = DockStyle.Top, Height = 56, Padding = new Padding(20, 12, 0, 0), Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro };

            TableLayoutPanel raiz = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(14, 4, 14, 14) };
            raiz.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380));
            raiz.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // ----- Roles -----
            PanelTarjeta pnlRoles = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 8, 0), Name = "pnlRoles" };
            Label t1 = new Label { Text = "Roles", Dock = DockStyle.Top, Height = 30, Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold) };
            lstRoles = new ListBox { Name = "lstRoles", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F), BorderStyle = BorderStyle.None, ItemHeight = 24, IntegralHeight = false };
            Panel pie = new Panel { Dock = DockStyle.Bottom, Height = 214 };
            txtNombre = Ui.Caja("txtNombre", 0, 22, 330, 50, ModoEntrada.Letras);
            txtDescripcion = Ui.Caja("txtDescripcion", 0, 80, 330, 200, ModoEntrada.Libre);
            btnNuevo = Ui.Boton("btnNuevoRol", "Nuevo", Tema.PrimarioOscuro, 0, 134, 96, 36);
            btnGuardarRol = Ui.Boton("btnGuardarRol", "Guardar rol", Tema.Primario, 102, 134, 124, 36);
            btnEliminarRol = Ui.Boton("btnEliminarRol", "Eliminar", Tema.Peligro, 232, 134, 98, 36);
            pie.Controls.AddRange(new Control[] { Ui.Etiqueta("Nombre del rol *", 0, 0), txtNombre, Ui.Etiqueta("Descripción", 0, 58), txtDescripcion, btnNuevo, btnGuardarRol, btnEliminarRol });
            pnlRoles.Controls.Add(lstRoles);
            pnlRoles.Controls.Add(pie);
            pnlRoles.Controls.Add(t1);

            // ----- Permisos -----
            PanelTarjeta pnlPermisos = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(8, 0, 0, 0), Name = "pnlPermisos" };
            lblPermisosTitulo = new Label { Text = "Permisos del rol seleccionado", Dock = DockStyle.Top, Height = 30, Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold) };
            lblDescripcionRol = new Label { Dock = DockStyle.Top, Height = 26, ForeColor = Tema.TextoSuave };
            clbPermisos = new CheckedListBox { Name = "clbPermisos", Dock = DockStyle.Fill, CheckOnClick = true, BorderStyle = BorderStyle.None, Font = new Font("Segoe UI", 10F), IntegralHeight = false, ItemHeight = 26 };
            Panel pie2 = new Panel { Dock = DockStyle.Bottom, Height = 54, Padding = new Padding(0, 10, 0, 0) };
            btnGuardarPermisos = new BotonModerno { Name = "btnGuardarPermisos", Text = "Guardar permisos", BackColor = Tema.Primario, Dock = DockStyle.Fill };
            btnMarcarTodos = new BotonModerno { Name = "btnMarcarTodos", Text = "Marcar / desmarcar todos", BackColor = Tema.Neutro, Dock = DockStyle.Left, Width = 210 };
            pie2.Controls.Add(btnGuardarPermisos);
            pie2.Controls.Add(new Panel { Dock = DockStyle.Left, Width = 8 });
            pie2.Controls.Add(btnMarcarTodos);
            pnlPermisos.Controls.Add(clbPermisos);
            pnlPermisos.Controls.Add(pie2);
            pnlPermisos.Controls.Add(lblDescripcionRol);
            pnlPermisos.Controls.Add(lblPermisosTitulo);

            raiz.Controls.Add(pnlRoles, 0, 0);
            raiz.Controls.Add(pnlPermisos, 1, 0);
            Controls.Add(raiz);
            Controls.Add(titulo);

            txtNombre.TabIndex = 0; txtDescripcion.TabIndex = 1; btnNuevo.TabIndex = 2; btnGuardarRol.TabIndex = 3; btnEliminarRol.TabIndex = 4;
            lstRoles.TabIndex = 5; clbPermisos.TabIndex = 6; btnMarcarTodos.TabIndex = 7; btnGuardarPermisos.TabIndex = 8;

            tip.SetToolTip(lstRoles, "Seleccione un rol para ver y modificar sus permisos.");
            tip.SetToolTip(txtNombre, "Nombre del rol (solo letras y espacios).");
            tip.SetToolTip(txtDescripcion, "Descripción breve de lo que hace el rol.");
            tip.SetToolTip(btnNuevo, "Prepara el formulario para crear un rol nuevo.");
            tip.SetToolTip(btnGuardarRol, "Guarda el rol nuevo o los cambios del rol seleccionado.");
            tip.SetToolTip(btnEliminarRol, "Elimina el rol seleccionado (no puede tener usuarios asignados).");
            tip.SetToolTip(clbPermisos, "Marque las acciones que podrá realizar el rol seleccionado.");
            tip.SetToolTip(btnMarcarTodos, "Marca todos los permisos o los desmarca si ya estaban todos marcados.");
            tip.SetToolTip(btnGuardarPermisos, "Guarda los permisos marcados para el rol seleccionado.");

            lstRoles.SelectedIndexChanged += lstRoles_SelectedIndexChanged;
            btnNuevo.Click += (s, e) => NuevoRol();
            btnGuardarRol.Click += btnGuardarRol_Click;
            btnEliminarRol.Click += btnEliminarRol_Click;
            btnMarcarTodos.Click += (s, e) =>
            {
                bool marcar = clbPermisos.CheckedItems.Count < clbPermisos.Items.Count;
                for (int i = 0; i < clbPermisos.Items.Count; i++) clbPermisos.SetItemChecked(i, marcar);
            };
            btnGuardarPermisos.Click += btnGuardarPermisos_Click;
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
