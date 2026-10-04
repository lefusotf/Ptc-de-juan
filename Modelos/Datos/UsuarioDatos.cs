using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Seguridad;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class UsuarioDatos
    {
        /// <summary>
        /// Valida las credenciales con BCrypt. Devuelve el usuario con los permisos de su rol, null si usuario o contraseña son
        /// incorrectos y lanza ERR-SEC-002 si las credenciales son correctas pero el usuario está inactivo.
        /// </summary>
        public static Usuario Autenticar(string nombreUsuario, string contrasena)
        {
            DataTable t = Conexion.Consultar(
                "SELECT u.idUsuario, u.idEmpleado, u.nombreCompleto, u.nombreUsuario, u.contrasena, u.correo, u.idRol, r.nombre AS rol, " +
                "u.debeCambiarClave, u.estado FROM usuario u INNER JOIN rol r ON r.idRol = u.idRol WHERE u.nombreUsuario = @u",
                Conexion.P("@u", nombreUsuario));

            if (t.Rows.Count == 0) return null;
            DataRow f = t.Rows[0];
            if (!EncriptadorContrasena.Verificar(contrasena, f["contrasena"].ToString())) return null;
            if (f["estado"].ToString() != "Activo") throw new ErrorSistemaException("ERR-SEC-002");

            Usuario usuario = new Usuario
            {
                IdUsuario = (int)f["idUsuario"],
                IdEmpleado = f["idEmpleado"] as int?,
                NombreCompleto = f["nombreCompleto"].ToString(),
                NombreUsuario = f["nombreUsuario"].ToString(),
                Correo = f["correo"] as string,
                IdRol = (int)f["idRol"],
                Rol = f["rol"].ToString(),
                DebeCambiarClave = (bool)f["debeCambiarClave"],
                Estado = f["estado"].ToString()
            };

            foreach (DataRow p in Conexion.Consultar(
                "SELECT p.codigo FROM rolPermiso rp INNER JOIN permisoSistema p ON p.idPermisoSistema = rp.idPermisoSistema WHERE rp.idRol = @r",
                Conexion.P("@r", usuario.IdRol)).Rows)
                usuario.Permisos.Add(p["codigo"].ToString());

            Conexion.EjecutarNoQuery("UPDATE usuario SET ultimoAcceso = GETDATE() WHERE idUsuario = @id", Conexion.P("@id", usuario.IdUsuario));
            return usuario;
        }

        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwUsuario",
                "WHERE nombreUsuario LIKE @f OR nombreCompleto LIKE @f OR rol LIKE @f OR correo LIKE @f OR estado LIKE @f",
                "nombreCompleto", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        /// <summary>Empleados activos que aún no tienen usuario (más el empleado indicado, al editar).</summary>
        public static DataTable EmpleadosDisponibles(int? idEmpleadoActual)
        {
            return Conexion.Consultar(
                "SELECT e.idEmpleado, e.codigo + ' - ' + e.nombres + ' ' + e.apellidos AS nombre, e.nombres + ' ' + e.apellidos AS nombreCompleto, e.correo " +
                "FROM empleado e WHERE e.estado <> 'Inactivo' AND (NOT EXISTS (SELECT 1 FROM usuario u WHERE u.idEmpleado = e.idEmpleado) " +
                "OR e.idEmpleado = @a) ORDER BY e.nombres, e.apellidos", Conexion.P("@a", idEmpleadoActual));
        }

        public static void Insertar(Usuario u)
        {
            Conexion.EjecutarNoQuery(
                "INSERT INTO usuario (idEmpleado, nombreUsuario, nombreCompleto, contrasena, correo, idRol, preguntaSeguridad, respuestaSeguridad, debeCambiarClave, estado) " +
                "VALUES (@emp, @usr, @nom, @clave, @correo, @rol, @preg, @resp, @cambiar, @estado)",
                Conexion.P("@emp", u.IdEmpleado), Conexion.P("@usr", u.NombreUsuario), Conexion.P("@nom", u.NombreCompleto),
                Conexion.P("@clave", EncriptadorContrasena.Hashear(u.Contrasena)), Conexion.P("@correo", u.Correo), Conexion.P("@rol", u.IdRol),
                Conexion.P("@preg", u.PreguntaSeguridad),
                Conexion.P("@resp", EncriptadorContrasena.Hashear(EncriptadorContrasena.NormalizarRespuesta(u.RespuestaSeguridad))),
                Conexion.P("@cambiar", u.DebeCambiarClave), Conexion.P("@estado", u.Estado));
        }

        /// <summary>Actualiza el usuario. Si Contrasena o RespuestaSeguridad vienen vacías se conservan las actuales.</summary>
        public static void Actualizar(Usuario u)
        {
            if (Sesion.HaySesion && Sesion.UsuarioActual.IdUsuario == u.IdUsuario && u.Estado == "Inactivo")
                throw new ErrorSistemaException("ERR-NEG-061");

            Conexion.EjecutarNoQuery(
                "UPDATE usuario SET idEmpleado=@emp, nombreUsuario=@usr, nombreCompleto=@nom, correo=@correo, idRol=@rol, preguntaSeguridad=@preg, estado=@estado " +
                "WHERE idUsuario=@id",
                Conexion.P("@emp", u.IdEmpleado), Conexion.P("@usr", u.NombreUsuario), Conexion.P("@nom", u.NombreCompleto),
                Conexion.P("@correo", u.Correo), Conexion.P("@rol", u.IdRol), Conexion.P("@preg", u.PreguntaSeguridad),
                Conexion.P("@estado", u.Estado), Conexion.P("@id", u.IdUsuario));

            if (!string.IsNullOrEmpty(u.Contrasena))
                CambiarContrasena(u.IdUsuario, u.Contrasena, u.DebeCambiarClave);
            if (!string.IsNullOrWhiteSpace(u.RespuestaSeguridad))
                Conexion.EjecutarNoQuery("UPDATE usuario SET respuestaSeguridad = @r WHERE idUsuario = @id",
                    Conexion.P("@r", EncriptadorContrasena.Hashear(EncriptadorContrasena.NormalizarRespuesta(u.RespuestaSeguridad))),
                    Conexion.P("@id", u.IdUsuario));
        }

        public static void Eliminar(int idUsuario)
        {
            if (Sesion.HaySesion && Sesion.UsuarioActual.IdUsuario == idUsuario) throw new ErrorSistemaException("ERR-NEG-061");
            Conexion.EjecutarNoQuery("DELETE FROM usuario WHERE idUsuario = @id", Conexion.P("@id", idUsuario));
        }

        public static void CambiarContrasena(int idUsuario, string nueva, bool debeCambiar)
        {
            Conexion.EjecutarNoQuery("UPDATE usuario SET contrasena = @c, debeCambiarClave = @d WHERE idUsuario = @id",
                Conexion.P("@c", EncriptadorContrasena.Hashear(nueva)), Conexion.P("@d", debeCambiar), Conexion.P("@id", idUsuario));
        }

        /// <summary>Genera una clave temporal, la guarda (con BCrypt) obligando a cambiarla en el próximo ingreso y la devuelve.</summary>
        public static string RestablecerConClaveTemporal(int idUsuario)
        {
            string temporal = EncriptadorContrasena.GenerarClaveTemporal();
            CambiarContrasena(idUsuario, temporal, true);
            return temporal;
        }

        public static bool VerificarContrasena(int idUsuario, string contrasena)
        {
            object h = Conexion.Escalar("SELECT contrasena FROM usuario WHERE idUsuario = @id", Conexion.P("@id", idUsuario));
            return h != null && EncriptadorContrasena.Verificar(contrasena, h.ToString());
        }

        // ---- Recuperación de contraseña por pregunta de seguridad ----
        /// <summary>Devuelve el usuario activo con su pregunta de seguridad o null si no existe.</summary>
        public static DataRow BuscarParaRecuperar(string nombreUsuario)
        {
            DataTable t = Conexion.Consultar(
                "SELECT idUsuario, nombreUsuario, preguntaSeguridad, estado FROM usuario WHERE nombreUsuario = @u", Conexion.P("@u", nombreUsuario));
            return t.Rows.Count == 0 ? null : t.Rows[0];
        }

        public static bool VerificarRespuesta(int idUsuario, string respuesta)
        {
            object h = Conexion.Escalar("SELECT respuestaSeguridad FROM usuario WHERE idUsuario = @id", Conexion.P("@id", idUsuario));
            return h != null && EncriptadorContrasena.Verificar(EncriptadorContrasena.NormalizarRespuesta(respuesta), h.ToString());
        }
    }
}
