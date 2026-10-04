using System;
using System.Data;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Planilla Movimiento: bonos, comisiones, viáticos y descuentos internos de un empleado en un mes.</summary>
    public class frmMovimientos : frmMantenimiento
    {
        protected override string Titulo { get { return "Planilla movimiento"; } }
        protected override string PermisoGestionar { get { return Permisos.PlanillaGestionar; } }
        protected override string ColumnaId { get { return "idPlanillaMovimiento"; } }

        private static DataTable Meses()
        {
            string[] nombres = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            DataTable t = new DataTable();
            t.Columns.Add("mes", typeof(int));
            t.Columns.Add("nombre", typeof(string));
            for (int i = 0; i < 12; i++) t.Rows.Add(i + 1, nombres[i]);
            return t;
        }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("idEmpleado", "Empleado", TipoCampo.Combo) { Origen = EmpleadoDatos.ListarActivos });
            Campos.Add(new Campo("idTipoMovimiento", "Tipo de movimiento", TipoCampo.Combo) { Origen = TipoMovimientoDatos.ListarActivos, Ayuda = "Ingreso suma al salario; Deducción lo reduce en la planilla del mes." });
            Campos.Add(new Campo("anio", "Año", TipoCampo.Entero, 4) { Minimo = 2000, Maximo = 2100, Predeterminado = DateTime.Today.Year });
            Campos.Add(new Campo("mes", "Mes", TipoCampo.Combo) { Origen = Meses, ValorMiembro = "mes", Predeterminado = DateTime.Today.Month });
            Campos.Add(new Campo("monto", "Monto ($)", TipoCampo.Decimal, 9) { Minimo = 0.01m, Maximo = 99999 });
            Campos.Add(new Campo("descripcion", "Descripción", TipoCampo.Multilinea, 200, false));
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return MovimientoDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override void ConfigurarColumnas(DataGridView g)
        {
            GridUtil.Configurar(g);
            GridUtil.Ocultar(g, "gravable", "fechaRegistro");
        }

        protected override bool PuedeModificar(DataRow fila) { return fila == null || !(bool)fila["aplicado"]; }

        protected override string ValidarNegocio()
        {
            DateTime periodo = new DateTime(Entero("anio"), Seleccion("mes").Value, 1);
            if (periodo > new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1))
            {
                MarcarError("mes", "Período demasiado adelantado.");
                return "No se pueden registrar movimientos para un período posterior al próximo mes.";
            }
            DataRow emp = FilaCombo("idEmpleado");
            if (emp != null && periodo.AddMonths(1).AddDays(-1) < (DateTime)emp["fechaIngreso"])
            {
                MarcarError("anio", "Anterior al ingreso del empleado.");
                return "El período es anterior al ingreso del empleado.";
            }
            return null;
        }

        private PlanillaMovimiento Leer(int id)
        {
            return new PlanillaMovimiento
            {
                IdPlanillaMovimiento = id, IdEmpleado = Seleccion("idEmpleado").Value, IdTipoMovimiento = Seleccion("idTipoMovimiento").Value,
                Anio = Entero("anio"), Mes = Seleccion("mes").Value, Monto = Decimal("monto"), Descripcion = Texto("descripcion"),
                IdUsuario = Sesion.UsuarioActual.IdUsuario
            };
        }

        protected override void Insertar() { MovimientoDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { MovimientoDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { MovimientoDatos.Eliminar(id); }
    }
}
