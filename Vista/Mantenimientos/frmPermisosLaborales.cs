using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Permisos laborales (permisos con/sin goce, incapacidades y vacaciones) con aprobación y reflejo en la asistencia.</summary>
    public partial class frmPermisosLaborales : frmMantenimiento
    {
        public frmPermisosLaborales()
        {
            InitializeComponent();
        }

        private Button _btnAprobar, _btnRechazar;

        protected override string Titulo { get { return "Permisos"; } }
        protected override string PermisoGestionar { get { return Permisos.PermisosGestionar; } }
        protected override string ColumnaId { get { return "idPermisoLaboral"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("idEmpleado", "Empleado", TipoCampo.Combo) { Origen = EmpleadoDatos.ListarActivos });
            Campos.Add(new Campo("tipo", "Tipo de permiso", TipoCampo.Combo, 15) { Opciones = new[] { "Con goce", "Sin goce", "Incapacidad", "Vacaciones" }, Ayuda = "Con goce y Vacaciones no descuentan sueldo; Sin goce descuenta los días hábiles." });
            Campos.Add(new Campo("fechaInicio", "Fecha de inicio", TipoCampo.Fecha) { FechaMin = DateTime.Today.AddDays(-120), FechaMax = DateTime.Today.AddYears(1) });
            Campos.Add(new Campo("fechaFin", "Fecha de fin", TipoCampo.Fecha) { FechaMin = DateTime.Today.AddDays(-120), FechaMax = DateTime.Today.AddYears(1) });
            Campos.Add(new Campo("motivo", "Motivo", TipoCampo.Multilinea, 250));

            _btnAprobar = AgregarAccion("Aprobar", "Aprueba el permiso seleccionado y lo refleja en la asistencia del empleado.", Tema.Primario, Aprobar, Permisos.PermisosGestionar);
            _btnRechazar = AgregarAccion("Rechazar", "Rechaza el permiso seleccionado.", Tema.Peligro, Rechazar, Permisos.PermisosGestionar);
            HabilitarAccion(_btnAprobar, false);
            HabilitarAccion(_btnRechazar, false);
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return PermisoLaboralDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override void ConfigurarColumnas(DataGridView g)
        {
            GridUtil.Configurar(g);
            GridUtil.Ocultar(g, "motivo", "resueltoPor", "fechaSolicitud", "fechaResolucion");
        }

        protected override bool PuedeModificar(DataRow fila) { return fila == null || (string)fila["estado"] == "Pendiente"; }

        protected override void AlCambiarSeleccion(DataRow fila)
        {
            bool pendiente = fila != null && (string)fila["estado"] == "Pendiente";
            if (_btnAprobar != null) { HabilitarAccion(_btnAprobar, pendiente); HabilitarAccion(_btnRechazar, pendiente); }
        }

        protected override string ValidarNegocio()
        {
            DateTime ini = Fecha("fechaInicio"), fin = Fecha("fechaFin");
            if (fin < ini) { MarcarError("fechaFin", "No puede ser anterior al inicio."); return "La fecha de fin no puede ser anterior a la fecha de inicio."; }
            int dias = (int)(fin - ini).TotalDays + 1;
            string tipo = Opcion("tipo");
            if (tipo == "Vacaciones" && dias > 15) { MarcarError("fechaFin", "Máximo 15 días."); return "Las vacaciones no pueden exceder 15 días por solicitud."; }
            if (tipo != "Incapacidad" && dias > 30) { MarcarError("fechaFin", "Máximo 30 días."); return "Un permiso no puede exceder 30 días. Para períodos mayores use una incapacidad."; }
            DataRow emp = FilaCombo("idEmpleado");
            if (emp != null && ini < (DateTime)emp["fechaIngreso"]) { MarcarError("fechaInicio", "Anterior al ingreso del empleado."); return "El permiso no puede iniciar antes de la fecha de ingreso del empleado."; }
            return null;
        }

        private PermisoLaboral Leer(int id)
        {
            return new PermisoLaboral
            {
                IdPermisoLaboral = id, IdEmpleado = Seleccion("idEmpleado").Value, Tipo = Opcion("tipo"),
                FechaInicio = Fecha("fechaInicio"), FechaFin = Fecha("fechaFin"), Motivo = Texto("motivo")
            };
        }

        protected override void Insertar() { PermisoLaboralDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { PermisoLaboralDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { PermisoLaboralDatos.Eliminar(id); }

        private void Aprobar(object sender, EventArgs e)
        {
            if (!IdActual.HasValue) return;
            if (!Mensajes.Confirmar("¿Aprobar el permiso seleccionado?\nSe registrarán los días hábiles en la asistencia del empleado.")) return;
            try
            {
                PermisoLaboralDatos.Aprobar(IdActual.Value, Sesion.UsuarioActual.IdUsuario);
                Modelos.Utilidades.Logger.Info(Titulo, "Permiso aprobado (id " + IdActual + ")");
                Mensajes.Exito("El permiso fue aprobado y reflejado en la asistencia.");
                Limpiar();
                Refrescar();
            }
            catch (Exception ex) { Mensajes.Error(Titulo, ex, "aprobar el permiso"); }
        }

        private void Rechazar(object sender, EventArgs e)
        {
            if (!IdActual.HasValue) return;
            if (!Mensajes.Confirmar("¿Rechazar el permiso seleccionado?")) return;
            try
            {
                PermisoLaboralDatos.Rechazar(IdActual.Value, Sesion.UsuarioActual.IdUsuario);
                Modelos.Utilidades.Logger.Info(Titulo, "Permiso rechazado (id " + IdActual + ")");
                Mensajes.Exito("El permiso fue rechazado.");
                Limpiar();
                Refrescar();
            }
            catch (Exception ex) { Mensajes.Error(Titulo, ex, "rechazar el permiso"); }
        }
    }
}
