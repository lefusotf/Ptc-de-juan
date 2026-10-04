using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Modelos.Utilidades
{
    /// <summary>
    /// Excepción propia del sistema: lleva un código del catálogo (ERR-SQL-001, ERR-VAL-003...) y un mensaje
    /// amigable. La capa Vista solo muestra Codigo + Message al usuario.
    /// </summary>
    public class ErrorSistemaException : Exception
    {
        public string Codigo { get; private set; }
        public string Detalle { get; private set; }

        public ErrorSistemaException(string codigo, string detalle = null, Exception interna = null)
            : base(Errores.Mensaje(codigo), interna)
        {
            Codigo = codigo;
            Detalle = detalle;
        }

        /// <summary>Texto listo para mostrar: [CODIGO] mensaje y, si existe, el detalle específico.</summary>
        public string TextoCompleto
        {
            get
            {
                string texto = "[" + Codigo + "] " + Message;
                if (!string.IsNullOrWhiteSpace(Detalle) && Detalle != Message) texto += "\n" + Detalle;
                return texto;
            }
        }
    }

    /// <summary>
    /// Diccionario centralizado de códigos de error. Traduce cada código técnico a un mensaje descriptivo y
    /// clasifica las excepciones de SQL Server (incluidas las lanzadas con THROW desde los procedimientos
    /// almacenados con el formato "ERR-XXX-000|mensaje").
    /// </summary>
    public static class Errores
    {
        private static readonly Dictionary<string, string> Catalogo = new Dictionary<string, string>
        {
            // ---- Base de datos ----
            { "ERR-SQL-001", "No se pudo conectar con el servidor de base de datos. Verifique que SQL Server esté iniciado y que los datos de conexión sean correctos." },
            { "ERR-SQL-002", "Ya existe un registro con esos datos únicos (por ejemplo DUI, NIT, código o nombre)." },
            { "ERR-SQL-003", "Los datos hacen referencia a un registro que no existe o no es válido (llave foránea)." },
            { "ERR-SQL-004", "No se puede eliminar el registro porque tiene información relacionada en otras tablas." },
            { "ERR-SQL-005", "La base de datos no existe o el usuario no tiene permisos sobre ella. Use el formulario de conexión para crearla." },
            { "ERR-SQL-006", "SQL Server rechazó las credenciales de acceso (usuario o contraseña incorrectos)." },
            { "ERR-SQL-007", "La operación tardó demasiado y fue cancelada (tiempo de espera agotado)." },
            { "ERR-SQL-008", "Algún valor no cumple las reglas de la base de datos (restricción CHECK). Revise rangos y estados." },
            { "ERR-SQL-009", "Algún texto supera la longitud permitida por la base de datos." },
            { "ERR-SQL-010", "Falta un dato obligatorio que la base de datos no permite dejar vacío." },
            { "ERR-SQL-099", "Ocurrió un error de base de datos no clasificado." },
            // ---- Validación ----
            { "ERR-VAL-001", "Hay campos obligatorios sin completar." },
            { "ERR-VAL-002", "Algún dato no tiene el formato esperado." },
            { "ERR-VAL-003", "Algún dato supera la longitud máxima permitida." },
            { "ERR-VAL-004", "Algún valor está fuera del rango permitido." },
            { "ERR-VAL-005", "Alguna fecha no es válida para la lógica del proceso." },
            { "ERR-VAL-006", "Se ingresaron caracteres no permitidos en el campo." },
            // ---- Seguridad ----
            { "ERR-SEC-001", "Usuario o contraseña incorrectos." },
            { "ERR-SEC-002", "El usuario está inactivo. Contacte al administrador." },
            { "ERR-SEC-003", "Su rol no tiene permiso para realizar esta acción." },
            { "ERR-SEC-004", "La respuesta de seguridad no coincide." },
            { "ERR-SEC-005", "La contraseña no cumple la política de seguridad (mínimo 8 caracteres con mayúscula, minúscula, número y símbolo)." },
            // ---- Reglas de negocio (procedimientos almacenados y motor de planilla) ----
            { "ERR-NEG-001", "El permiso solicitado no existe." },
            { "ERR-NEG-002", "Solo se pueden aprobar o rechazar permisos en estado Pendiente." },
            { "ERR-NEG-003", "El empleado ya tiene un permiso aprobado que se traslapa con esas fechas." },
            { "ERR-NEG-010", "La acción de personal no existe." },
            { "ERR-NEG-011", "Solo se pueden aplicar acciones en estado Pendiente." },
            { "ERR-NEG-012", "El empleado está inactivo; no se pueden aplicar acciones de personal." },
            { "ERR-NEG-013", "La fecha de la acción no puede ser anterior al ingreso del empleado." },
            { "ERR-NEG-014", "El nuevo salario debe ser mayor al salario actual." },
            { "ERR-NEG-015", "El nuevo salario excede el máximo permitido para el cargo." },
            { "ERR-NEG-016", "La promoción requiere un nuevo cargo y un nuevo salario." },
            { "ERR-NEG-017", "El nuevo cargo debe pertenecer al departamento correspondiente." },
            { "ERR-NEG-018", "El salario está fuera del rango del cargo." },
            { "ERR-NEG-019", "El traslado requiere un nuevo departamento y un cargo de ese departamento." },
            { "ERR-NEG-020", "La suspensión requiere una fecha final igual o posterior a la fecha de inicio." },
            { "ERR-NEG-030", "La planilla mensual no existe." },
            { "ERR-NEG-031", "La planilla ya se encuentra cerrada." },
            { "ERR-NEG-032", "La planilla no tiene empleados; genérela antes de cerrarla." },
            { "ERR-NEG-040", "No se puede eliminar una planilla cerrada." },
            { "ERR-NEG-050", "No hay empleados activos asignados a la planilla seleccionada para ese período." },
            { "ERR-NEG-051", "La planilla de ese período ya está cerrada y no puede regenerarse." },
            { "ERR-NEG-052", "No se pueden registrar movimientos en un período cuya planilla ya fue cerrada." },
            { "ERR-NEG-053", "La cuota del préstamo no puede exceder el 20% del salario base del empleado." },
            { "ERR-NEG-054", "El salario debe estar dentro del rango definido para el cargo." },
            { "ERR-NEG-055", "El salario no puede ser menor al salario mínimo vigente." },
            { "ERR-NEG-056", "El empleado no está activo." },
            { "ERR-NEG-057", "Solo se pueden modificar o eliminar registros en estado Pendiente." },
            { "ERR-NEG-058", "El empleado ya tiene registrada la asistencia de esa fecha." },
            { "ERR-NEG-059", "No se puede eliminar o inactivar un elemento que tiene empleados asignados." },
            { "ERR-NEG-060", "El rol Administrador no puede eliminarse ni perder el permiso de gestión de roles." },
            { "ERR-NEG-061", "No se puede eliminar al usuario que tiene la sesión abierta." },
            // ---- Configuración y sistema ----
            { "ERR-CFG-001", "No existe una configuración de conexión guardada. Configure la conexión a SQL Server." },
            { "ERR-CFG-002", "No se encontró el script de la base de datos dentro de la aplicación." },
            { "ERR-CFG-003", "El nombre de la base de datos no es válido (use letras, números y guion bajo)." },
            { "ERR-SYS-001", "Ocurrió un error inesperado en la aplicación. Fue registrado en la bitácora." },
            { "ERR-SYS-002", "No se pudo leer o escribir un archivo. Verifique la ruta y los permisos." },
            { "ERR-SYS-003", "No se pudo generar el reporte o el documento solicitado." }
        };

        public static IEnumerable<KeyValuePair<string, string>> Todos { get { return Catalogo; } }

        public static string Mensaje(string codigo)
        {
            string texto;
            return codigo != null && Catalogo.TryGetValue(codigo, out texto) ? texto : "Error no catalogado (" + codigo + ").";
        }

        /// <summary>Convierte cualquier excepción en un ErrorSistemaException con su código del catálogo.</summary>
        public static ErrorSistemaException Clasificar(Exception ex)
        {
            ErrorSistemaException propio = ex as ErrorSistemaException;
            if (propio != null) return propio;

            SqlException sql = ex as SqlException;
            if (sql == null)
            {
                if (ex is System.IO.IOException || ex is UnauthorizedAccessException)
                    return new ErrorSistemaException("ERR-SYS-002", ex.Message, ex);
                return new ErrorSistemaException("ERR-SYS-001", ex.Message, ex);
            }

            // Errores lanzados con THROW desde los procedimientos almacenados: "ERR-NEG-002|mensaje"
            if (sql.Number >= 50000 && sql.Message != null && sql.Message.StartsWith("ERR-"))
            {
                int barra = sql.Message.IndexOf('|');
                string codigo = barra > 0 ? sql.Message.Substring(0, barra) : sql.Message;
                string detalle = barra > 0 ? sql.Message.Substring(barra + 1) : null;
                return new ErrorSistemaException(codigo, detalle, ex);
            }

            string msg = sql.Message ?? "";
            switch (sql.Number)
            {
                case 2627:
                case 2601: return new ErrorSistemaException("ERR-SQL-002", null, ex);
                case 547:
                    if (msg.Contains("DELETE")) return new ErrorSistemaException("ERR-SQL-004", null, ex);
                    if (msg.Contains("CHECK")) return new ErrorSistemaException("ERR-SQL-008", null, ex);
                    return new ErrorSistemaException("ERR-SQL-003", null, ex);
                case 515: return new ErrorSistemaException("ERR-SQL-010", null, ex);
                case 8152:
                case 2628: return new ErrorSistemaException("ERR-SQL-009", null, ex);
                case 4060:
                case 911: return new ErrorSistemaException("ERR-SQL-005", null, ex);
                case 18456: return new ErrorSistemaException("ERR-SQL-006", null, ex);
                case -2: return new ErrorSistemaException("ERR-SQL-007", null, ex);
                case 2:
                case 53:
                case -1:
                case 1231:
                case 10060:
                case 10061: return new ErrorSistemaException("ERR-SQL-001", sql.Message, ex);
                default: return new ErrorSistemaException("ERR-SQL-099", sql.Message, ex);
            }
        }
    }
}
