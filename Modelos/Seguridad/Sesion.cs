using Modelos.Entidades;

namespace Modelos.Seguridad
{
    /// <summary>Usuario autenticado actualmente y verificación de permisos.</summary>
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; private set; }

        public static bool HaySesion { get { return UsuarioActual != null; } }

        public static void Iniciar(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
        }

        public static bool Tiene(string codigoPermiso)
        {
            return UsuarioActual != null && UsuarioActual.Permisos.Contains(codigoPermiso);
        }

        public static bool TieneAlguno(params string[] codigos)
        {
            foreach (string c in codigos)
                if (Tiene(c)) return true;
            return false;
        }
    }

    /// <summary>Códigos de permisos (coinciden con la columna codigo de la tabla permisoSistema).</summary>
    public static class Permisos
    {
        public const string BitacoraVer = "BITACORA_VER";
        public const string UsuariosGestionar = "USUARIOS_GESTIONAR";
        public const string RolesGestionar = "ROLES_GESTIONAR";
        public const string ConfiguracionGestionar = "CONFIGURACION_GESTIONAR";
        public const string DepartamentosVer = "DEPARTAMENTOS_VER";
        public const string DepartamentosGestionar = "DEPARTAMENTOS_GESTIONAR";
        public const string HorariosVer = "HORARIOS_VER";
        public const string HorariosGestionar = "HORARIOS_GESTIONAR";
        public const string EmpleadosVer = "EMPLEADOS_VER";
        public const string EmpleadosGestionar = "EMPLEADOS_GESTIONAR";
        public const string AsistenciaVer = "ASISTENCIA_VER";
        public const string AsistenciaGestionar = "ASISTENCIA_GESTIONAR";
        public const string PermisosVer = "PERMISOS_VER";
        public const string PermisosGestionar = "PERMISOS_GESTIONAR";
        public const string AccionesVer = "ACCIONES_VER";
        public const string AccionesGestionar = "ACCIONES_GESTIONAR";
        public const string PlanillaVer = "PLANILLA_VER";
        public const string PlanillaGestionar = "PLANILLA_GESTIONAR";
        public const string BoletasVer = "BOLETAS_VER";
        public const string ReportesVer = "REPORTES_VER";
    }
}
