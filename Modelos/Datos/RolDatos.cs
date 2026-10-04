using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Seguridad;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class RolDatos
    {
        public static DataTable Listar()
        {
            return Conexion.Consultar("SELECT idRol, nombre, descripcion FROM rol ORDER BY idRol");
        }

        public static DataTable ListarPermisos()
        {
            return Conexion.Consultar("SELECT idPermisoSistema, codigo, descripcion, modulo FROM permisoSistema ORDER BY idPermisoSistema");
        }

        public static HashSet<int> PermisosDelRol(int idRol)
        {
            HashSet<int> ids = new HashSet<int>();
            foreach (DataRow f in Conexion.Consultar("SELECT idPermisoSistema FROM rolPermiso WHERE idRol = @r", Conexion.P("@r", idRol)).Rows)
                ids.Add((int)f["idPermisoSistema"]);
            return ids;
        }

        public static void Insertar(Rol r)
        {
            Conexion.EjecutarNoQuery("INSERT INTO rol (nombre, descripcion) VALUES (@n, @d)", Conexion.P("@n", r.Nombre), Conexion.P("@d", r.Descripcion));
        }

        public static void Actualizar(Rol r)
        {
            Conexion.EjecutarNoQuery("UPDATE rol SET nombre = @n, descripcion = @d WHERE idRol = @id",
                Conexion.P("@n", r.Nombre), Conexion.P("@d", r.Descripcion), Conexion.P("@id", r.IdRol));
        }

        public static void Eliminar(int idRol)
        {
            if (idRol == 1) throw new ErrorSistemaException("ERR-NEG-060");
            if ((int)Conexion.Escalar("SELECT COUNT(*) FROM usuario WHERE idRol = @r", Conexion.P("@r", idRol)) > 0)
                throw new ErrorSistemaException("ERR-SQL-004", "Hay usuarios asignados a este rol.");
            Conexion.EjecutarNoQuery("DELETE FROM rol WHERE idRol = @r", Conexion.P("@r", idRol));
        }

        /// <summary>Reemplaza los permisos del rol. El Administrador siempre conserva la gestión de roles para no quedar bloqueado.</summary>
        public static void GuardarPermisos(int idRol, IEnumerable<int> idsPermisos)
        {
            List<int> ids = new List<int>(idsPermisos);
            if (idRol == 1)
            {
                object roles = Conexion.Escalar("SELECT idPermisoSistema FROM permisoSistema WHERE codigo = @c", Conexion.P("@c", Permisos.RolesGestionar));
                if (roles != null && !ids.Contains((int)roles)) throw new ErrorSistemaException("ERR-NEG-060");
            }

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                using (SqlTransaction tx = cn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand del = new SqlCommand("DELETE FROM rolPermiso WHERE idRol = @r", cn, tx))
                        {
                            del.Parameters.AddWithValue("@r", idRol);
                            del.ExecuteNonQuery();
                        }
                        foreach (int id in ids)
                        {
                            using (SqlCommand ins = new SqlCommand("INSERT INTO rolPermiso (idRol, idPermisoSistema) VALUES (@r, @p)", cn, tx))
                            {
                                ins.Parameters.AddWithValue("@r", idRol);
                                ins.Parameters.AddWithValue("@p", id);
                                ins.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }
    }
}
