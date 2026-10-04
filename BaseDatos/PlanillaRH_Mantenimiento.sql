-- =====================================================================
-- PlanillaRH - Pruebas de mantenimiento a nivel de base de datos
-- Demuestra mostrar, insertar, actualizar y eliminar registros, el uso de las vistas,
-- de los procedimientos almacenados y de los triggers.
-- Ejecutar DESPUÉS de PlanillaRH.sql (cada bloque es independiente).
-- =====================================================================
USE PlanillaRH;
GO

-- ---------- 1. MOSTRAR ----------
SELECT TOP 10 * FROM departamento ORDER BY nombre;
SELECT TOP 10 * FROM vwEmpleado ORDER BY nombreCompleto;     -- vista 1: empleados con departamento, cargo, horario y planilla
SELECT * FROM vwResumenDepartamento ORDER BY empleados DESC;  -- vista: alimenta los gráficos del dashboard
SELECT TOP 20 * FROM vwAsistencia ORDER BY fecha DESC;
GO

-- ---------- 2. INSERTAR / ACTUALIZAR / ELIMINAR (catálogo de ejemplo) ----------
INSERT INTO departamento (nombre, descripcion) VALUES ('Departamento de prueba', 'Se elimina al final de esta prueba');
SELECT * FROM departamento WHERE nombre = 'Departamento de prueba';

UPDATE departamento SET descripcion = 'Descripción modificada' WHERE nombre = 'Departamento de prueba';
SELECT * FROM departamento WHERE nombre = 'Departamento de prueba';

DELETE FROM departamento WHERE nombre = 'Departamento de prueba';
SELECT COUNT(*) AS quedan FROM departamento WHERE nombre = 'Departamento de prueba';
GO

-- ---------- 3. TRIGGER trgEmpleadoHistorialSalario (evento UPDATE) ----------
-- Al cambiar el salario de un empleado se registra automáticamente en historialSalario y en la bitácora.
DECLARE @id INT = (SELECT TOP 1 idEmpleado FROM empleado WHERE estado = 'Activo' ORDER BY idEmpleado);
SELECT idEmpleado, salarioBase FROM empleado WHERE idEmpleado = @id;
UPDATE empleado SET salarioBase = salarioBase + 10 WHERE idEmpleado = @id;      -- dispara el trigger
SELECT * FROM historialSalario WHERE idEmpleado = @id ORDER BY fecha DESC;      -- cambio registrado automáticamente
SELECT TOP 3 * FROM bitacora ORDER BY idBitacora DESC;
UPDATE empleado SET salarioBase = salarioBase - 10 WHERE idEmpleado = @id;      -- restaura el valor (queda otro registro de historial)
GO

-- ---------- 4. PROCEDIMIENTO sp_AprobarPermisoLaboral ----------
-- Aprueba el primer permiso pendiente y refleja los días hábiles en la asistencia.
DECLARE @permiso INT = (SELECT TOP 1 idPermisoLaboral FROM permisoLaboral WHERE estado = 'Pendiente' ORDER BY idPermisoLaboral);
SELECT * FROM vwPermisoLaboral WHERE idPermisoLaboral = @permiso;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = @permiso, @idUsuario = 1;
SELECT * FROM vwPermisoLaboral WHERE idPermisoLaboral = @permiso;
SELECT * FROM vwAsistencia WHERE idEmpleado = (SELECT idEmpleado FROM permisoLaboral WHERE idPermisoLaboral = @permiso) AND tipo <> 'Presente' ORDER BY fecha DESC;
GO

-- ---------- 5. PROCEDIMIENTO sp_AplicarAccionPersonal ----------
-- Aplica la primera acción pendiente y muestra el cambio en el empleado.
DECLARE @accion INT = (SELECT TOP 1 idAccionPersonal FROM accionPersonal WHERE estado = 'Pendiente' ORDER BY idAccionPersonal);
SELECT * FROM vwAccionPersonal WHERE idAccionPersonal = @accion;
EXEC sp_AplicarAccionPersonal @idAccionPersonal = @accion;
SELECT * FROM vwAccionPersonal WHERE idAccionPersonal = @accion;
GO

-- ---------- 6. TRIGGER trgPlanillaMensualProtegerCerrada (evento DELETE) ----------
-- Una planilla cerrada no se puede eliminar. (Genere y cierre una planilla desde la aplicación para probarlo.)
-- DELETE FROM planillaMensual WHERE estado = 'Cerrada';   -- produce el error ERR-NEG-040
GO
