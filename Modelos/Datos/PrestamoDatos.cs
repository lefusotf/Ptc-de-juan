using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class PrestamoDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwPrestamo", "WHERE codigo LIKE @f OR empleado LIKE @f OR descripcion LIKE @f OR estado LIKE @f",
                "fechaOtorgado DESC, idPrestamo DESC", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        /// <summary>Regla de negocio: la cuota mensual no puede exceder el 20% del salario base del empleado.</summary>
        private static void Validar(Prestamo p)
        {
            object salario = Conexion.Escalar("SELECT salarioBase FROM empleado WHERE idEmpleado = @e AND estado <> 'Inactivo'", Conexion.P("@e", p.IdEmpleado));
            if (salario == null) throw new ErrorSistemaException("ERR-NEG-056");
            if (p.CuotaMensual > (decimal)salario * 0.20m)
                throw new ErrorSistemaException("ERR-NEG-053", "Cuota máxima permitida: $" + ((decimal)salario * 0.20m).ToString("N2") + ".");
        }

        public static void Insertar(Prestamo p)
        {
            Validar(p);
            Conexion.EjecutarNoQuery(
                "INSERT INTO prestamo (idEmpleado, monto, cuotaMensual, saldo, fechaOtorgado, descripcion) VALUES (@e, @m, @c, @m, @f, @d)",
                Conexion.P("@e", p.IdEmpleado), Conexion.P("@m", p.Monto), Conexion.P("@c", p.CuotaMensual),
                Conexion.P("@f", p.FechaOtorgado.Date), Conexion.P("@d", p.Descripcion));
        }

        /// <summary>Un préstamo con pagos realizados solo permite cambiar la descripción, la cuota o cancelarlo.</summary>
        public static void Actualizar(Prestamo p)
        {
            DataTable t = Conexion.Consultar("SELECT monto, saldo FROM prestamo WHERE idPrestamo = @id", Conexion.P("@id", p.IdPrestamo));
            if (t.Rows.Count == 0) throw new ErrorSistemaException("ERR-SQL-003");
            decimal monto = (decimal)t.Rows[0]["monto"], saldo = (decimal)t.Rows[0]["saldo"];
            bool conPagos = saldo < monto;
            if (conPagos && p.Monto != monto)
                throw new ErrorSistemaException("ERR-NEG-057", "El préstamo ya tiene pagos; no se puede modificar el monto.");
            Validar(p);

            Conexion.EjecutarNoQuery(
                "UPDATE prestamo SET idEmpleado=@e, monto=@m, cuotaMensual=@c, saldo=@s, fechaOtorgado=@f, descripcion=@d, estado=@es WHERE idPrestamo=@id",
                Conexion.P("@e", p.IdEmpleado), Conexion.P("@m", p.Monto), Conexion.P("@c", p.CuotaMensual),
                Conexion.P("@s", conPagos ? saldo : p.Monto), Conexion.P("@f", p.FechaOtorgado.Date),
                Conexion.P("@d", p.Descripcion), Conexion.P("@es", p.Estado), Conexion.P("@id", p.IdPrestamo));
        }

        public static void Eliminar(int id)
        {
            DataTable t = Conexion.Consultar("SELECT monto, saldo FROM prestamo WHERE idPrestamo = @id", Conexion.P("@id", id));
            if (t.Rows.Count > 0 && (decimal)t.Rows[0]["saldo"] < (decimal)t.Rows[0]["monto"])
                throw new ErrorSistemaException("ERR-NEG-057", "El préstamo ya tiene pagos; cámbielo a Cancelado en lugar de eliminarlo.");
            Conexion.EjecutarNoQuery("DELETE FROM prestamo WHERE idPrestamo = @id", Conexion.P("@id", id));
        }
    }
}
