using System;
using System.Data;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Préstamos internos a empleados: sus cuotas se descuentan automáticamente en la planilla mensual.</summary>
    public partial class frmPrestamos : frmMantenimiento
    {
        public frmPrestamos()
        {
            InitializeComponent();
        }

        protected override string Titulo { get { return "Préstamos"; } }
        protected override string PermisoGestionar { get { return Permisos.PlanillaGestionar; } }
        protected override string ColumnaId { get { return "idPrestamo"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("idEmpleado", "Empleado", TipoCampo.Combo) { Origen = EmpleadoDatos.ListarActivos });
            Campos.Add(new Campo("monto", "Monto del préstamo ($)", TipoCampo.Decimal, 9) { Minimo = 1, Maximo = 50000 });
            Campos.Add(new Campo("cuotaMensual", "Cuota mensual ($)", TipoCampo.Decimal, 9) { Minimo = 1, Maximo = 50000, Ayuda = "No puede exceder el 20% del salario base del empleado ni el monto del préstamo." });
            Campos.Add(new Campo("fechaOtorgado", "Fecha en que se otorga", TipoCampo.Fecha) { FechaMin = DateTime.Today.AddYears(-3), FechaMax = DateTime.Today, Ayuda = "El descuento inicia en la planilla del mes siguiente." });
            Campos.Add(new Campo("descripcion", "Descripción", TipoCampo.Multilinea, 200, false));
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 10) { Opciones = new[] { "Activo", "Pagado", "Cancelado" }, Predeterminado = "Activo", Ayuda = "Pagado se asigna automáticamente al llegar el saldo a cero." });
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return PrestamoDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override void ConfigurarColumnas(DataGridView g)
        {
            GridUtil.Configurar(g);
            GridUtil.Ocultar(g, "salarioBase");
        }

        protected override bool PuedeModificar(DataRow fila) { return fila == null || (string)fila["estado"] == "Activo"; }

        protected override string ValidarNegocio()
        {
            decimal monto = Decimal("monto"), cuota = Decimal("cuotaMensual");
            if (cuota > monto) { MarcarError("cuotaMensual", "No puede superar el monto."); return "La cuota mensual no puede ser mayor al monto del préstamo."; }
            DataRow emp = FilaCombo("idEmpleado");
            if (emp != null && cuota > (decimal)emp["salarioBase"] * 0.20m)
            {
                MarcarError("cuotaMensual", "Excede el 20% del salario.");
                return "La cuota no puede exceder el 20% del salario base del empleado (máximo $" + ((decimal)emp["salarioBase"] * 0.20m).ToString("N2") + ").";
            }
            if (Opcion("estado") == "Pagado" && FilaActual != null && (decimal)FilaActual["saldo"] > 0)
            {
                MarcarError("estado", "El saldo aún no es cero.");
                return "Un préstamo solo pasa a Pagado cuando su saldo llega a cero.";
            }
            return null;
        }

        private Prestamo Leer(int id)
        {
            return new Prestamo
            {
                IdPrestamo = id, IdEmpleado = Seleccion("idEmpleado").Value, Monto = Decimal("monto"), CuotaMensual = Decimal("cuotaMensual"),
                FechaOtorgado = Fecha("fechaOtorgado"), Descripcion = Texto("descripcion"), Estado = Opcion("estado")
            };
        }

        protected override void Insertar() { PrestamoDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { PrestamoDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { PrestamoDatos.Eliminar(id); }
    }
}
