-- =====================================================================
-- PlanillaRH - LIMPIAR LA BASE DE DATOS PARA UNA EMPRESA NUEVA
-- Borra empleados, usuarios, asistencia, permisos, acciones, planillas, préstamos, movimientos,
-- departamentos, cargos, horarios, planillas y bitácora. Conserva la estructura (tablas, vistas,
-- procedimientos y triggers) y lo indispensable: roles Administrador / Recursos Humanos / Contador
-- con sus permisos, permisos del sistema, parámetros de ley, tramos de renta y tipos de asistencia.
-- Deja el sistema "sin configurar": al abrir la aplicación se pedirá la Configuración Inicial
-- (datos de la empresa y primer administrador).
--
-- ¡ATENCIÓN! Es IRREVERSIBLE. Haga un respaldo antes:
--   BACKUP DATABASE PlanillaRH TO DISK = 'C:\Respaldo\PlanillaRH.bak';
-- =====================================================================
USE PlanillaRH;
GO

SET XACT_ABORT ON;
BEGIN TRANSACTION;

-- El trigger impide borrar planillas cerradas: se desactiva solo durante la limpieza
DISABLE TRIGGER trgPlanillaMensualProtegerCerrada ON planillaMensual;

-- Datos de operación (de los más dependientes a los menos dependientes)
DELETE FROM planillaDetalle;
DELETE FROM planillaMensual;
DELETE FROM planillaMovimiento;
DELETE FROM prestamo;
DELETE FROM historialSalario;
DELETE FROM accionPersonal;
DELETE FROM permisoLaboral;
DELETE FROM asistencia;
DELETE FROM bitacora;
DELETE FROM usuario;
DELETE FROM empleado;

-- Catálogos de la empresa
DELETE FROM cargo;
DELETE FROM horario;
DELETE FROM planilla;
DELETE FROM departamento;
DELETE FROM tipoMovimiento;

-- Seguridad: solo los 3 roles base (sus permisos de rolPermiso no se tocan)
DELETE FROM rol WHERE idRol > 3;

-- Catálogos de ley y asistencia: solo los indispensables
DELETE FROM parametroLey WHERE codigo NOT IN ('ISSS_EMPLEADO','ISSS_PATRONAL','ISSS_TOPE','AFP_EMPLEADO','AFP_PATRONAL','AFP_TOPE',
                                              'DIAS_MES','HORAS_DIA','FACTOR_HORA_EXTRA','SALARIO_MINIMO','DESCUENTA_TARDANZA');
DELETE FROM tipoAsistencia WHERE codigo NOT IN ('PRE','TAR','AUS','PCG','PSG','INC','VAC');

-- La empresa vuelve a quedar sin configurar
UPDATE configuracion
SET nombreEmpresa = 'Empresa sin configurar', nit = NULL, nrc = NULL, direccion = NULL, telefono = NULL,
    correo = NULL, logo = NULL, moneda = 'USD', configurado = 0, fechaConfiguracion = NULL
WHERE idConfiguracion = 1;

ENABLE TRIGGER trgPlanillaMensualProtegerCerrada ON planillaMensual;
COMMIT TRANSACTION;
GO

-- Reinicia los contadores para que los códigos (EMP-0001, ...) empiecen desde 1
DBCC CHECKIDENT ('planillaDetalle', RESEED, 0);
DBCC CHECKIDENT ('planillaMensual', RESEED, 0);
DBCC CHECKIDENT ('planillaMovimiento', RESEED, 0);
DBCC CHECKIDENT ('prestamo', RESEED, 0);
DBCC CHECKIDENT ('historialSalario', RESEED, 0);
DBCC CHECKIDENT ('accionPersonal', RESEED, 0);
DBCC CHECKIDENT ('permisoLaboral', RESEED, 0);
DBCC CHECKIDENT ('asistencia', RESEED, 0);
DBCC CHECKIDENT ('bitacora', RESEED, 0);
DBCC CHECKIDENT ('usuario', RESEED, 0);
DBCC CHECKIDENT ('empleado', RESEED, 0);
DBCC CHECKIDENT ('cargo', RESEED, 0);
DBCC CHECKIDENT ('horario', RESEED, 0);
DBCC CHECKIDENT ('planilla', RESEED, 0);
DBCC CHECKIDENT ('departamento', RESEED, 0);
DBCC CHECKIDENT ('tipoMovimiento', RESEED, 0);
GO

-- Verificación: debe mostrar 0 en las tablas de la empresa y los datos base en las demás
SELECT 'empleado' AS tabla, COUNT(*) AS filas FROM empleado
UNION ALL SELECT 'usuario', COUNT(*) FROM usuario
UNION ALL SELECT 'departamento', COUNT(*) FROM departamento
UNION ALL SELECT 'asistencia', COUNT(*) FROM asistencia
UNION ALL SELECT 'rol', COUNT(*) FROM rol
UNION ALL SELECT 'permisoSistema', COUNT(*) FROM permisoSistema
UNION ALL SELECT 'parametroLey', COUNT(*) FROM parametroLey
UNION ALL SELECT 'tipoAsistencia', COUNT(*) FROM tipoAsistencia;
SELECT nombreEmpresa, configurado FROM configuracion;
GO
