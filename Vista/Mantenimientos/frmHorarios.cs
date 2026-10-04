using System.Data;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Mantenimiento de horarios de trabajo (hora de entrada, salida y tolerancia).</summary>
    public partial class frmHorarios : frmMantenimiento
    {
        public frmHorarios()
        {
            InitializeComponent();
        }

        protected override string Titulo { get { return "Horarios"; } }
        protected override string PermisoGestionar { get { return Permisos.HorariosGestionar; } }
        protected override string ColumnaId { get { return "idHorario"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("nombre", "Nombre del horario", TipoCampo.Alfanumerico, 60));
            Campos.Add(new Campo("horaEntrada", "Hora de entrada", TipoCampo.Hora) { Predeterminado = new System.TimeSpan(8, 0, 0) });
            Campos.Add(new Campo("horaSalida", "Hora de salida", TipoCampo.Hora) { Predeterminado = new System.TimeSpan(17, 0, 0) });
            Campos.Add(new Campo("minutosTolerancia", "Tolerancia de entrada (minutos)", TipoCampo.Entero, 2) { Minimo = 0, Maximo = 60, Predeterminado = 10, Ayuda = "Minutos de gracia después de la hora de entrada antes de contar la llegada como tardanza (0 a 60)." });
            Campos.Add(new Campo("horasAlmuerzo", "Horas de almuerzo", TipoCampo.Decimal, 4) { Minimo = 0, Maximo = 3, Predeterminado = 1m, Ayuda = "Horas de almuerzo que no se cuentan como trabajadas (0 a 3)." });
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 10) { Opciones = new[] { "Activo", "Inactivo" }, Predeterminado = "Activo" });
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return HorarioDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override string ValidarNegocio()
        {
            if (Hora("horaSalida") <= Hora("horaEntrada")) { MarcarError("horaSalida", "Debe ser posterior a la hora de entrada."); return "La hora de salida debe ser posterior a la hora de entrada."; }
            double horas = (Hora("horaSalida") - Hora("horaEntrada")).TotalHours - (double)Decimal("horasAlmuerzo");
            if (horas <= 0) { MarcarError("horasAlmuerzo", "Las horas de almuerzo superan la jornada."); return "La jornada no puede quedar sin horas trabajadas después del almuerzo."; }
            return null;
        }

        private Horario Leer(int id)
        {
            return new Horario
            {
                IdHorario = id, Nombre = Texto("nombre"), HoraEntrada = Hora("horaEntrada"), HoraSalida = Hora("horaSalida"),
                MinutosTolerancia = Entero("minutosTolerancia"), HorasAlmuerzo = Decimal("horasAlmuerzo"), Estado = Opcion("estado")
            };
        }

        protected override void Insertar() { HorarioDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { HorarioDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { HorarioDatos.Eliminar(id); }
    }
}
