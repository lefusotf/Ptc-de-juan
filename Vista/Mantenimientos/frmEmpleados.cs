using System;
using System.Data;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>
    /// Mantenimiento de empleados (base maestra de datos y perfil salarial). Es coherente por diseño: al elegir el departamento
    /// solo se pueden elegir cargos de ese departamento y el salario debe estar dentro del rango del cargo.
    /// </summary>
    public partial class frmEmpleados : frmMantenimiento
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        protected override string Titulo { get { return "Empleados"; } }
        protected override string PermisoGestionar { get { return Permisos.EmpleadosGestionar; } }
        protected override string ColumnaId { get { return "idEmpleado"; } }
        protected override int Columnas { get { return 2; } }
        protected override int AnchoFormulario { get { return 680; } }

        private static DataTable Sexos()
        {
            DataTable t = new DataTable();
            t.Columns.Add("sexo", typeof(string));
            t.Columns.Add("nombre", typeof(string));
            t.Rows.Add("M", "Masculino");
            t.Rows.Add("F", "Femenino");
            return t;
        }

        protected override void DefinirCampos()
        {
            DateTime hoy = DateTime.Today;
            Campos.Add(new Campo("nombres", "Nombres", TipoCampo.Letras, 80) { Ayuda = "Solo letras y espacios; no admite números ni símbolos." });
            Campos.Add(new Campo("apellidos", "Apellidos", TipoCampo.Letras, 80) { Ayuda = "Solo letras y espacios; no admite números ni símbolos." });
            Campos.Add(new Campo("dui", "DUI", TipoCampo.Dui, 10));
            Campos.Add(new Campo("nit", "NIT", TipoCampo.Nit, 17));
            Campos.Add(new Campo("numeroIsss", "N.º de ISSS", TipoCampo.Digitos, 9));
            Campos.Add(new Campo("numeroNup", "NUP (AFP)", TipoCampo.Digitos, 12));
            Campos.Add(new Campo("sexo", "Sexo", TipoCampo.Combo, 1) { Origen = Sexos, ValorMiembro = "sexo", TextoMiembro = "nombre" });
            Campos.Add(new Campo("fechaNacimiento", "Fecha de nacimiento", TipoCampo.Fecha) { FechaMin = hoy.AddYears(-75), FechaMax = hoy.AddYears(-18), Predeterminado = hoy.AddYears(-25), Ayuda = "El empleado debe ser mayor de edad (18 años cumplidos)." });
            Campos.Add(new Campo("telefono", "Teléfono", TipoCampo.Telefono, 9));
            Campos.Add(new Campo("correo", "Correo electrónico", TipoCampo.Correo, 100, false));
            Campos.Add(new Campo("direccion", "Dirección", TipoCampo.Texto, 250, false) { Ancho = true });

            // Cadena departamento -> cargo: el cargo solo muestra los cargos del departamento elegido
            Campos.Add(new Campo("idDepartamento", "Departamento", TipoCampo.Combo) { Origen = DepartamentoDatos.ListarActivos });
            Campos.Add(new Campo("idCargo", "Cargo", TipoCampo.Combo, 100) { Padre = "idDepartamento", OrigenDependiente = v => CargoDatos.ListarPorDepartamento(Convert.ToInt32(v)), Ayuda = "Solo se muestran los cargos del departamento seleccionado." });
            Campos.Add(new Campo("idHorario", "Horario", TipoCampo.Combo) { Origen = HorarioDatos.ListarActivos });
            Campos.Add(new Campo("idPlanilla", "Planilla", TipoCampo.Combo) { Origen = PlanillaDatos.ListarActivas });
            Campos.Add(new Campo("fechaIngreso", "Fecha de ingreso", TipoCampo.Fecha) { FechaMin = new DateTime(1990, 1, 1), FechaMax = hoy, Ayuda = "No puede ser una fecha futura." });
            Campos.Add(new Campo("fechaRetiro", "Fecha de retiro", TipoCampo.FechaOpcional, 10, false) { FechaMin = new DateTime(1990, 1, 1), FechaMax = hoy.AddMonths(1), Ayuda = "Marque la casilla solo si el empleado se retiró de la empresa." });
            Campos.Add(new Campo("salarioBase", "Salario base mensual ($)", TipoCampo.Decimal, 10) { Minimo = 0.01m, Maximo = 99999 });
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 12) { Opciones = new[] { "Activo", "Inactivo", "Suspendido" }, Predeterminado = "Activo" });
        }

        protected override void ConfigurarColumnas(DataGridView g)
        {
            GridUtil.Configurar(g);
            GridUtil.Ocultar(g, "nombres", "apellidos", "nit", "numeroIsss", "numeroNup", "sexo", "fechaNacimiento", "correo", "direccion", "fechaRetiro", "horario");
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return EmpleadoDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override void AlCambiarSeleccion(DataRow fila)
        {
            ActualizarRangoSalarial();
            ((ComboBox)ControlDe("idCargo")).SelectedIndexChanged -= CargoCambio;
            ((ComboBox)ControlDe("idCargo")).SelectedIndexChanged += CargoCambio;
        }

        private void CargoCambio(object sender, EventArgs e) { ActualizarRangoSalarial(); }

        /// <summary>Muestra en la etiqueta del salario el rango permitido por el cargo elegido.</summary>
        private void ActualizarRangoSalarial()
        {
            DataRow cargo = FilaCombo("idCargo");
            PonerEtiqueta("salarioBase", cargo == null ? "Salario base mensual ($)"
                : "Salario base ($) - rango del cargo: " + ((decimal)cargo["salarioMinimo"]).ToString("N2") + " a " + ((decimal)cargo["salarioMaximo"]).ToString("N2"));
        }

        protected override string ValidarNegocio()
        {
            string e = Validaciones.FechaNacimiento(Fecha("fechaNacimiento"));
            if (e != null) { MarcarError("fechaNacimiento", e); return e; }

            if (Fecha("fechaIngreso") < Fecha("fechaNacimiento").AddYears(18))
            {
                MarcarError("fechaIngreso", "El empleado debía tener al menos 18 años al ingresar.");
                return "La fecha de ingreso no es coherente con la fecha de nacimiento (el empleado debía tener al menos 18 años al ingresar).";
            }

            DateTime? retiro = FechaOpcional("fechaRetiro");
            string estado = Opcion("estado");
            if (retiro.HasValue && retiro.Value < Fecha("fechaIngreso")) { MarcarError("fechaRetiro", "No puede ser anterior al ingreso."); return "La fecha de retiro no puede ser anterior a la fecha de ingreso."; }
            if (retiro.HasValue && estado != "Inactivo") { MarcarError("estado", "Un empleado con fecha de retiro debe estar Inactivo."); return "Si el empleado tiene fecha de retiro, su estado debe ser Inactivo."; }
            if (!retiro.HasValue && estado == "Inactivo") { MarcarError("fechaRetiro", "Indique la fecha de retiro."); return "Un empleado Inactivo debe tener fecha de retiro."; }

            decimal salario = Decimal("salarioBase");
            decimal minimoLey = ParametrosLeyDatos.Valor("SALARIO_MINIMO", 0m);
            if (salario < minimoLey) { MarcarError("salarioBase", "Menor al salario mínimo vigente."); return "El salario no puede ser menor al salario mínimo vigente ($" + minimoLey.ToString("N2") + ")."; }
            DataRow cargo = FilaCombo("idCargo");
            if (cargo != null && (salario < (decimal)cargo["salarioMinimo"] || salario > (decimal)cargo["salarioMaximo"]))
            {
                MarcarError("salarioBase", "Fuera del rango del cargo.");
                return "El salario debe estar dentro del rango del cargo seleccionado ($" + ((decimal)cargo["salarioMinimo"]).ToString("N2") + " a $" + ((decimal)cargo["salarioMaximo"]).ToString("N2") + ").";
            }
            return null;
        }

        private Empleado Leer(int id)
        {
            return new Empleado
            {
                IdEmpleado = id, Nombres = Texto("nombres"), Apellidos = Texto("apellidos"), Dui = Texto("dui"), Nit = Texto("nit"),
                NumeroIsss = Texto("numeroIsss"), NumeroNup = Texto("numeroNup"), Sexo = ValorTexto("sexo"),
                FechaNacimiento = Fecha("fechaNacimiento"), Telefono = Texto("telefono"), Correo = Texto("correo"), Direccion = Texto("direccion"),
                IdDepartamento = Seleccion("idDepartamento").Value, IdCargo = Seleccion("idCargo").Value,
                IdHorario = Seleccion("idHorario").Value, IdPlanilla = Seleccion("idPlanilla").Value,
                FechaIngreso = Fecha("fechaIngreso"), FechaRetiro = FechaOpcional("fechaRetiro"),
                SalarioBase = Decimal("salarioBase"), Estado = Opcion("estado")
            };
        }

        protected override void Insertar() { EmpleadoDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { EmpleadoDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { EmpleadoDatos.Eliminar(id); }
    }
}
