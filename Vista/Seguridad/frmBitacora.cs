using System.Data;
using Modelos.Datos;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Seguridad
{
    /// <summary>Consulta de la bitácora del sistema (actividades, advertencias y errores) con búsqueda y paginación.</summary>
    public class frmBitacora : frmMantenimiento
    {
        protected override string Titulo { get { return "Bitácora del sistema"; } }
        protected override string PermisoGestionar { get { return Permisos.BitacoraVer; } }
        protected override string ColumnaId { get { return "idBitacora"; } }
        protected override bool MostrarFormulario { get { return false; } }
        protected override string AyudaBusqueda { get { return "Busque por nivel (INFO, ERROR), usuario, módulo o parte del mensaje."; } }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return BitacoraDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override void ConfigurarColumnas(System.Windows.Forms.DataGridView g)
        {
            GridUtil.Configurar(g);
            GridUtil.Ocultar(g, "detalle");
            if (g.Columns.Contains("fecha")) g.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            if (g.Columns.Contains("mensaje")) g.Columns["mensaje"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
