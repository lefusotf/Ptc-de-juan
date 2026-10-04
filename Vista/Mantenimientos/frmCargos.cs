using System.Data;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Mantenimiento de cargos (puestos): cada cargo pertenece a un departamento y define su rango salarial.</summary>
    public class frmCargos : frmMantenimiento
    {
        protected override string Titulo { get { return "Cargos"; } }
        protected override string PermisoGestionar { get { return Permisos.DepartamentosGestionar; } }
        protected override string ColumnaId { get { return "idCargo"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("idDepartamento", "Departamento", TipoCampo.Combo) { Origen = DepartamentoDatos.ListarActivos, Ayuda = "Departamento al que pertenece el cargo." });
            Campos.Add(new Campo("nombre", "Nombre del cargo", TipoCampo.Alfanumerico, 80));
            Campos.Add(new Campo("salarioMinimo", "Salario mínimo del cargo ($)", TipoCampo.Decimal, 10) { Minimo = 0.01m, Maximo = 99999 });
            Campos.Add(new Campo("salarioMaximo", "Salario máximo del cargo ($)", TipoCampo.Decimal, 10) { Minimo = 0.01m, Maximo = 99999 });
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 10) { Opciones = new[] { "Activo", "Inactivo" }, Predeterminado = "Activo" });
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return CargoDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override string ValidarNegocio()
        {
            decimal min = Decimal("salarioMinimo"), max = Decimal("salarioMaximo");
            if (max < min) { MarcarError("salarioMaximo", "El salario máximo no puede ser menor al mínimo."); return "El salario máximo del cargo no puede ser menor al salario mínimo."; }
            decimal minimoLey = ParametrosLeyDatos.Valor("SALARIO_MINIMO", 0m);
            if (min < minimoLey) { MarcarError("salarioMinimo", "Menor al salario mínimo vigente."); return "El salario mínimo del cargo no puede ser menor al salario mínimo vigente ($" + minimoLey.ToString("N2") + ")."; }
            return null;
        }

        private Cargo Leer(int id)
        {
            return new Cargo
            {
                IdCargo = id, IdDepartamento = Seleccion("idDepartamento").Value, Nombre = Texto("nombre"),
                SalarioMinimo = Decimal("salarioMinimo"), SalarioMaximo = Decimal("salarioMaximo"), Estado = Opcion("estado")
            };
        }

        protected override void Insertar() { CargoDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { CargoDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { CargoDatos.Eliminar(id); }
    }
}
