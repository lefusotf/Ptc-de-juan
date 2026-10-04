using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;

namespace Modelos.Datos
{
    public static class ParametrosLeyDatos
    {
        public static DataTable Listar()
        {
            return Conexion.Consultar("SELECT idParametroLey, codigo, descripcion, valor FROM parametroLey ORDER BY idParametroLey");
        }

        public static decimal Valor(string codigo, decimal predeterminado)
        {
            object v = Conexion.Escalar("SELECT valor FROM parametroLey WHERE codigo = @c", Conexion.P("@c", codigo));
            return v == null || v == System.DBNull.Value ? predeterminado : (decimal)v;
        }

        public static void ActualizarValor(int idParametroLey, decimal valor)
        {
            Conexion.EjecutarNoQuery("UPDATE parametroLey SET valor = @v WHERE idParametroLey = @id",
                Conexion.P("@v", valor), Conexion.P("@id", idParametroLey));
        }

        public static DataTable ListarTramos()
        {
            return Conexion.Consultar("SELECT idTramoRenta, nombre, desde, hasta, porcentaje, excesoSobre, cuotaFija FROM tramoRenta ORDER BY desde");
        }

        /// <summary>Carga todos los parámetros de ley y la tabla de renta para el motor de cálculo.</summary>
        public static ParametrosLey Cargar()
        {
            ParametrosLey p = new ParametrosLey();
            foreach (DataRow f in Listar().Rows)
            {
                decimal v = (decimal)f["valor"];
                switch ((string)f["codigo"])
                {
                    case "ISSS_EMPLEADO": p.IsssEmpleado = v; break;
                    case "ISSS_PATRONAL": p.IsssPatronal = v; break;
                    case "ISSS_TOPE": p.IsssTope = v; break;
                    case "AFP_EMPLEADO": p.AfpEmpleado = v; break;
                    case "AFP_PATRONAL": p.AfpPatronal = v; break;
                    case "AFP_TOPE": p.AfpTope = v; break;
                    case "DIAS_MES": p.DiasMes = v; break;
                    case "HORAS_DIA": p.HorasDia = v; break;
                    case "FACTOR_HORA_EXTRA": p.FactorHoraExtra = v; break;
                    case "SALARIO_MINIMO": p.SalarioMinimo = v; break;
                    case "DESCUENTA_TARDANZA": p.DescuentaTardanza = v != 0; break;
                }
            }
            foreach (DataRow f in ListarTramos().Rows)
            {
                p.Tramos.Add(new TramoRenta
                {
                    Desde = (decimal)f["desde"], Hasta = (decimal)f["hasta"], Porcentaje = (decimal)f["porcentaje"],
                    ExcesoSobre = (decimal)f["excesoSobre"], CuotaFija = (decimal)f["cuotaFija"]
                });
            }
            return p;
        }
    }
}
