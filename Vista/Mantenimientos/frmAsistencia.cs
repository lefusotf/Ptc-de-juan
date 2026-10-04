using System;
using System.Data;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Negocio;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>
    /// Registro de asistencia diaria. Calcula automáticamente horas trabajadas, minutos de tardanza y horas extra con el horario
    /// del empleado y sugiere el tipo (Presente / Tardanza); los tipos sin marcación (ausencia, permisos) no piden horas.
    /// </summary>
    public class frmAsistencia : frmMantenimiento
    {
        private bool _enlazado;

        protected override string Titulo { get { return "Asistencia"; } }
        protected override string PermisoGestionar { get { return Permisos.AsistenciaGestionar; } }
        protected override string ColumnaId { get { return "idAsistencia"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("idEmpleado", "Empleado", TipoCampo.Combo) { Origen = EmpleadoDatos.ListarActivos, Ayuda = "Empleado al que corresponde la marcación." });
            Campos.Add(new Campo("fecha", "Fecha", TipoCampo.Fecha) { FechaMin = DateTime.Today.AddYears(-1), FechaMax = DateTime.Today, Ayuda = "Fecha de la marcación (no puede ser futura)." });
            Campos.Add(new Campo("idTipoAsistencia", "Tipo de asistencia", TipoCampo.Combo) { Origen = TipoAsistenciaDatos.ListarActivos });
            Campos.Add(new Campo("horaEntrada", "Hora de entrada", TipoCampo.Hora) { Predeterminado = new TimeSpan(8, 0, 0) });
            Campos.Add(new Campo("horaSalida", "Hora de salida", TipoCampo.Hora) { Predeterminado = new TimeSpan(17, 0, 0) });
            Campos.Add(new Campo("calculo", "", TipoCampo.Nota) { Predeterminado = "Seleccione el empleado y las horas para ver el cálculo." });
            Campos.Add(new Campo("observacion", "Observación", TipoCampo.Multilinea, 250, false));
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return AsistenciaDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override void ConfigurarColumnas(DataGridView g)
        {
            GridUtil.Configurar(g);
            GridUtil.Ocultar(g, "codigoTipo", "observacion");
        }

        protected override void AlCambiarSeleccion(DataRow fila)
        {
            if (!_enlazado)
            {
                _enlazado = true;
                ((ComboBox)ControlDe("idEmpleado")).SelectedIndexChanged += (s, e) => Recalcular(false);
                ((ComboBox)ControlDe("idTipoAsistencia")).SelectedIndexChanged += (s, e) => Recalcular(true);
                ((DateTimePicker)ControlDe("horaEntrada")).ValueChanged += (s, e) => Recalcular(false);
                ((DateTimePicker)ControlDe("horaSalida")).ValueChanged += (s, e) => Recalcular(false);
            }
            Recalcular(true);
        }

        private bool RequiereHoras()
        {
            DataRow tipo = FilaCombo("idTipoAsistencia");
            return tipo == null || (bool)tipo["requiereHoras"];
        }

        /// <summary>Habilita las horas según el tipo y muestra el cálculo de horas, tardanza y extras.</summary>
        private void Recalcular(bool cambioTipo)
        {
            bool requiere = RequiereHoras();
            Habilitar("horaEntrada", requiere);
            Habilitar("horaSalida", requiere);

            DataRow emp = FilaCombo("idEmpleado");
            Control nota = ControlDe("calculo");
            if (emp == null) { nota.Text = "Seleccione el empleado para calcular la jornada."; return; }
            if (!requiere) { nota.Text = "Este tipo de asistencia no requiere hora de entrada ni de salida."; return; }

            try
            {
                Horario h = HorarioDatos.Obtener((int)emp["idHorario"]);
                ResultadoAsistencia r = CalculoAsistencia.Calcular(h, Hora("horaEntrada"), Hora("horaSalida"));
                nota.Text = "Horario: " + h.HoraEntrada.ToString(@"hh\:mm") + " a " + h.HoraSalida.ToString(@"hh\:mm") + " (tolerancia " + h.MinutosTolerancia + " min)\n" +
                            "Trabajadas: " + r.HorasTrabajadas.ToString("0.00") + " h | Tardanza: " + r.MinutosTarde + " min | Extra: " + r.HorasExtra.ToString("0.0") + " h";
                SugerirTipo(r.TipoSugerido);
            }
            catch (Exception) { nota.Text = ""; }
        }

        /// <summary>Si el tipo elegido es Presente o Tardanza, lo ajusta al resultado del cálculo.</summary>
        private void SugerirTipo(string codigo)
        {
            DataRow actual = FilaCombo("idTipoAsistencia");
            if (actual == null) return;
            string c = actual["codigo"].ToString();
            if ((c != "PRE" && c != "TAR") || c == codigo) return;
            ComboBox cmb = (ComboBox)ControlDe("idTipoAsistencia");
            foreach (DataRowView v in (DataView)((DataTable)cmb.DataSource).DefaultView)
                if (v["codigo"].ToString() == codigo) { cmb.SelectedValue = v["idTipoAsistencia"]; break; }
        }

        protected override string ValidarNegocio()
        {
            DataRow emp = FilaCombo("idEmpleado");
            if (emp != null && Fecha("fecha") < (DateTime)emp["fechaIngreso"])
            {
                MarcarError("fecha", "Anterior al ingreso del empleado.");
                return "La fecha no puede ser anterior a la fecha de ingreso del empleado (" + ((DateTime)emp["fechaIngreso"]).ToString("dd/MM/yyyy") + ").";
            }
            if (RequiereHoras() && Hora("horaSalida") <= Hora("horaEntrada"))
            {
                MarcarError("horaSalida", "Debe ser posterior a la entrada.");
                return "La hora de salida debe ser posterior a la hora de entrada.";
            }
            return null;
        }

        private Asistencia Leer(int id)
        {
            bool horas = RequiereHoras();
            return new Asistencia
            {
                IdAsistencia = id, IdEmpleado = Seleccion("idEmpleado").Value, Fecha = Fecha("fecha"), IdTipoAsistencia = Seleccion("idTipoAsistencia").Value,
                HoraEntrada = horas ? Hora("horaEntrada") : (TimeSpan?)null, HoraSalida = horas ? Hora("horaSalida") : (TimeSpan?)null,
                Observacion = Texto("observacion")
            };
        }

        protected override void Insertar() { AsistenciaDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { AsistenciaDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { AsistenciaDatos.Eliminar(id); }
    }
}
