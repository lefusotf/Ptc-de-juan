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
    /// Acciones de personal (aumento, promoción, traslado, suspensión, retiro y amonestación). Los campos cambian según el tipo
    /// de acción y, al aplicarla, un procedimiento almacenado actualiza al empleado validando salario, cargo y departamento.
    /// </summary>
    public class frmAccionesPersonales : frmMantenimiento
    {
        private Button _btnAplicar, _btnAnular;
        private bool _enlazado;

        protected override string Titulo { get { return "Acciones personales"; } }
        protected override string PermisoGestionar { get { return Permisos.AccionesGestionar; } }
        protected override string ColumnaId { get { return "idAccionPersonal"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("idEmpleado", "Empleado", TipoCampo.Combo) { Origen = EmpleadoDatos.ListarActivos });
            Campos.Add(new Campo("tipoAccion", "Tipo de acción", TipoCampo.Combo, 20) { Opciones = new[] { "Aumento salarial", "Promoción", "Traslado", "Suspensión", "Retiro", "Amonestación" } });
            Campos.Add(new Campo("fecha", "Fecha efectiva", TipoCampo.Fecha) { FechaMin = DateTime.Today.AddYears(-5), FechaMax = DateTime.Today.AddMonths(3) });
            Campos.Add(new Campo("descripcion", "Descripción", TipoCampo.Multilinea, 250));
            Campos.Add(new Campo("idDepartamentoNuevo", "Nuevo departamento", TipoCampo.Combo, 100, false) { Origen = DepartamentoDatos.ListarActivos, Columna = "idDepartamentoNuevo" });
            Campos.Add(new Campo("idCargoNuevo", "Nuevo cargo", TipoCampo.Combo, 100, false) { Padre = "idDepartamentoNuevo", OrigenDependiente = v => CargoDatos.ListarPorDepartamento(Convert.ToInt32(v)) });
            Campos.Add(new Campo("salarioNuevo", "Nuevo salario base ($)", TipoCampo.Decimal, 10, false) { Minimo = 0.01m, Maximo = 99999 });
            Campos.Add(new Campo("fechaFin", "Fecha final de la suspensión", TipoCampo.FechaOpcional, 10, false) { FechaMin = DateTime.Today.AddYears(-5), FechaMax = DateTime.Today.AddYears(1) });
            Campos.Add(new Campo("resumen", "", TipoCampo.Nota) { Predeterminado = "Seleccione el empleado y el tipo de acción." });

            _btnAplicar = AgregarAccion("Aplicar acción", "Aplica la acción al empleado (actualiza salario, cargo, departamento o estado).", Tema.Primario, Aplicar, Permisos.AccionesGestionar);
            _btnAnular = AgregarAccion("Anular", "Anula la acción pendiente seleccionada.", Tema.Peligro, Anular, Permisos.AccionesGestionar);
            HabilitarAccion(_btnAplicar, false);
            HabilitarAccion(_btnAnular, false);
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return AccionPersonalDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override void ConfigurarColumnas(DataGridView g)
        {
            GridUtil.Configurar(g);
            GridUtil.Ocultar(g, "descripcion", "registradoPor", "fechaRegistro");
        }

        protected override bool PuedeModificar(DataRow fila) { return fila == null || (string)fila["estado"] == "Pendiente"; }

        protected override void AlCambiarSeleccion(DataRow fila)
        {
            if (!_enlazado)
            {
                _enlazado = true;
                ((ComboBox)ControlDe("tipoAccion")).SelectedIndexChanged += (s, e) => AplicarTipo();
                ((ComboBox)ControlDe("idEmpleado")).SelectedIndexChanged += (s, e) => AplicarTipo();
            }
            AplicarTipo();
            bool pendiente = fila != null && (string)fila["estado"] == "Pendiente";
            if (_btnAplicar != null) { HabilitarAccion(_btnAplicar, pendiente); HabilitarAccion(_btnAnular, pendiente); }
        }

        /// <summary>Habilita solo los campos que usa el tipo de acción elegido y marca cuáles son obligatorios.</summary>
        private void AplicarTipo()
        {
            string tipo = Opcion("tipoAccion");
            DataRow emp = FilaCombo("idEmpleado");
            bool editable = FilaActual == null || (string)FilaActual["estado"] == "Pendiente";

            bool salario = tipo == "Aumento salarial" || tipo == "Promoción" || tipo == "Traslado";
            bool cargo = tipo == "Promoción" || tipo == "Traslado";
            bool depto = tipo == "Traslado";
            bool suspension = tipo == "Suspensión";

            Habilitar("salarioNuevo", salario && editable);
            Habilitar("idCargoNuevo", cargo && editable);
            Habilitar("idDepartamentoNuevo", depto && editable);
            Habilitar("fechaFin", suspension && editable);
            Requerir("salarioNuevo", tipo == "Aumento salarial" || tipo == "Promoción");
            Requerir("idCargoNuevo", cargo);
            Requerir("idDepartamentoNuevo", depto);
            Requerir("fechaFin", suspension);

            // En una promoción el departamento no cambia: se toma el actual del empleado
            if (tipo == "Promoción" && emp != null && FilaActual == null) Poner("idDepartamentoNuevo", emp["idDepartamento"]);

            string resumen = "Seleccione el empleado y el tipo de acción.";
            if (emp != null)
            {
                resumen = "Salario actual: $" + ((decimal)emp["salarioBase"]).ToString("N2");
                if (tipo == "Aumento salarial") resumen += " - el nuevo salario debe ser mayor y no exceder el máximo del cargo.";
                else if (tipo == "Promoción") resumen += " - elija un cargo del mismo departamento y un salario dentro de su rango.";
                else if (tipo == "Traslado") resumen += " - elija el nuevo departamento y un cargo de ese departamento.";
                else if (tipo == "Suspensión") resumen += " - indique hasta cuándo dura la suspensión.";
                else if (tipo == "Retiro") resumen += " - el empleado quedará Inactivo con la fecha efectiva como fecha de retiro.";
            }
            ControlDe("resumen").Text = resumen;
        }

        protected override string ValidarNegocio()
        {
            string tipo = Opcion("tipoAccion");
            DataRow emp = FilaCombo("idEmpleado");
            if (emp != null && Fecha("fecha") < (DateTime)emp["fechaIngreso"])
            {
                MarcarError("fecha", "Anterior al ingreso del empleado.");
                return "La fecha de la acción no puede ser anterior al ingreso del empleado.";
            }

            if (tipo == "Aumento salarial" && emp != null && Decimal("salarioNuevo") <= (decimal)emp["salarioBase"])
            {
                MarcarError("salarioNuevo", "Debe ser mayor al salario actual.");
                return "El nuevo salario debe ser mayor al salario actual ($" + ((decimal)emp["salarioBase"]).ToString("N2") + ").";
            }

            DataRow cargo = FilaCombo("idCargoNuevo");
            if (cargo != null && Texto("salarioNuevo") != null && (Decimal("salarioNuevo") < (decimal)cargo["salarioMinimo"] || Decimal("salarioNuevo") > (decimal)cargo["salarioMaximo"]))
            {
                MarcarError("salarioNuevo", "Fuera del rango del cargo.");
                return "El nuevo salario debe estar dentro del rango del cargo ($" + ((decimal)cargo["salarioMinimo"]).ToString("N2") + " a $" + ((decimal)cargo["salarioMaximo"]).ToString("N2") + ").";
            }

            if (tipo == "Suspensión")
            {
                DateTime? fin = FechaOpcional("fechaFin");
                if (fin.HasValue && fin.Value < Fecha("fecha")) { MarcarError("fechaFin", "No puede ser anterior al inicio."); return "La suspensión no puede terminar antes de iniciar."; }
            }
            return null;
        }

        private AccionPersonal Leer(int id)
        {
            string tipo = Opcion("tipoAccion");
            return new AccionPersonal
            {
                IdAccionPersonal = id, IdEmpleado = Seleccion("idEmpleado").Value, TipoAccion = tipo, Fecha = Fecha("fecha"), Descripcion = Texto("descripcion"),
                SalarioNuevo = Texto("salarioNuevo") != null && (tipo == "Aumento salarial" || tipo == "Promoción" || tipo == "Traslado") ? Decimal("salarioNuevo") : (decimal?)null,
                IdDepartamentoNuevo = tipo == "Promoción" || tipo == "Traslado" ? Seleccion("idDepartamentoNuevo") : null,
                IdCargoNuevo = tipo == "Promoción" || tipo == "Traslado" ? Seleccion("idCargoNuevo") : null,
                FechaFin = tipo == "Suspensión" ? FechaOpcional("fechaFin") : null,
                IdUsuario = Sesion.UsuarioActual.IdUsuario
            };
        }

        protected override void Insertar() { AccionPersonalDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { AccionPersonalDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { AccionPersonalDatos.Eliminar(id); }

        private void Aplicar(object sender, EventArgs e)
        {
            if (!IdActual.HasValue) return;
            if (!Mensajes.Confirmar("¿Aplicar la acción de personal seleccionada?\nSe actualizará la información del empleado.")) return;
            try
            {
                AccionPersonalDatos.Aplicar(IdActual.Value);
                Modelos.Utilidades.Logger.Info(Titulo, "Acción de personal aplicada (id " + IdActual + ")");
                Mensajes.Exito("La acción de personal fue aplicada al empleado.");
                Limpiar();
                Refrescar();
            }
            catch (Exception ex) { Mensajes.Error(Titulo, ex, "aplicar la acción"); }
        }

        private void Anular(object sender, EventArgs e)
        {
            if (!IdActual.HasValue) return;
            if (!Mensajes.Confirmar("¿Anular la acción de personal seleccionada?")) return;
            try
            {
                AccionPersonalDatos.Anular(IdActual.Value);
                Modelos.Utilidades.Logger.Info(Titulo, "Acción de personal anulada (id " + IdActual + ")");
                Mensajes.Exito("La acción de personal fue anulada.");
                Limpiar();
                Refrescar();
            }
            catch (Exception ex) { Mensajes.Error(Titulo, ex, "anular la acción"); }
        }
    }
}
