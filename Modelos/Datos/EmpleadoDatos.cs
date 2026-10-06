using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class EmpleadoDatos
    {
        private const string Columnas = "idEmpleado, codigo, nombreCompleto, dui, telefono, departamento, cargo, planilla, fechaIngreso, salarioBase, estado";

        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwEmpleado",
                "WHERE codigo LIKE @f OR nombreCompleto LIKE @f OR dui LIKE @f OR nit LIKE @f OR departamento LIKE @f OR cargo LIKE @f OR estado LIKE @f",
                "nombreCompleto", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        /// <summary>Empleados no inactivos para llenar combos (código + nombre).</summary>
        public static DataTable ListarActivos()
        {
            return Conexion.Consultar(
                "SELECT idEmpleado, codigo + ' - ' + nombres + ' ' + apellidos AS nombre, nombres + ' ' + apellidos AS nombreCompleto, idDepartamento, idCargo, idHorario, idPlanilla, salarioBase, fechaIngreso, correo " +
                "FROM empleado WHERE estado <> 'Inactivo' ORDER BY nombres, apellidos");
        }

        public static DataRow Obtener(int idEmpleado)
        {
            DataTable t = Conexion.Consultar("SELECT * FROM vwEmpleado WHERE idEmpleado = @id", Conexion.P("@id", idEmpleado));
            return t.Rows.Count == 0 ? null : t.Rows[0];
        }

        public static string Estado(int idEmpleado)
        {
            return Conexion.Escalar("SELECT estado FROM empleado WHERE idEmpleado = @id", Conexion.P("@id", idEmpleado)) as string;
        }

        /// <summary>Regla de negocio: el salario debe respetar el salario mínimo y el rango del cargo.</summary>
        private static void ValidarSalario(int idCargo, decimal salario)
        {
            decimal minimo = ParametrosLeyDatos.Valor("SALARIO_MINIMO", 0m);
            if (salario < minimo)
                throw new ErrorSistemaException("ERR-NEG-055", "El salario mínimo vigente es $" + minimo.ToString("N2") + ".");

            DataTable t = Conexion.Consultar("SELECT salarioMinimo, salarioMaximo FROM cargo WHERE idCargo = @c", Conexion.P("@c", idCargo));
            if (t.Rows.Count == 0) throw new ErrorSistemaException("ERR-SQL-003");
            decimal min = (decimal)t.Rows[0]["salarioMinimo"], max = (decimal)t.Rows[0]["salarioMaximo"];
            if (salario < min || salario > max)
                throw new ErrorSistemaException("ERR-NEG-054", "El rango del cargo es de $" + min.ToString("N2") + " a $" + max.ToString("N2") + ".");
        }

        private static void ValidarPlanilla(int idPlanilla)
        {
            object per = Conexion.Escalar("SELECT periodicidad FROM planilla WHERE idPlanilla = @p", Conexion.P("@p", idPlanilla));
            if (per != null && per.ToString() == "Anual") throw new ErrorSistemaException("ERR-NEG-064");
        }

        public static void Insertar(Empleado e)
        {
            ValidarPlanilla(e.IdPlanilla);
            ValidarSalario(e.IdCargo, e.SalarioBase);
            Conexion.EjecutarNoQuery(
                "INSERT INTO empleado (nombres, apellidos, dui, nit, numeroIsss, numeroNup, sexo, fechaNacimiento, telefono, correo, direccion, " +
                "idDepartamento, idCargo, idHorario, idPlanilla, fechaIngreso, fechaRetiro, salarioBase, estado) " +
                "VALUES (@nom, @ape, @dui, @nit, @isss, @nup, @sexo, @nac, @tel, @correo, @dir, @dep, @cargo, @hor, @pla, @ing, @ret, @sal, @est)",
                Parametros(e));
        }

        public static void Actualizar(Empleado e)
        {
            ValidarPlanilla(e.IdPlanilla);
            ValidarSalario(e.IdCargo, e.SalarioBase);
            System.Data.SqlClient.SqlParameter[] p = Parametros(e);
            System.Array.Resize(ref p, p.Length + 1);
            p[p.Length - 1] = Conexion.P("@id", e.IdEmpleado);
            Conexion.EjecutarNoQuery(
                "UPDATE empleado SET nombres=@nom, apellidos=@ape, dui=@dui, nit=@nit, numeroIsss=@isss, numeroNup=@nup, sexo=@sexo, " +
                "fechaNacimiento=@nac, telefono=@tel, correo=@correo, direccion=@dir, idDepartamento=@dep, idCargo=@cargo, idHorario=@hor, " +
                "idPlanilla=@pla, fechaIngreso=@ing, fechaRetiro=@ret, salarioBase=@sal, estado=@est WHERE idEmpleado=@id", p);
        }

        public static void Eliminar(int id)
        {
            Conexion.EjecutarNoQuery("DELETE FROM empleado WHERE idEmpleado = @id", Conexion.P("@id", id));
        }

        private static System.Data.SqlClient.SqlParameter[] Parametros(Empleado e)
        {
            return new[]
            {
                Conexion.P("@nom", e.Nombres), Conexion.P("@ape", e.Apellidos), Conexion.P("@dui", e.Dui), Conexion.P("@nit", e.Nit),
                Conexion.P("@isss", e.NumeroIsss), Conexion.P("@nup", e.NumeroNup), Conexion.P("@sexo", e.Sexo),
                Conexion.P("@nac", e.FechaNacimiento), Conexion.P("@tel", e.Telefono), Conexion.P("@correo", e.Correo),
                Conexion.P("@dir", e.Direccion), Conexion.P("@dep", e.IdDepartamento), Conexion.P("@cargo", e.IdCargo),
                Conexion.P("@hor", e.IdHorario), Conexion.P("@pla", e.IdPlanilla), Conexion.P("@ing", e.FechaIngreso),
                Conexion.P("@ret", e.FechaRetiro), Conexion.P("@sal", e.SalarioBase), Conexion.P("@est", e.Estado)
            };
        }
    }
}
