-- =====================================================================
-- SISTEMA DE PLANILLA Y RECURSOS HUMANOS  (PlanillaRH)
-- Script de base de datos para SQL Server 2016 o superior (Express / LocalDB)
--
-- Contenido:
--   1. Creación de la base de datos
--   2. Tablas (seguridad, configuración, catálogos, personal, asistencia, planilla, auditoría)
--   3. Vistas        (vwEmpleado, vwCargo, vwUsuario, vwAsistencia, vwPermisoLaboral, vwAccionPersonal,
--                     vwPlanillaMovimiento, vwPrestamo, vwPlanillaMensual, vwPlanillaDetalle,
--                     vwResumenDepartamento, vwResumenPlanilla)
--   4. Procedimientos almacenados (aprobar permiso, aplicar acción de personal, cerrar planilla)
--   5. Triggers      (historial de salario, estado de préstamo, protección de planillas cerradas)
--   6. Datos iniciales y de demostración (el administrador se crea en la Configuración Inicial de la aplicación)
--
-- La aplicación puede ejecutar este mismo script desde el formulario "Conexión a SQL Server".
-- Para reiniciar:  DROP DATABASE PlanillaRH;  y volver a ejecutar el script.
-- =====================================================================

-- =====================================================================
-- 1. CREACIÓN DE LA BASE DE DATOS
-- =====================================================================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PlanillaRH')
BEGIN
    CREATE DATABASE PlanillaRH;
END
GO

USE PlanillaRH;
GO

-- =====================================================================
-- 2. TABLAS
-- =====================================================================

-- ---------- Configuración de la empresa (una sola fila) ----------
CREATE TABLE configuracion (
    idConfiguracion INT NOT NULL PRIMARY KEY CONSTRAINT ckConfiguracionUnica CHECK (idConfiguracion = 1),
    nombreEmpresa VARCHAR(150) NOT NULL,
    nit VARCHAR(17) NULL,
    nrc VARCHAR(10) NULL,
    direccion VARCHAR(250) NULL,
    telefono VARCHAR(9) NULL,
    correo VARCHAR(100) NULL,
    logo VARBINARY(MAX) NULL,
    moneda CHAR(3) NOT NULL DEFAULT 'USD',
    configurado BIT NOT NULL DEFAULT 0,
    fechaConfiguracion DATETIME NULL
);
GO

-- ---------- Seguridad: roles, permisos y usuarios ----------
CREATE TABLE rol (
    idRol INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL
);

CREATE TABLE permisoSistema (
    idPermisoSistema INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NOT NULL,
    modulo VARCHAR(50) NOT NULL
);

CREATE TABLE rolPermiso (
    idRol INT NOT NULL,
    idPermisoSistema INT NOT NULL,
    CONSTRAINT pkRolPermiso PRIMARY KEY (idRol, idPermisoSistema),
    CONSTRAINT fkRolPermisoRol FOREIGN KEY (idRol) REFERENCES rol(idRol) ON DELETE CASCADE,
    CONSTRAINT fkRolPermisoPermisoSistema FOREIGN KEY (idPermisoSistema) REFERENCES permisoSistema(idPermisoSistema) ON DELETE CASCADE
);
GO

-- ---------- Catálogos organizacionales ----------
CREATE TABLE departamento (
    idDepartamento INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(80) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    estado VARCHAR(10) NOT NULL DEFAULT 'Activo',
    CONSTRAINT ckDepartamentoEstado CHECK (estado IN ('Activo', 'Inactivo'))
);

-- Cargos (puestos) que pertenecen a un departamento
CREATE TABLE cargo (
    idCargo INT IDENTITY(1,1) PRIMARY KEY,
    idDepartamento INT NOT NULL,
    nombre VARCHAR(80) NOT NULL,
    salarioMinimo DECIMAL(10,2) NOT NULL,
    salarioMaximo DECIMAL(10,2) NOT NULL,
    estado VARCHAR(10) NOT NULL DEFAULT 'Activo',
    CONSTRAINT fkCargoDepartamento FOREIGN KEY (idDepartamento) REFERENCES departamento(idDepartamento),
    CONSTRAINT ukCargoNombre UNIQUE (idDepartamento, nombre),
    CONSTRAINT ukCargoDepartamento UNIQUE (idCargo, idDepartamento),   -- permite la llave foránea compuesta de empleado
    CONSTRAINT ckCargoSalario CHECK (salarioMinimo > 0 AND salarioMaximo >= salarioMinimo),
    CONSTRAINT ckCargoEstado CHECK (estado IN ('Activo', 'Inactivo'))
);

CREATE TABLE horario (
    idHorario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(60) NOT NULL UNIQUE,
    horaEntrada TIME(0) NOT NULL,
    horaSalida TIME(0) NOT NULL,
    minutosTolerancia INT NOT NULL DEFAULT 10,
    horasAlmuerzo DECIMAL(3,2) NOT NULL DEFAULT 1,
    horasDiarias AS CONVERT(DECIMAL(4,2), DATEDIFF(MINUTE, horaEntrada, horaSalida) / 60.0 - horasAlmuerzo) PERSISTED,
    estado VARCHAR(10) NOT NULL DEFAULT 'Activo',
    CONSTRAINT ckHorarioHoras CHECK (horaSalida > horaEntrada),
    CONSTRAINT ckHorarioTolerancia CHECK (minutosTolerancia BETWEEN 0 AND 60),
    CONSTRAINT ckHorarioAlmuerzo CHECK (horasAlmuerzo BETWEEN 0 AND 3),
    CONSTRAINT ckHorarioEstado CHECK (estado IN ('Activo', 'Inactivo'))
);

-- Tipos de planilla de la empresa (a cuál planilla pertenece cada empleado)
CREATE TABLE planilla (
    idPlanilla INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(80) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    periodicidad VARCHAR(10) NOT NULL DEFAULT 'Mensual',
    estado VARCHAR(10) NOT NULL DEFAULT 'Activo',
    CONSTRAINT ckPlanillaPeriodicidad CHECK (periodicidad IN ('Mensual')),
    CONSTRAINT ckPlanillaEstado CHECK (estado IN ('Activo', 'Inactivo'))
);
GO

-- ---------- Empleados ----------
CREATE TABLE empleado (
    idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    codigo AS ('EMP-' + RIGHT('0000' + CONVERT(VARCHAR(10), idEmpleado), 4)) PERSISTED,
    nombres VARCHAR(80) NOT NULL,
    apellidos VARCHAR(80) NOT NULL,
    dui CHAR(10) NOT NULL UNIQUE,
    nit VARCHAR(17) NOT NULL UNIQUE,
    numeroIsss VARCHAR(9) NOT NULL,
    numeroNup VARCHAR(12) NOT NULL,
    sexo CHAR(1) NOT NULL,
    fechaNacimiento DATE NOT NULL,
    telefono VARCHAR(9) NOT NULL,
    correo VARCHAR(100) NULL,
    direccion VARCHAR(250) NULL,
    idDepartamento INT NOT NULL,
    idCargo INT NOT NULL,
    idHorario INT NOT NULL,
    idPlanilla INT NOT NULL,
    fechaIngreso DATE NOT NULL,
    fechaRetiro DATE NULL,
    salarioBase DECIMAL(10,2) NOT NULL,
    estado VARCHAR(12) NOT NULL DEFAULT 'Activo',
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fkEmpleadoDepartamento FOREIGN KEY (idDepartamento) REFERENCES departamento(idDepartamento),
    -- el cargo debe pertenecer al departamento del empleado (coherencia a nivel de base de datos)
    CONSTRAINT fkEmpleadoCargo FOREIGN KEY (idCargo, idDepartamento) REFERENCES cargo(idCargo, idDepartamento),
    CONSTRAINT fkEmpleadoHorario FOREIGN KEY (idHorario) REFERENCES horario(idHorario),
    CONSTRAINT fkEmpleadoPlanilla FOREIGN KEY (idPlanilla) REFERENCES planilla(idPlanilla),
    CONSTRAINT ckEmpleadoSexo CHECK (sexo IN ('M', 'F')),
    CONSTRAINT ckEmpleadoSalario CHECK (salarioBase > 0),
    CONSTRAINT ckEmpleadoRetiro CHECK (fechaRetiro IS NULL OR fechaRetiro >= fechaIngreso),
    CONSTRAINT ckEmpleadoEstado CHECK (estado IN ('Activo', 'Inactivo', 'Suspendido'))
);

-- Usuarios del sistema (opcionalmente vinculados a un empleado). La contraseña se guarda con BCrypt
CREATE TABLE usuario (
    idUsuario INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NULL,
    nombreUsuario VARCHAR(30) NOT NULL UNIQUE,
    nombreCompleto VARCHAR(160) NOT NULL,
    contrasena VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NULL,
    idRol INT NOT NULL,
    preguntaSeguridad VARCHAR(150) NOT NULL,
    respuestaSeguridad VARCHAR(100) NOT NULL,
    debeCambiarClave BIT NOT NULL DEFAULT 0,
    estado VARCHAR(10) NOT NULL DEFAULT 'Activo',
    fechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    ultimoAcceso DATETIME NULL,
    CONSTRAINT fkUsuarioEmpleado FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
    CONSTRAINT fkUsuarioRol FOREIGN KEY (idRol) REFERENCES rol(idRol),
    CONSTRAINT ckUsuarioEstado CHECK (estado IN ('Activo', 'Inactivo'))
);
CREATE UNIQUE INDEX ukUsuarioEmpleado ON usuario(idEmpleado) WHERE idEmpleado IS NOT NULL;
GO

-- ---------- Asistencia ----------
CREATE TABLE tipoAsistencia (
    idTipoAsistencia INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(5) NOT NULL UNIQUE,
    nombre VARCHAR(60) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    descuentaDia BIT NOT NULL DEFAULT 0,        -- 1 = el día se descuenta del salario
    requiereHoras BIT NOT NULL DEFAULT 0,       -- 1 = se deben registrar hora de entrada y salida
    estado VARCHAR(10) NOT NULL DEFAULT 'Activo',
    CONSTRAINT ckTipoAsistenciaEstado CHECK (estado IN ('Activo', 'Inactivo'))
);

CREATE TABLE asistencia (
    idAsistencia INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NOT NULL,
    fecha DATE NOT NULL,
    idTipoAsistencia INT NOT NULL,
    horaEntrada TIME(0) NULL,
    horaSalida TIME(0) NULL,
    horasTrabajadas DECIMAL(5,2) NOT NULL DEFAULT 0,
    minutosTarde INT NOT NULL DEFAULT 0,
    horasExtra DECIMAL(5,2) NOT NULL DEFAULT 0,
    observacion VARCHAR(250) NULL,
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fkAsistenciaEmpleado FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
    CONSTRAINT fkAsistenciaTipo FOREIGN KEY (idTipoAsistencia) REFERENCES tipoAsistencia(idTipoAsistencia),
    CONSTRAINT ukAsistenciaEmpleadoFecha UNIQUE (idEmpleado, fecha),
    CONSTRAINT ckAsistenciaHoras CHECK (horaEntrada IS NULL OR horaSalida IS NULL OR horaSalida > horaEntrada),
    CONSTRAINT ckAsistenciaValores CHECK (horasTrabajadas >= 0 AND minutosTarde >= 0 AND horasExtra >= 0)
);
CREATE INDEX ixAsistenciaFecha ON asistencia(fecha);
GO

-- ---------- Permisos laborales y acciones de personal ----------
CREATE TABLE permisoLaboral (
    idPermisoLaboral INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NOT NULL,
    tipo VARCHAR(15) NOT NULL,
    fechaInicio DATE NOT NULL,
    fechaFin DATE NOT NULL,
    dias AS (DATEDIFF(DAY, fechaInicio, fechaFin) + 1) PERSISTED,
    motivo VARCHAR(250) NOT NULL,
    estado VARCHAR(10) NOT NULL DEFAULT 'Pendiente',
    idUsuarioResuelve INT NULL,
    fechaSolicitud DATETIME NOT NULL DEFAULT GETDATE(),
    fechaResolucion DATETIME NULL,
    CONSTRAINT fkPermisoLaboralEmpleado FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
    CONSTRAINT fkPermisoLaboralUsuario FOREIGN KEY (idUsuarioResuelve) REFERENCES usuario(idUsuario),
    CONSTRAINT ckPermisoLaboralTipo CHECK (tipo IN ('Con goce', 'Sin goce', 'Incapacidad', 'Vacaciones')),
    CONSTRAINT ckPermisoLaboralFechas CHECK (fechaFin >= fechaInicio),
    CONSTRAINT ckPermisoLaboralEstado CHECK (estado IN ('Pendiente', 'Aprobado', 'Rechazado'))
);

CREATE TABLE accionPersonal (
    idAccionPersonal INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NOT NULL,
    tipoAccion VARCHAR(20) NOT NULL,
    fecha DATE NOT NULL,
    descripcion VARCHAR(250) NOT NULL,
    salarioNuevo DECIMAL(10,2) NULL,
    idDepartamentoNuevo INT NULL,
    idCargoNuevo INT NULL,
    fechaFin DATE NULL,
    estado VARCHAR(10) NOT NULL DEFAULT 'Pendiente',
    idUsuario INT NOT NULL,
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fkAccionPersonalEmpleado FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
    CONSTRAINT fkAccionPersonalUsuario FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario),
    CONSTRAINT fkAccionPersonalDepartamento FOREIGN KEY (idDepartamentoNuevo) REFERENCES departamento(idDepartamento),
    CONSTRAINT fkAccionPersonalCargo FOREIGN KEY (idCargoNuevo, idDepartamentoNuevo) REFERENCES cargo(idCargo, idDepartamento),
    CONSTRAINT ckAccionPersonalTipo CHECK (tipoAccion IN ('Aumento salarial', 'Promoción', 'Traslado', 'Suspensión', 'Retiro', 'Amonestación')),
    CONSTRAINT ckAccionPersonalEstado CHECK (estado IN ('Pendiente', 'Aplicada', 'Anulada')),
    CONSTRAINT ckAccionPersonalSalario CHECK (salarioNuevo IS NULL OR salarioNuevo > 0)
);

-- Historial de cambios de salario (lo alimenta un trigger)
CREATE TABLE historialSalario (
    idHistorialSalario INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NOT NULL,
    salarioAnterior DECIMAL(10,2) NOT NULL,
    salarioNuevo DECIMAL(10,2) NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    usuarioBd VARCHAR(100) NULL,
    CONSTRAINT fkHistorialSalarioEmpleado FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado)
);
GO

-- ---------- Planilla ----------
CREATE TABLE parametroLey (
    idParametroLey INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(30) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NOT NULL,
    valor DECIMAL(12,4) NOT NULL
);

CREATE TABLE tramoRenta (
    idTramoRenta INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(20) NOT NULL UNIQUE,
    desde DECIMAL(12,2) NOT NULL,
    hasta DECIMAL(12,2) NOT NULL,
    porcentaje DECIMAL(5,2) NOT NULL,
    excesoSobre DECIMAL(12,2) NOT NULL,
    cuotaFija DECIMAL(12,2) NOT NULL,
    CONSTRAINT ckTramoRenta CHECK (hasta >= desde AND porcentaje BETWEEN 0 AND 100)
);

CREATE TABLE tipoMovimiento (
    idTipoMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(60) NOT NULL UNIQUE,
    naturaleza VARCHAR(10) NOT NULL,
    gravable BIT NOT NULL DEFAULT 1,
    estado VARCHAR(10) NOT NULL DEFAULT 'Activo',
    CONSTRAINT ckTipoMovimientoNaturaleza CHECK (naturaleza IN ('Ingreso', 'Deducción')),
    CONSTRAINT ckTipoMovimientoEstado CHECK (estado IN ('Activo', 'Inactivo'))
);

-- Movimientos variables del mes (bonos, comisiones, descuentos internos...)
CREATE TABLE planillaMovimiento (
    idPlanillaMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NOT NULL,
    idTipoMovimiento INT NOT NULL,
    anio SMALLINT NOT NULL,
    mes TINYINT NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    descripcion VARCHAR(200) NULL,
    aplicado BIT NOT NULL DEFAULT 0,
    idUsuario INT NULL,
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT fkMovimientoEmpleado FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
    CONSTRAINT fkMovimientoTipo FOREIGN KEY (idTipoMovimiento) REFERENCES tipoMovimiento(idTipoMovimiento),
    CONSTRAINT fkMovimientoUsuario FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario),
    CONSTRAINT ckMovimientoMes CHECK (mes BETWEEN 1 AND 12),
    CONSTRAINT ckMovimientoAnio CHECK (anio BETWEEN 2000 AND 2100),
    CONSTRAINT ckMovimientoMonto CHECK (monto > 0)
);

CREATE TABLE prestamo (
    idPrestamo INT IDENTITY(1,1) PRIMARY KEY,
    idEmpleado INT NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    cuotaMensual DECIMAL(10,2) NOT NULL,
    saldo DECIMAL(10,2) NOT NULL,
    fechaOtorgado DATE NOT NULL,
    descripcion VARCHAR(200) NULL,
    estado VARCHAR(10) NOT NULL DEFAULT 'Activo',
    CONSTRAINT fkPrestamoEmpleado FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
    CONSTRAINT ckPrestamoMonto CHECK (monto > 0 AND cuotaMensual > 0 AND cuotaMensual <= monto),
    CONSTRAINT ckPrestamoSaldo CHECK (saldo >= 0 AND saldo <= monto),
    CONSTRAINT ckPrestamoEstado CHECK (estado IN ('Activo', 'Pagado', 'Cancelado'))
);

CREATE TABLE planillaMensual (
    idPlanillaMensual INT IDENTITY(1,1) PRIMARY KEY,
    idPlanilla INT NOT NULL,
    anio SMALLINT NOT NULL,
    mes TINYINT NOT NULL,
    fechaGeneracion DATETIME NOT NULL DEFAULT GETDATE(),
    estado VARCHAR(10) NOT NULL DEFAULT 'Borrador',
    totalIngresos DECIMAL(12,2) NOT NULL DEFAULT 0,
    totalDeducciones DECIMAL(12,2) NOT NULL DEFAULT 0,
    totalNeto DECIMAL(12,2) NOT NULL DEFAULT 0,
    totalPatronal DECIMAL(12,2) NOT NULL DEFAULT 0,
    idUsuario INT NOT NULL,
    CONSTRAINT fkPlanillaMensualPlanilla FOREIGN KEY (idPlanilla) REFERENCES planilla(idPlanilla),
    CONSTRAINT fkPlanillaMensualUsuario FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario),
    CONSTRAINT ukPlanillaMensualPeriodo UNIQUE (idPlanilla, anio, mes),
    CONSTRAINT ckPlanillaMensualMes CHECK (mes BETWEEN 1 AND 12),
    CONSTRAINT ckPlanillaMensualEstado CHECK (estado IN ('Borrador', 'Cerrada'))
);

CREATE TABLE planillaDetalle (
    idPlanillaDetalle INT IDENTITY(1,1) PRIMARY KEY,
    idPlanillaMensual INT NOT NULL,
    idEmpleado INT NOT NULL,
    salarioBase DECIMAL(10,2) NOT NULL,
    diasLaborados INT NOT NULL,
    diasAusencia INT NOT NULL DEFAULT 0,
    minutosTarde INT NOT NULL DEFAULT 0,
    descuentoTardanza DECIMAL(10,2) NOT NULL DEFAULT 0,
    salarioDevengado DECIMAL(10,2) NOT NULL,
    horasExtra DECIMAL(6,2) NOT NULL DEFAULT 0,
    montoHorasExtra DECIMAL(10,2) NOT NULL DEFAULT 0,
    otrosIngresos DECIMAL(10,2) NOT NULL DEFAULT 0,
    totalIngresos DECIMAL(10,2) NOT NULL,
    isss DECIMAL(10,2) NOT NULL DEFAULT 0,
    afp DECIMAL(10,2) NOT NULL DEFAULT 0,
    renta DECIMAL(10,2) NOT NULL DEFAULT 0,
    prestamos DECIMAL(10,2) NOT NULL DEFAULT 0,
    otrosDescuentos DECIMAL(10,2) NOT NULL DEFAULT 0,
    totalDeducciones DECIMAL(10,2) NOT NULL DEFAULT 0,
    salarioNeto DECIMAL(10,2) NOT NULL,
    isssPatronal DECIMAL(10,2) NOT NULL DEFAULT 0,
    afpPatronal DECIMAL(10,2) NOT NULL DEFAULT 0,
    CONSTRAINT fkPlanillaDetallePlanillaMensual FOREIGN KEY (idPlanillaMensual) REFERENCES planillaMensual(idPlanillaMensual) ON DELETE CASCADE,
    CONSTRAINT fkPlanillaDetalleEmpleado FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
    CONSTRAINT ukPlanillaDetalleEmpleado UNIQUE (idPlanillaMensual, idEmpleado),
    CONSTRAINT ckPlanillaDetalleDias CHECK (diasLaborados BETWEEN 0 AND 30 AND diasAusencia BETWEEN 0 AND 30)
);
GO

-- ---------- Auditoría ----------
CREATE TABLE bitacora (
    idBitacora INT IDENTITY(1,1) PRIMARY KEY,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    nivel VARCHAR(10) NOT NULL,
    nombreUsuario VARCHAR(50) NULL,
    modulo VARCHAR(60) NOT NULL,
    mensaje VARCHAR(500) NOT NULL,
    detalle VARCHAR(MAX) NULL,
    CONSTRAINT ckBitacoraNivel CHECK (nivel IN ('INFO', 'ADVERTENCIA', 'ERROR'))
);
CREATE INDEX ixBitacoraFecha ON bitacora(fecha DESC);
GO

-- =====================================================================
-- 3. VISTAS
-- =====================================================================

-- Vista 1: empleados con departamento, cargo, horario y planilla (alimenta el formulario de empleados y reportes)
CREATE VIEW vwEmpleado AS
SELECT e.idEmpleado, e.codigo, e.nombres, e.apellidos,
       e.nombres + ' ' + e.apellidos AS nombreCompleto,
       e.dui, e.nit, e.numeroIsss, e.numeroNup, e.sexo, e.fechaNacimiento, e.telefono, e.correo, e.direccion,
       e.idDepartamento, d.nombre AS departamento,
       e.idCargo, c.nombre AS cargo,
       e.idHorario, h.nombre AS horario,
       e.idPlanilla, p.nombre AS planilla,
       e.fechaIngreso, e.fechaRetiro, e.salarioBase, e.estado
FROM empleado e
INNER JOIN departamento d ON d.idDepartamento = e.idDepartamento
INNER JOIN cargo c ON c.idCargo = e.idCargo
INNER JOIN horario h ON h.idHorario = e.idHorario
INNER JOIN planilla p ON p.idPlanilla = e.idPlanilla;
GO

CREATE VIEW vwCargo AS
SELECT c.idCargo, c.idDepartamento, d.nombre AS departamento, c.nombre, c.salarioMinimo, c.salarioMaximo, c.estado,
       (SELECT COUNT(*) FROM empleado e WHERE e.idCargo = c.idCargo AND e.estado <> 'Inactivo') AS empleados
FROM cargo c
INNER JOIN departamento d ON d.idDepartamento = c.idDepartamento;
GO

CREATE VIEW vwUsuario AS
SELECT u.idUsuario, u.idEmpleado, e.codigo AS codigoEmpleado, u.nombreUsuario, u.nombreCompleto, u.correo,
       u.idRol, r.nombre AS rol, u.preguntaSeguridad, u.debeCambiarClave, u.estado, u.fechaCreacion, u.ultimoAcceso
FROM usuario u
INNER JOIN rol r ON r.idRol = u.idRol
LEFT JOIN empleado e ON e.idEmpleado = u.idEmpleado;
GO

CREATE VIEW vwAsistencia AS
SELECT a.idAsistencia, a.idEmpleado, e.codigo, e.nombres + ' ' + e.apellidos AS empleado,
       e.idDepartamento, d.nombre AS departamento, a.fecha,
       a.idTipoAsistencia, t.codigo AS codigoTipo, t.nombre AS tipo,
       a.horaEntrada, a.horaSalida, a.horasTrabajadas, a.minutosTarde, a.horasExtra, a.observacion
FROM asistencia a
INNER JOIN empleado e ON e.idEmpleado = a.idEmpleado
INNER JOIN departamento d ON d.idDepartamento = e.idDepartamento
INNER JOIN tipoAsistencia t ON t.idTipoAsistencia = a.idTipoAsistencia;
GO

CREATE VIEW vwPermisoLaboral AS
SELECT p.idPermisoLaboral, p.idEmpleado, e.codigo, e.nombres + ' ' + e.apellidos AS empleado,
       d.nombre AS departamento, p.tipo, p.fechaInicio, p.fechaFin, p.dias, p.motivo, p.estado,
       p.idUsuarioResuelve, u.nombreUsuario AS resueltoPor, p.fechaSolicitud, p.fechaResolucion
FROM permisoLaboral p
INNER JOIN empleado e ON e.idEmpleado = p.idEmpleado
INNER JOIN departamento d ON d.idDepartamento = e.idDepartamento
LEFT JOIN usuario u ON u.idUsuario = p.idUsuarioResuelve;
GO

CREATE VIEW vwAccionPersonal AS
SELECT a.idAccionPersonal, a.idEmpleado, e.codigo, e.nombres + ' ' + e.apellidos AS empleado,
       a.tipoAccion, a.fecha, a.descripcion, a.salarioNuevo,
       a.idDepartamentoNuevo, dn.nombre AS departamentoNuevo,
       a.idCargoNuevo, cn.nombre AS cargoNuevo, a.fechaFin, a.estado,
       a.idUsuario, u.nombreUsuario AS registradoPor, a.fechaRegistro
FROM accionPersonal a
INNER JOIN empleado e ON e.idEmpleado = a.idEmpleado
INNER JOIN usuario u ON u.idUsuario = a.idUsuario
LEFT JOIN departamento dn ON dn.idDepartamento = a.idDepartamentoNuevo
LEFT JOIN cargo cn ON cn.idCargo = a.idCargoNuevo;
GO

CREATE VIEW vwPlanillaMovimiento AS
SELECT m.idPlanillaMovimiento, m.idEmpleado, e.codigo, e.nombres + ' ' + e.apellidos AS empleado,
       m.idTipoMovimiento, t.nombre AS tipoMovimiento, t.naturaleza, t.gravable,
       m.anio, m.mes, m.monto, m.descripcion, m.aplicado, m.fechaRegistro
FROM planillaMovimiento m
INNER JOIN empleado e ON e.idEmpleado = m.idEmpleado
INNER JOIN tipoMovimiento t ON t.idTipoMovimiento = m.idTipoMovimiento;
GO

CREATE VIEW vwPrestamo AS
SELECT p.idPrestamo, p.idEmpleado, e.codigo, e.nombres + ' ' + e.apellidos AS empleado, e.salarioBase,
       p.monto, p.cuotaMensual, p.saldo, p.fechaOtorgado, p.descripcion, p.estado
FROM prestamo p
INNER JOIN empleado e ON e.idEmpleado = p.idEmpleado;
GO

CREATE VIEW vwPlanillaMensual AS
SELECT pm.idPlanillaMensual, pm.idPlanilla, p.nombre AS planilla, pm.anio, pm.mes,
       CONVERT(VARCHAR(4), pm.anio) + '-' + RIGHT('0' + CONVERT(VARCHAR(2), pm.mes), 2) AS periodo,
       pm.fechaGeneracion, pm.estado, pm.totalIngresos, pm.totalDeducciones, pm.totalNeto, pm.totalPatronal,
       (SELECT COUNT(*) FROM planillaDetalle d WHERE d.idPlanillaMensual = pm.idPlanillaMensual) AS empleados,
       pm.idUsuario, u.nombreUsuario AS generadaPor
FROM planillaMensual pm
INNER JOIN planilla p ON p.idPlanilla = pm.idPlanilla
INNER JOIN usuario u ON u.idUsuario = pm.idUsuario;
GO

-- Detalle de planilla con los datos del empleado (fuente de la boleta de pago y de los reportes)
CREATE VIEW vwPlanillaDetalle AS
SELECT d.idPlanillaDetalle, d.idPlanillaMensual, pm.idPlanilla, pl.nombre AS planilla, pm.anio, pm.mes, pm.estado AS estadoPlanilla,
       d.idEmpleado, e.codigo, e.nombres + ' ' + e.apellidos AS empleado, e.dui, e.numeroIsss, e.numeroNup,
       e.idDepartamento, dp.nombre AS departamento, c.nombre AS cargo,
       d.salarioBase, d.diasLaborados, d.diasAusencia, d.minutosTarde, d.descuentoTardanza, d.salarioDevengado,
       d.horasExtra, d.montoHorasExtra, d.otrosIngresos, d.totalIngresos,
       d.isss, d.afp, d.renta, d.prestamos, d.otrosDescuentos, d.totalDeducciones, d.salarioNeto,
       d.isssPatronal, d.afpPatronal
FROM planillaDetalle d
INNER JOIN planillaMensual pm ON pm.idPlanillaMensual = d.idPlanillaMensual
INNER JOIN planilla pl ON pl.idPlanilla = pm.idPlanilla
INNER JOIN empleado e ON e.idEmpleado = d.idEmpleado
INNER JOIN departamento dp ON dp.idDepartamento = e.idDepartamento
INNER JOIN cargo c ON c.idCargo = e.idCargo;
GO

-- Resumen por departamento (gráficos del Dashboard)
CREATE VIEW vwResumenDepartamento AS
SELECT d.idDepartamento, d.nombre AS departamento,
       COUNT(e.idEmpleado) AS empleados,
       ISNULL(SUM(e.salarioBase), 0) AS salarioTotal,
       ISNULL(AVG(e.salarioBase), 0) AS salarioPromedio
FROM departamento d
LEFT JOIN empleado e ON e.idDepartamento = d.idDepartamento AND e.estado <> 'Inactivo'
GROUP BY d.idDepartamento, d.nombre;
GO

-- Totales por período (gráfico de planilla del Dashboard)
CREATE VIEW vwResumenPlanilla AS
SELECT anio, mes,
       CONVERT(VARCHAR(4), anio) + '-' + RIGHT('0' + CONVERT(VARCHAR(2), mes), 2) AS periodo,
       SUM(totalIngresos) AS totalIngresos, SUM(totalDeducciones) AS totalDeducciones,
       SUM(totalNeto) AS totalNeto, SUM(totalPatronal) AS totalPatronal
FROM planillaMensual
GROUP BY anio, mes;
GO

-- =====================================================================
-- 4. PROCEDIMIENTOS ALMACENADOS
--    Los errores de negocio se lanzan con THROW en el formato  "CODIGO|mensaje"
--    para que la aplicación los traduzca con su catálogo de códigos de error.
-- =====================================================================

-- Aprueba un permiso laboral y refleja los días hábiles aprobados en la asistencia del empleado
CREATE PROCEDURE sp_AprobarPermisoLaboral
    @idPermisoLaboral INT,
    @idUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @idEmpleado INT, @inicio DATE, @fin DATE, @tipo VARCHAR(15), @estado VARCHAR(10), @idTipo INT, @codigo VARCHAR(5);

    SELECT @idEmpleado = idEmpleado, @inicio = fechaInicio, @fin = fechaFin, @tipo = tipo, @estado = estado
    FROM permisoLaboral WHERE idPermisoLaboral = @idPermisoLaboral;

    IF @idEmpleado IS NULL
        THROW 50001, 'ERR-NEG-001|El permiso solicitado no existe.', 1;
    IF @estado <> 'Pendiente'
        THROW 50002, 'ERR-NEG-002|Solo se pueden aprobar permisos en estado Pendiente.', 1;
    IF EXISTS (SELECT 1 FROM permisoLaboral
               WHERE idEmpleado = @idEmpleado AND estado = 'Aprobado'
                 AND idPermisoLaboral <> @idPermisoLaboral AND fechaInicio <= @fin AND fechaFin >= @inicio)
        THROW 50003, 'ERR-NEG-003|El empleado ya tiene un permiso aprobado que se traslapa con esas fechas.', 1;

    SET @codigo = CASE @tipo WHEN 'Con goce' THEN 'PCG' WHEN 'Sin goce' THEN 'PSG' WHEN 'Incapacidad' THEN 'INC' ELSE 'VAC' END;
    SELECT @idTipo = idTipoAsistencia FROM tipoAsistencia WHERE codigo = @codigo;

    BEGIN TRANSACTION;

    UPDATE permisoLaboral
    SET estado = 'Aprobado', idUsuarioResuelve = @idUsuario, fechaResolucion = GETDATE()
    WHERE idPermisoLaboral = @idPermisoLaboral;

    -- Días hábiles (lunes a viernes) del permiso
    CREATE TABLE #dias (dia DATE PRIMARY KEY);
    ;WITH dias AS (
        SELECT @inicio AS dia
        UNION ALL
        SELECT DATEADD(DAY, 1, dia) FROM dias WHERE dia < @fin
    )
    INSERT INTO #dias (dia)
    SELECT dia FROM dias WHERE (DATEDIFF(DAY, '19000101', dia) % 7) < 5
    OPTION (MAXRECURSION 400);

    UPDATE a
    SET idTipoAsistencia = @idTipo, horaEntrada = NULL, horaSalida = NULL,
        horasTrabajadas = 0, minutosTarde = 0, horasExtra = 0, observacion = 'Permiso laboral aprobado'
    FROM asistencia a
    INNER JOIN #dias d ON d.dia = a.fecha
    WHERE a.idEmpleado = @idEmpleado;

    INSERT INTO asistencia (idEmpleado, fecha, idTipoAsistencia, observacion)
    SELECT @idEmpleado, d.dia, @idTipo, 'Permiso laboral aprobado'
    FROM #dias d
    WHERE NOT EXISTS (SELECT 1 FROM asistencia a WHERE a.idEmpleado = @idEmpleado AND a.fecha = d.dia);

    DROP TABLE #dias;
    COMMIT TRANSACTION;
END
GO

-- Aplica una acción de personal sobre el empleado validando la coherencia salario / cargo / departamento
CREATE PROCEDURE sp_AplicarAccionPersonal
    @idAccionPersonal INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @idEmpleado INT, @tipo VARCHAR(20), @estado VARCHAR(10), @fecha DATE, @fechaFin DATE,
            @salarioNuevo DECIMAL(10,2), @idDeptoNuevo INT, @idCargoNuevo INT,
            @salarioActual DECIMAL(10,2), @idDeptoActual INT, @estadoEmpleado VARCHAR(12), @ingreso DATE,
            @min DECIMAL(10,2), @max DECIMAL(10,2);

    SELECT @idEmpleado = idEmpleado, @tipo = tipoAccion, @estado = estado, @fecha = fecha, @fechaFin = fechaFin,
           @salarioNuevo = salarioNuevo, @idDeptoNuevo = idDepartamentoNuevo, @idCargoNuevo = idCargoNuevo
    FROM accionPersonal WHERE idAccionPersonal = @idAccionPersonal;

    IF @idEmpleado IS NULL
        THROW 50010, 'ERR-NEG-010|La acción de personal no existe.', 1;
    IF @estado <> 'Pendiente'
        THROW 50011, 'ERR-NEG-011|Solo se pueden aplicar acciones en estado Pendiente.', 1;

    SELECT @salarioActual = salarioBase, @idDeptoActual = idDepartamento, @estadoEmpleado = estado, @ingreso = fechaIngreso
    FROM empleado WHERE idEmpleado = @idEmpleado;

    IF @estadoEmpleado = 'Inactivo'
        THROW 50012, 'ERR-NEG-012|El empleado está inactivo; no se pueden aplicar acciones de personal.', 1;
    IF @fecha < @ingreso
        THROW 50013, 'ERR-NEG-013|La fecha de la acción no puede ser anterior al ingreso del empleado.', 1;

    BEGIN TRANSACTION;

    IF @tipo = 'Aumento salarial'
    BEGIN
        IF @salarioNuevo IS NULL OR @salarioNuevo <= @salarioActual
            THROW 50014, 'ERR-NEG-014|El nuevo salario debe ser mayor al salario actual.', 1;
        SELECT @min = c.salarioMinimo, @max = c.salarioMaximo FROM cargo c INNER JOIN empleado e ON e.idCargo = c.idCargo WHERE e.idEmpleado = @idEmpleado;
        IF @salarioNuevo > @max
            THROW 50015, 'ERR-NEG-015|El nuevo salario excede el máximo permitido para el cargo.', 1;
        UPDATE empleado SET salarioBase = @salarioNuevo WHERE idEmpleado = @idEmpleado;
    END
    ELSE IF @tipo = 'Promoción'
    BEGIN
        IF @idCargoNuevo IS NULL OR @salarioNuevo IS NULL
            THROW 50016, 'ERR-NEG-016|La promoción requiere un nuevo cargo y un nuevo salario.', 1;
        SELECT @min = salarioMinimo, @max = salarioMaximo FROM cargo WHERE idCargo = @idCargoNuevo AND idDepartamento = @idDeptoActual;
        IF @min IS NULL
            THROW 50017, 'ERR-NEG-017|El nuevo cargo debe pertenecer al departamento actual del empleado.', 1;
        IF @salarioNuevo < @min OR @salarioNuevo > @max
            THROW 50018, 'ERR-NEG-018|El nuevo salario está fuera del rango del cargo.', 1;
        UPDATE empleado SET idCargo = @idCargoNuevo, salarioBase = @salarioNuevo WHERE idEmpleado = @idEmpleado;
    END
    ELSE IF @tipo = 'Traslado'
    BEGIN
        IF @idDeptoNuevo IS NULL OR @idCargoNuevo IS NULL
            THROW 50019, 'ERR-NEG-019|El traslado requiere un nuevo departamento y un cargo de ese departamento.', 1;
        SELECT @min = salarioMinimo, @max = salarioMaximo FROM cargo WHERE idCargo = @idCargoNuevo AND idDepartamento = @idDeptoNuevo;
        IF @min IS NULL
            THROW 50017, 'ERR-NEG-017|El nuevo cargo debe pertenecer al departamento seleccionado.', 1;
        SET @salarioNuevo = ISNULL(@salarioNuevo, @salarioActual);
        IF @salarioNuevo < @min OR @salarioNuevo > @max
            THROW 50018, 'ERR-NEG-018|El salario está fuera del rango del nuevo cargo.', 1;
        UPDATE empleado SET idDepartamento = @idDeptoNuevo, idCargo = @idCargoNuevo, salarioBase = @salarioNuevo WHERE idEmpleado = @idEmpleado;
    END
    ELSE IF @tipo = 'Suspensión'
    BEGIN
        IF @fechaFin IS NULL OR @fechaFin < @fecha
            THROW 50020, 'ERR-NEG-020|La suspensión requiere una fecha final igual o posterior a la fecha de inicio.', 1;
        UPDATE empleado SET estado = 'Suspendido' WHERE idEmpleado = @idEmpleado;
    END
    ELSE IF @tipo = 'Retiro'
    BEGIN
        UPDATE empleado SET estado = 'Inactivo', fechaRetiro = @fecha WHERE idEmpleado = @idEmpleado;
    END

    UPDATE accionPersonal SET estado = 'Aplicada' WHERE idAccionPersonal = @idAccionPersonal;
    COMMIT TRANSACTION;
END
GO

-- Cierra una planilla mensual: descuenta las cuotas de los préstamos y marca los movimientos como aplicados
CREATE PROCEDURE sp_CerrarPlanillaMensual
    @idPlanillaMensual INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @estado VARCHAR(10), @anio SMALLINT, @mes TINYINT, @idPlanilla INT;

    SELECT @estado = estado, @anio = anio, @mes = mes, @idPlanilla = idPlanilla
    FROM planillaMensual WHERE idPlanillaMensual = @idPlanillaMensual;

    IF @estado IS NULL
        THROW 50030, 'ERR-NEG-030|La planilla mensual no existe.', 1;
    IF @estado = 'Cerrada'
        THROW 50031, 'ERR-NEG-031|La planilla ya se encuentra cerrada.', 1;
    IF NOT EXISTS (SELECT 1 FROM planillaDetalle WHERE idPlanillaMensual = @idPlanillaMensual)
        THROW 50032, 'ERR-NEG-032|La planilla no tiene empleados; genérela antes de cerrarla.', 1;

    BEGIN TRANSACTION;

    -- Cada préstamo activo de un empleado de la planilla paga su cuota (o el saldo si es menor)
    UPDATE p
    SET saldo = CASE WHEN p.saldo > p.cuotaMensual THEN p.saldo - p.cuotaMensual ELSE 0 END
    FROM prestamo p
    INNER JOIN planillaDetalle d ON d.idEmpleado = p.idEmpleado AND d.idPlanillaMensual = @idPlanillaMensual
    WHERE p.estado = 'Activo' AND d.prestamos > 0 AND p.fechaOtorgado < DATEFROMPARTS(@anio, @mes, 1) ;

    UPDATE m
    SET aplicado = 1
    FROM planillaMovimiento m
    INNER JOIN planillaDetalle d ON d.idEmpleado = m.idEmpleado AND d.idPlanillaMensual = @idPlanillaMensual
    WHERE m.anio = @anio AND m.mes = @mes;

    UPDATE planillaMensual SET estado = 'Cerrada' WHERE idPlanillaMensual = @idPlanillaMensual;
    COMMIT TRANSACTION;
END
GO

-- =====================================================================
-- 5. TRIGGERS
-- =====================================================================

-- Trigger 1 (UPDATE): registra cada cambio de salario en historialSalario y en la bitácora
CREATE TRIGGER trgEmpleadoHistorialSalario ON empleado
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(salarioBase)
    BEGIN
        INSERT INTO historialSalario (idEmpleado, salarioAnterior, salarioNuevo, usuarioBd)
        SELECT i.idEmpleado, d.salarioBase, i.salarioBase, SUSER_SNAME()
        FROM inserted i INNER JOIN deleted d ON d.idEmpleado = i.idEmpleado
        WHERE i.salarioBase <> d.salarioBase;

        INSERT INTO bitacora (nivel, nombreUsuario, modulo, mensaje)
        SELECT 'INFO', SUSER_SNAME(), 'Empleados',
               'Cambio de salario de ' + i.nombres + ' ' + i.apellidos + ': $' + CONVERT(VARCHAR(20), d.salarioBase) + ' -> $' + CONVERT(VARCHAR(20), i.salarioBase)
        FROM inserted i INNER JOIN deleted d ON d.idEmpleado = i.idEmpleado
        WHERE i.salarioBase <> d.salarioBase;
    END
END
GO

-- Trigger 2 (UPDATE): cuando el saldo de un préstamo llega a cero, el préstamo pasa a Pagado
CREATE TRIGGER trgPrestamoEstado ON prestamo
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(saldo)
    BEGIN
        UPDATE p SET estado = 'Pagado'
        FROM prestamo p INNER JOIN inserted i ON i.idPrestamo = p.idPrestamo
        WHERE i.saldo = 0 AND p.estado = 'Activo';
    END
END
GO

-- Trigger 3 (DELETE): impide eliminar planillas cerradas (respaldo para auditorías contables)
CREATE TRIGGER trgPlanillaMensualProtegerCerrada ON planillaMensual
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM deleted WHERE estado = 'Cerrada')
    BEGIN
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW 50040, 'ERR-NEG-040|No se puede eliminar una planilla cerrada.', 1;
    END
END
GO

-- =====================================================================
-- 6. DATOS INICIALES
-- =====================================================================

INSERT INTO configuracion (idConfiguracion, nombreEmpresa, moneda, configurado) VALUES (1, 'Empresa sin configurar', 'USD', 0);

INSERT INTO rol (nombre, descripcion) VALUES
('Administrador', 'Administra la configuración, los usuarios y tiene control general del sistema'),
('Recursos Humanos', 'Gestiona empleados, asistencia, permisos, acciones de personal y movimientos'),
('Contador', 'Genera y cierra la planilla, emite boletas y reportes');

INSERT INTO permisoSistema (codigo, descripcion, modulo) VALUES
('BITACORA_VER', 'Consultar la bitácora del sistema', 'Seguridad'),
('USUARIOS_GESTIONAR', 'Crear, editar y eliminar usuarios y asignarles rol', 'Seguridad'),
('ROLES_GESTIONAR', 'Asignar permisos a los roles', 'Seguridad'),
('CONFIGURACION_GESTIONAR', 'Modificar la configuración de la empresa y los parámetros de ley', 'Seguridad'),
('DEPARTAMENTOS_VER', 'Consultar departamentos y cargos', 'Organización'),
('DEPARTAMENTOS_GESTIONAR', 'Registrar, editar y eliminar departamentos y cargos', 'Organización'),
('HORARIOS_VER', 'Consultar horarios de trabajo', 'Organización'),
('HORARIOS_GESTIONAR', 'Registrar, editar y eliminar horarios de trabajo', 'Organización'),
('EMPLEADOS_VER', 'Consultar empleados', 'Personal'),
('EMPLEADOS_GESTIONAR', 'Registrar, editar y eliminar empleados', 'Personal'),
('ASISTENCIA_VER', 'Consultar asistencia y tipos de asistencia', 'Personal'),
('ASISTENCIA_GESTIONAR', 'Registrar, editar y eliminar asistencia y tipos de asistencia', 'Personal'),
('PERMISOS_VER', 'Consultar permisos laborales', 'Personal'),
('PERMISOS_GESTIONAR', 'Solicitar, aprobar, rechazar y eliminar permisos laborales', 'Personal'),
('ACCIONES_VER', 'Consultar acciones de personal', 'Personal'),
('ACCIONES_GESTIONAR', 'Registrar y aplicar acciones de personal', 'Personal'),
('PLANILLA_VER', 'Consultar planillas, movimientos y préstamos', 'Planilla'),
('PLANILLA_GESTIONAR', 'Gestionar planillas, generar y cerrar la planilla mensual, movimientos y préstamos', 'Planilla'),
('BOLETAS_VER', 'Consultar y generar boletas de pago', 'Planilla'),
('REPORTES_VER', 'Generar reportes en PDF y Excel', 'Planilla');

-- Administrador: todos los permisos
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 1, idPermisoSistema FROM permisoSistema;

-- Recursos Humanos
INSERT INTO rolPermiso (idRol, idPermisoSistema)
SELECT 2, idPermisoSistema FROM permisoSistema
WHERE codigo IN ('DEPARTAMENTOS_VER','DEPARTAMENTOS_GESTIONAR','HORARIOS_VER','HORARIOS_GESTIONAR',
                 'EMPLEADOS_VER','EMPLEADOS_GESTIONAR','ASISTENCIA_VER','ASISTENCIA_GESTIONAR',
                 'PERMISOS_VER','PERMISOS_GESTIONAR','ACCIONES_VER','ACCIONES_GESTIONAR',
                 'PLANILLA_VER','BOLETAS_VER','REPORTES_VER');

-- Contador
INSERT INTO rolPermiso (idRol, idPermisoSistema)
SELECT 3, idPermisoSistema FROM permisoSistema
WHERE codigo IN ('DEPARTAMENTOS_VER','HORARIOS_VER','EMPLEADOS_VER','ASISTENCIA_VER','PERMISOS_VER','ACCIONES_VER',
                 'PLANILLA_VER','PLANILLA_GESTIONAR','BOLETAS_VER','REPORTES_VER');
GO

-- Parámetros de ley (editables). Verifique su vigencia antes de procesar una planilla real.
INSERT INTO parametroLey (codigo, descripcion, valor) VALUES
('ISSS_EMPLEADO', 'ISSS - porcentaje que aporta el empleado', 0.0300),
('ISSS_PATRONAL', 'ISSS - porcentaje que aporta el patrono', 0.0750),
('ISSS_TOPE', 'ISSS - salario máximo cotizable mensual', 1000.0000),
('AFP_EMPLEADO', 'AFP - porcentaje que aporta el empleado', 0.0725),
('AFP_PATRONAL', 'AFP - porcentaje que aporta el patrono', 0.0875),
('AFP_TOPE', 'AFP - salario máximo cotizable mensual', 7045.0600),
('DIAS_MES', 'Días que se usan para el cálculo del salario mensual', 30.0000),
('HORAS_DIA', 'Horas de la jornada diaria para calcular el valor de la hora', 8.0000),
('FACTOR_HORA_EXTRA', 'Factor de pago de la hora extra diurna (recargo del 100%)', 2.0000),
('SALARIO_MINIMO', 'Salario mínimo mensual vigente', 408.8000),
('DESCUENTA_TARDANZA', 'Descontar los minutos de tardanza (1 = sí, 0 = no)', 1.0000);

-- Tabla de retención de renta mensual
INSERT INTO tramoRenta (nombre, desde, hasta, porcentaje, excesoSobre, cuotaFija) VALUES
('Tramo I',   0.01,    550.00,  0, 0.00,    0.00),
('Tramo II',  550.01,  895.24, 10, 550.00,  17.67),
('Tramo III', 895.25, 2038.10, 20, 895.24,  60.00),
('Tramo IV', 2038.11, 99999999.99, 30, 2038.10, 288.57);

INSERT INTO tipoAsistencia (codigo, nombre, descripcion, descuentaDia, requiereHoras) VALUES
('PRE', 'Presente', 'Asistió y cumplió su jornada', 0, 1),
('TAR', 'Tardanza', 'Llegó después de la tolerancia del horario', 0, 1),
('AUS', 'Ausencia injustificada', 'No se presentó y no tiene permiso; se descuenta el día', 1, 0),
('PCG', 'Permiso con goce de sueldo', 'Permiso aprobado sin descuento', 0, 0),
('PSG', 'Permiso sin goce de sueldo', 'Permiso aprobado con descuento del día', 1, 0),
('INC', 'Incapacidad', 'Incapacidad médica comprobada', 0, 0),
('VAC', 'Vacaciones', 'Día de vacaciones aprobado', 0, 0);

INSERT INTO tipoMovimiento (nombre, naturaleza, gravable) VALUES
('Bono por desempeño', 'Ingreso', 1),
('Comisión por ventas', 'Ingreso', 1),
('Bonificación extraordinaria', 'Ingreso', 1),
('Viáticos', 'Ingreso', 0),
('Descuento por uniforme', 'Deducción', 1),
('Anticipo de salario', 'Deducción', 1),
('Cuota sindical', 'Deducción', 1),
('Seguro médico privado', 'Deducción', 1),
('Embargo judicial', 'Deducción', 1);
GO

INSERT INTO departamento (nombre, descripcion) VALUES
('Administración', 'Dirección general y apoyo administrativo'),
('Recursos Humanos', 'Gestión del talento, planilla y personal'),
('Finanzas y Contabilidad', 'Contabilidad, tesorería y control financiero'),
('Ventas y Mercadeo', 'Ventas, publicidad y atención comercial'),
('Tecnología de la Información', 'Desarrollo, infraestructura y soporte técnico'),
('Operaciones', 'Producción y mantenimiento'),
('Logística y Bodega', 'Almacenaje, despacho y transporte'),
('Servicio al Cliente', 'Atención, soporte y calidad del servicio');

INSERT INTO cargo (idDepartamento, nombre, salarioMinimo, salarioMaximo) VALUES
(1, 'Gerente General', 2500.00, 4500.00),
(1, 'Asistente Administrativo', 450.00, 900.00),
(1, 'Recepcionista', 408.80, 650.00),
(2, 'Jefe de Recursos Humanos', 1200.00, 2200.00),
(2, 'Analista de Planillas', 700.00, 1300.00),
(2, 'Técnico de Reclutamiento', 500.00, 900.00),
(3, 'Contador General', 1100.00, 2200.00),
(3, 'Auxiliar Contable', 500.00, 900.00),
(3, 'Tesorero', 900.00, 1600.00),
(4, 'Jefe de Ventas', 1100.00, 2000.00),
(4, 'Ejecutivo de Ventas', 450.00, 1200.00),
(4, 'Diseñador de Mercadeo', 500.00, 1000.00),
(5, 'Jefe de Tecnología', 1400.00, 2600.00),
(5, 'Desarrollador de Software', 800.00, 1800.00),
(5, 'Técnico de Soporte', 500.00, 950.00),
(6, 'Supervisor de Operaciones', 800.00, 1400.00),
(6, 'Operario de Producción', 408.80, 650.00),
(6, 'Técnico de Mantenimiento', 500.00, 900.00),
(7, 'Encargado de Bodega', 550.00, 950.00),
(7, 'Motorista', 450.00, 750.00),
(7, 'Auxiliar de Bodega', 408.80, 600.00),
(8, 'Jefe de Servicio al Cliente', 900.00, 1500.00),
(8, 'Agente de Servicio', 408.80, 700.00),
(8, 'Supervisor de Calidad', 600.00, 1000.00);

INSERT INTO horario (nombre, horaEntrada, horaSalida, minutosTolerancia, horasAlmuerzo) VALUES
('Administrativo', '08:00', '17:00', 10, 1.00),
('Operativo diurno', '07:00', '16:00', 10, 1.00),
('Turno tarde', '12:00', '21:00', 10, 1.00),
('Bodega temprano', '06:00', '15:00', 10, 1.00),
('Comercial', '08:30', '17:30', 15, 1.00),
('Medio tiempo', '08:00', '13:00', 10, 0.00);

INSERT INTO planilla (nombre, descripcion) VALUES
('Planilla Administrativa', 'Personal administrativo y de oficina'),
('Planilla Operativa', 'Personal de producción, bodega y servicio'),
('Planilla Comercial', 'Personal de ventas y mercadeo');


INSERT INTO empleado (nombres, apellidos, dui, nit, numeroIsss, numeroNup, sexo, fechaNacimiento, telefono, correo, direccion,
                      idDepartamento, idCargo, idHorario, idPlanilla, fechaIngreso, salarioBase, estado)
VALUES
('Carlos Eduardo','Menjívar Rivas','05870761-4','1219-121775-625-3','366113609','779123746044','M','1978-03-14','2869-9953','carlos.menjivar@empresa.com.sv','Colonia Escalón, San Salvador',1,1,1,1,'2019-02-01',3200.00,'Activo'),
('Ana Patricia','Hernández López','03252646-4','1469-298616-651-5','266173260','443619421573','F','1990-07-22','7697-9060','ana.hernandez@empresa.com.sv','Colonia Escalón, San Salvador',1,2,1,1,'2021-05-10',620.00,'Activo'),
('Karla Beatriz','Orellana Cruz','02131326-4','1217-158439-485-9','240892401','761245766653','F','1998-11-05','7616-5762','karla.orellana@empresa.com.sv','Colonia Escalón, San Salvador',1,3,1,1,'2023-01-16',450.00,'Activo'),
('Roberto Antonio','Chávez Martínez','01708277-0','0955-275257-164-2','941210101','437524425296','M','1982-09-30','7521-7396','roberto.chavez@empresa.com.sv','Colonia Escalón, San Salvador',2,4,1,1,'2019-08-01',1650.00,'Activo'),
('María Fernanda','Portillo Gómez','02246012-9','1165-151562-386-0','213960451','156149968611','F','1993-04-18','6761-6790','maria.portillo@empresa.com.sv','Colonia Escalón, San Salvador',2,5,1,1,'2020-03-02',980.00,'Activo'),
('José Luis','Ramírez Aguilar','01216344-0','0152-233795-488-5','833144986','595225499138','M','1996-12-09','6224-9152','jose.ramirez@empresa.com.sv','Colonia Escalón, San Salvador',2,6,1,1,'2022-06-01',640.00,'Activo'),
('Sofía Alejandra','Quintanilla Mejía','04913980-4','1270-262163-825-2','265238756','673770100602','F','1985-06-27','2544-6511','sofia.quintanilla@empresa.com.sv','Colonia Escalón, San Salvador',3,7,1,1,'2020-01-13',1480.00,'Activo'),
('Daniel Ernesto','Flores Alvarado','04848838-1','1325-161165-695-1','687716833','136074104939','M','1997-02-11','2762-3840','daniel.flores@empresa.com.sv','Colonia Escalón, San Salvador',3,8,1,1,'2022-09-05',610.00,'Activo'),
('Gabriela Isabel','Escobar Salazar','01379472-3','1427-242807-954-0','585138951','932657128915','F','1989-10-03','7293-8927','gabriela.escobar@empresa.com.sv','Colonia Escalón, San Salvador',3,9,1,1,'2021-02-15',1250.00,'Activo'),
('Miguel Ángel','Guzmán Peña','01171713-1','0364-269253-543-3','943326434','670726706234','M','1984-01-25','2264-4047','miguel.guzman@empresa.com.sv','Colonia Escalón, San Salvador',4,10,5,3,'2019-11-04',1500.00,'Activo'),
('Lucía Carolina','Cáceres Vides','04271317-8','0658-211504-546-6','184459259','436653217611','F','1999-08-14','2452-3862','lucia.caceres@empresa.com.sv','Colonia Escalón, San Salvador',4,11,5,3,'2023-03-01',720.00,'Activo'),
('Andrés Josué','Bonilla Argueta','03209925-5','1050-230443-799-6','408883592','295282286164','M','1995-05-20','6631-8897','andres.bonilla@empresa.com.sv','Colonia Escalón, San Salvador',4,12,5,3,'2022-01-17',780.00,'Activo'),
('Fernando José','Mendoza Pineda','04729431-5','0345-238215-816-8','955462995','994529299931','M','1987-12-01','2968-4511','fernando.mendoza@empresa.com.sv','Colonia Escalón, San Salvador',5,13,1,1,'2020-07-01',2100.00,'Activo'),
('Valeria Nicole','Sandoval Cortez','02940577-2','0110-124410-900-7','793292768','548095837031','F','1996-03-08','7902-3989','valeria.sandoval@empresa.com.sv','Colonia Escalón, San Salvador',5,14,1,1,'2021-10-18',1350.00,'Activo'),
('Oscar Armando','Reyes Castillo','01228042-0','0820-141093-361-8','837829360','970041542062','M','1994-09-16','7321-2797','oscar.reyes@empresa.com.sv','Colonia Escalón, San Salvador',5,15,1,1,'2023-04-03',720.00,'Activo'),
('Wilfredo Antonio','Lara Bernal','03352771-4','1238-296934-582-3','711855694','719741018004','M','1980-07-07','6786-3172','wilfredo.lara@empresa.com.sv','Colonia Escalón, San Salvador',6,16,2,2,'2019-05-06',1100.00,'Activo'),
('Rosa Elena','Campos Henríquez','01851072-6','0640-125278-978-6','283905224','852074696809','F','1992-02-19','2877-6836','rosa.campos@empresa.com.sv','Colonia Escalón, San Salvador',6,17,2,2,'2022-02-14',520.00,'Activo'),
('Néstor Ariel','Villalta Ayala','02556046-5','1422-265173-109-8','436672727','745433881515','M','1991-11-23','2398-6154','nestor.villalta@empresa.com.sv','Colonia Escalón, San Salvador',7,19,4,2,'2021-08-02',760.00,'Activo'),
('Julio César','Alas Recinos','02353844-6','0634-167141-065-0','541997588','954290082848','M','1986-04-04','6524-1252','julio.alas@empresa.com.sv','Colonia Escalón, San Salvador',7,20,4,2,'2020-11-09',590.00,'Activo'),
('Diana Marisol','Ventura Torres','01480764-2','0297-161662-024-4','232092060','852022445999','F','2000-01-30','7690-6739','diana.ventura@empresa.com.sv','Colonia Escalón, San Salvador',8,23,3,2,DATEADD(DAY, 9, DATEADD(MONTH, -1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))),500.00,'Activo');
GO

-- Usuarios de demostración (el administrador se crea en la Configuración Inicial de la aplicación)
--   rrhh  / Rrhh123*  (Recursos Humanos)      respuesta de seguridad: azul
--   conta / Conta123* (Contador)              respuesta de seguridad: sansalvador
INSERT INTO usuario (idEmpleado, nombreUsuario, nombreCompleto, contrasena, correo, idRol, preguntaSeguridad, respuestaSeguridad, estado) VALUES
(4, 'rrhh', 'Roberto Antonio Chávez Martínez', '$2a$11$JmBeJIdePJ/tP418M9ny0.80LHQT9owQhqg9egsfe99S1s/lxMMZ2', 'roberto.chavez@empresa.com.sv', 2, '¿Cuál es su color favorito?', '$2a$11$bDbP22vJsZ3HkV3drabUuevYOalko4mGbjdBpY1dwgRrGekIg9Uv6', 'Activo'),
(7, 'conta', 'Sofía Alejandra Quintanilla Mejía', '$2a$11$wydrRWNfeczPeEfV/1hT.e5UGUQiFWzXCnuyTP13GrZSRAarkwRRm', 'sofia.quintanilla@empresa.com.sv', 3, '¿En qué ciudad nació?', '$2a$11$W02rOZuxtUlTGZKlwEjRDOlMkCPhTb5JUb/wxKdX2m3w3qMC2AX0W', 'Activo');
GO

-- Asistencia de demostración: lunes a viernes desde hace dos meses hasta ayer
DECLARE @dia DATE = DATEFROMPARTS(YEAR(DATEADD(MONTH, -2, GETDATE())), MONTH(DATEADD(MONTH, -2, GETDATE())), 1);
DECLARE @hasta DATE = DATEADD(DAY, -1, CAST(GETDATE() AS DATE));
DECLARE @idPre INT = (SELECT idTipoAsistencia FROM tipoAsistencia WHERE codigo = 'PRE');
DECLARE @idTar INT = (SELECT idTipoAsistencia FROM tipoAsistencia WHERE codigo = 'TAR');
DECLARE @idAus INT = (SELECT idTipoAsistencia FROM tipoAsistencia WHERE codigo = 'AUS');

WHILE @dia <= @hasta
BEGIN
    IF (DATEDIFF(DAY, '19000101', @dia) % 7) < 5      -- lunes a viernes
    BEGIN
        ;WITH base AS (
            SELECT e.idEmpleado, h.horaEntrada, h.horaSalida, h.horasDiarias, h.minutosTolerancia,
                   ABS(CHECKSUM(e.idEmpleado, @dia)) % 100 AS r
            FROM empleado e INNER JOIN horario h ON h.idHorario = e.idHorario
            WHERE e.fechaIngreso <= @dia
        )
        INSERT INTO asistencia (idEmpleado, fecha, idTipoAsistencia, horaEntrada, horaSalida, horasTrabajadas, minutosTarde, horasExtra)
        SELECT idEmpleado, @dia,
               CASE WHEN r BETWEEN 80 AND 89 THEN @idTar WHEN r BETWEEN 90 AND 92 THEN @idAus ELSE @idPre END,
               CASE WHEN r BETWEEN 90 AND 92 THEN NULL
                    WHEN r BETWEEN 80 AND 89 THEN DATEADD(MINUTE, minutosTolerancia + 5 + (r - 80) * 2, horaEntrada)
                    ELSE horaEntrada END,
               CASE WHEN r BETWEEN 90 AND 92 THEN NULL
                    WHEN r BETWEEN 93 AND 95 THEN DATEADD(HOUR, 1, horaSalida)
                    ELSE horaSalida END,
               CASE WHEN r BETWEEN 90 AND 92 THEN 0
                    WHEN r BETWEEN 93 AND 95 THEN horasDiarias + 1
                    WHEN r BETWEEN 80 AND 89 THEN horasDiarias - CONVERT(DECIMAL(5,2), (minutosTolerancia + 5 + (r - 80) * 2) / 60.0)
                    ELSE horasDiarias END,
               CASE WHEN r BETWEEN 80 AND 89 THEN minutosTolerancia + 5 + (r - 80) * 2 ELSE 0 END,
               CASE WHEN r BETWEEN 93 AND 95 THEN 1 ELSE 0 END
        FROM base;
    END
    SET @dia = DATEADD(DAY, 1, @dia);
END
GO

-- Permisos laborales de demostración (los aprobados se reflejan en la asistencia mediante el procedimiento almacenado)
INSERT INTO permisoLaboral (idEmpleado, tipo, fechaInicio, fechaFin, motivo) VALUES
(2, 'Con goce', DATEADD(DAY, -40, CAST(GETDATE() AS DATE)), DATEADD(DAY, -40, CAST(GETDATE() AS DATE)), 'Trámite personal en oficinas del DUI'),
(3, 'Vacaciones', DATEADD(DAY, -35, CAST(GETDATE() AS DATE)), DATEADD(DAY, -31, CAST(GETDATE() AS DATE)), 'Vacaciones anuales'),
(5, 'Incapacidad', DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), DATEADD(DAY, -28, CAST(GETDATE() AS DATE)), 'Incapacidad médica por cuadro gripal'),
(6, 'Sin goce', DATEADD(DAY, -28, CAST(GETDATE() AS DATE)), DATEADD(DAY, -27, CAST(GETDATE() AS DATE)), 'Asuntos familiares'),
(8, 'Con goce', DATEADD(DAY, -25, CAST(GETDATE() AS DATE)), DATEADD(DAY, -25, CAST(GETDATE() AS DATE)), 'Cita médica'),
(9, 'Vacaciones', DATEADD(DAY, -22, CAST(GETDATE() AS DATE)), DATEADD(DAY, -19, CAST(GETDATE() AS DATE)), 'Vacaciones'),
(11, 'Con goce', DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'Matrimonio de un familiar'),
(12, 'Sin goce', DATEADD(DAY, -18, CAST(GETDATE() AS DATE)), DATEADD(DAY, -16, CAST(GETDATE() AS DATE)), 'Viaje personal'),
(14, 'Incapacidad', DATEADD(DAY, -15, CAST(GETDATE() AS DATE)), DATEADD(DAY, -14, CAST(GETDATE() AS DATE)), 'Incapacidad por procedimiento dental'),
(15, 'Con goce', DATEADD(DAY, -12, CAST(GETDATE() AS DATE)), DATEADD(DAY, -12, CAST(GETDATE() AS DATE)), 'Reunión escolar'),
(17, 'Sin goce', DATEADD(DAY, -10, CAST(GETDATE() AS DATE)), DATEADD(DAY, -9, CAST(GETDATE() AS DATE)), 'Trámite migratorio'),
(18, 'Vacaciones', DATEADD(DAY, -8, CAST(GETDATE() AS DATE)), DATEADD(DAY, -6, CAST(GETDATE() AS DATE)), 'Vacaciones'),
(19, 'Con goce', DATEADD(DAY, -6, CAST(GETDATE() AS DATE)), DATEADD(DAY, -6, CAST(GETDATE() AS DATE)), 'Trámite bancario'),
(10, 'Vacaciones', DATEADD(DAY, 10, CAST(GETDATE() AS DATE)), DATEADD(DAY, 14, CAST(GETDATE() AS DATE)), 'Vacaciones de fin de año'),
(13, 'Con goce', DATEADD(DAY, 12, CAST(GETDATE() AS DATE)), DATEADD(DAY, 12, CAST(GETDATE() AS DATE)), 'Cita médica programada'),
(16, 'Sin goce', DATEADD(DAY, 15, CAST(GETDATE() AS DATE)), DATEADD(DAY, 16, CAST(GETDATE() AS DATE)), 'Asunto personal'),
(20, 'Con goce', DATEADD(DAY, 20, CAST(GETDATE() AS DATE)), DATEADD(DAY, 20, CAST(GETDATE() AS DATE)), 'Capacitación externa');
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 1, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 2, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 3, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 4, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 5, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 6, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 7, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 8, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 9, @idUsuario = 1;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 10, @idUsuario = 1;
UPDATE permisoLaboral SET estado = 'Rechazado', idUsuarioResuelve = 1, fechaResolucion = GETDATE() WHERE idPermisoLaboral = 11;
EXEC sp_AprobarPermisoLaboral @idPermisoLaboral = 12, @idUsuario = 1;
UPDATE permisoLaboral SET estado = 'Rechazado', idUsuarioResuelve = 1, fechaResolucion = GETDATE() WHERE idPermisoLaboral = 13;

INSERT INTO accionPersonal (idEmpleado, tipoAccion, fecha, descripcion, salarioNuevo, idDepartamentoNuevo, idCargoNuevo, fechaFin, estado, idUsuario) VALUES
(2, 'Aumento salarial', '2024-01-01', 'Aumento por evaluación de desempeño', 620.0, NULL, NULL, NULL, 'Aplicada', 1),
(5, 'Promoción', '2023-01-02', 'Promoción a Analista de Planillas', 980.0, 2, 5, NULL, 'Aplicada', 1),
(11, 'Aumento salarial', '2024-06-01', 'Aumento por cumplimiento de metas de venta', 720.0, NULL, NULL, NULL, 'Aplicada', 1),
(14, 'Aumento salarial', '2025-01-02', 'Aumento anual', 1350.0, NULL, NULL, NULL, 'Aplicada', 1),
(13, 'Promoción', '2022-01-03', 'Promoción a Jefe de Tecnología', 2100.0, 5, 13, NULL, 'Aplicada', 1),
(16, 'Traslado', '2021-03-01', 'Traslado desde Logística hacia Operaciones', 1100.0, 6, 16, NULL, 'Aplicada', 1),
(8, 'Aumento salarial', '2024-03-01', 'Aumento por desempeño', 610.0, NULL, NULL, NULL, 'Aplicada', 1),
(10, 'Aumento salarial', '2023-07-01', 'Aumento por resultados comerciales', 1500.0, NULL, NULL, NULL, 'Aplicada', 1),
(3, 'Amonestación', '2024-09-10', 'Llamado de atención verbal por tardanzas reiteradas', NULL, NULL, NULL, NULL, 'Aplicada', 1),
(12, 'Amonestación', '2025-02-12', 'Amonestación escrita por incumplimiento de entregables', NULL, NULL, NULL, NULL, 'Aplicada', 1),
(17, 'Suspensión', '2024-11-04', 'Suspensión de 3 días por falta grave', NULL, NULL, NULL, '2024-11-06', 'Aplicada', 1),
(19, 'Aumento salarial', '2025-03-01', 'Aumento por antigüedad', 590.0, NULL, NULL, NULL, 'Aplicada', 1),
(18, 'Aumento salarial', '2025-04-01', 'Aumento por desempeño', 760.0, NULL, NULL, NULL, 'Aplicada', 1),
(7, 'Aumento salarial', CAST(GETDATE() AS DATE), 'Ajuste por costo de vida', 1600.0, NULL, NULL, NULL, 'Pendiente', 1),
(15, 'Promoción', CAST(GETDATE() AS DATE), 'Promoción a Desarrollador de Software', 1000.0, 5, 14, NULL, 'Pendiente', 1);

DECLARE @anioPrev SMALLINT = YEAR(DATEADD(MONTH, -1, GETDATE()));
DECLARE @mesPrev TINYINT = MONTH(DATEADD(MONTH, -1, GETDATE()));
INSERT INTO planillaMovimiento (idEmpleado, idTipoMovimiento, anio, mes, monto, descripcion, idUsuario) VALUES
(10, 2, @anioPrev, @mesPrev, 350.00, 'Comisión por ventas del mes', 1),
(11, 2, @anioPrev, @mesPrev, 210.50, 'Comisión por ventas del mes', 1),
(12, 2, @anioPrev, @mesPrev, 180.00, 'Comisión por ventas del mes', 1),
(10, 1, @anioPrev, @mesPrev, 100.00, 'Bono por cumplimiento de metas', 1),
(5, 1, @anioPrev, @mesPrev, 75.00, 'Bono por desempeño', 1),
(13, 1, @anioPrev, @mesPrev, 150.00, 'Bono por entrega de proyecto', 1),
(14, 1, @anioPrev, @mesPrev, 100.00, 'Bono por desempeño', 1),
(2, 4, @anioPrev, @mesPrev, 40.00, 'Viáticos por gestiones bancarias', 1),
(16, 3, @anioPrev, @mesPrev, 60.00, 'Bonificación por turno extraordinario', 1),
(18, 3, @anioPrev, @mesPrev, 45.00, 'Bonificación por despacho urgente', 1),
(3, 5, @anioPrev, @mesPrev, 15.00, 'Descuento por uniforme', 1),
(6, 6, @anioPrev, @mesPrev, 100.00, 'Anticipo de salario', 1),
(8, 7, @anioPrev, @mesPrev, 5.00, 'Cuota sindical', 1),
(9, 8, @anioPrev, @mesPrev, 22.50, 'Seguro médico privado', 1),
(15, 6, @anioPrev, @mesPrev, 80.00, 'Anticipo de salario', 1),
(17, 5, @anioPrev, @mesPrev, 12.00, 'Descuento por uniforme', 1);

INSERT INTO prestamo (idEmpleado, monto, cuotaMensual, saldo, fechaOtorgado, descripcion) VALUES
(2, 600.00, 50.00, 400.00, DATEADD(DAY, -20, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo personal'),
(3, 300.00, 25.00, 175.00, DATEADD(DAY, -45, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo para útiles escolares'),
(5, 1000.00, 80.00, 640.00, DATEADD(DAY, -70, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo personal'),
(6, 500.00, 40.00, 300.00, DATEADD(DAY, -95, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo por emergencia médica'),
(8, 400.00, 35.00, 210.00, DATEADD(DAY, -120, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo personal'),
(9, 1500.00, 120.00, 900.00, DATEADD(DAY, -150, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo para vivienda'),
(11, 350.00, 30.00, 200.00, DATEADD(DAY, -30, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo personal'),
(12, 800.00, 65.00, 520.00, DATEADD(DAY, -60, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo para reparación de vehículo'),
(14, 1200.00, 100.00, 700.00, DATEADD(DAY, -110, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo personal'),
(15, 450.00, 40.00, 250.00, DATEADD(DAY, -25, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo por emergencia'),
(16, 900.00, 75.00, 525.00, DATEADD(DAY, -80, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo para vivienda'),
(17, 300.00, 25.00, 125.00, DATEADD(DAY, -140, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo personal'),
(18, 700.00, 60.00, 480.00, DATEADD(DAY, -35, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo personal'),
(19, 500.00, 40.00, 380.00, DATEADD(DAY, -15, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo por emergencia'),
(1, 3000.00, 250.00, 1750.00, DATEADD(DAY, -180, DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))), 'Préstamo para vehículo');

-- ---------- Datos de demostración adicionales (mínimo 15 registros por tabla) ----------
INSERT INTO departamento (nombre, descripcion) VALUES
('Legal', 'Asesoría jurídica y contratos'),
('Auditoría Interna', 'Control interno y cumplimiento'),
('Compras', 'Adquisiciones y proveedores'),
('Mantenimiento', 'Mantenimiento de instalaciones y equipo'),
('Seguridad Industrial', 'Prevención de riesgos y salud ocupacional'),
('Control de Calidad', 'Aseguramiento y control de calidad'),
('Capacitación', 'Formación y desarrollo del personal');
INSERT INTO cargo (idDepartamento, nombre, salarioMinimo, salarioMaximo) VALUES
(9, 'Asesor Legal', 1200.00, 2400.00),
(10, 'Auditor Interno', 1000.00, 2000.00),
(11, 'Encargado de Compras', 700.00, 1400.00),
(12, 'Técnico Electricista', 450.00, 900.00),
(13, 'Oficial de Seguridad', 500.00, 1000.00),
(14, 'Inspector de Calidad', 550.00, 1100.00),
(15, 'Instructor de Capacitación', 600.00, 1200.00);
INSERT INTO horario (nombre, horaEntrada, horaSalida, minutosTolerancia, horasAlmuerzo) VALUES
('Turno nocturno', '19:00', '23:30', 10, 0.50),
('Fin de semana', '08:00', '14:00', 10, 0.00),
('Seguridad matutino', '06:00', '14:00', 10, 0.50),
('Seguridad vespertino', '14:00', '22:00', 10, 0.50),
('Atención al cliente', '09:00', '18:00', 10, 1.00),
('Taller', '07:30', '16:30', 10, 1.00),
('Corrido sin almuerzo', '08:00', '16:00', 10, 0.00),
('Medio tiempo tarde', '13:00', '18:00', 10, 0.00),
('Flexible administrativo', '09:00', '18:00', 15, 1.00);
INSERT INTO planilla (nombre, descripcion) VALUES
('Planilla Gerencial', 'Cargos de dirección y gerencia'),
('Planilla de Seguridad', 'Personal de seguridad y vigilancia'),
('Planilla de Mantenimiento', 'Personal técnico de mantenimiento'),
('Planilla de Calidad', 'Control y aseguramiento de calidad'),
('Planilla Temporal', 'Personal contratado por período definido'),
('Planilla de Pasantes', 'Practicantes y pasantes'),
('Planilla de Proyectos', 'Personal asignado a proyectos'),
('Planilla de Bodega', 'Personal de bodega y despacho'),
('Planilla de Transporte', 'Motoristas y personal de transporte'),
('Planilla de Capacitación', 'Instructores y formadores'),
('Planilla de Compras', 'Personal de compras y proveedores'),
('Planilla Legal', 'Personal del área legal');
INSERT INTO rol (nombre, descripcion) VALUES
('Gerente', 'Consulta general y reportes'),
('Jefe de Recursos Humanos', 'Gestión completa del personal'),
('Auxiliar Contable', 'Apoyo en planilla y movimientos'),
('Supervisor', 'Consulta de personal y asistencia'),
('Consulta', 'Solo consulta de empleados'),
('Auditor', 'Consulta de planilla, reportes y bitácora'),
('Planillero', 'Genera planillas y boletas'),
('Recepcionista', 'Registro de asistencia'),
('Analista de Personal', 'Empleados y acciones de personal'),
('Secretaria', 'Permisos y asistencia'),
('Coordinador', 'Asistencia y permisos del equipo'),
('Soporte', 'Consulta de bitácora y usuarios');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 4, idPermisoSistema FROM permisoSistema WHERE codigo IN ('EMPLEADOS_VER', 'REPORTES_VER', 'PLANILLA_VER');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 5, idPermisoSistema FROM permisoSistema WHERE codigo IN ('DEPARTAMENTOS_VER', 'DEPARTAMENTOS_GESTIONAR', 'HORARIOS_VER', 'HORARIOS_GESTIONAR', 'EMPLEADOS_VER', 'EMPLEADOS_GESTIONAR', 'ASISTENCIA_VER', 'ASISTENCIA_GESTIONAR', 'PERMISOS_VER', 'PERMISOS_GESTIONAR', 'ACCIONES_VER', 'ACCIONES_GESTIONAR', 'REPORTES_VER');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 6, idPermisoSistema FROM permisoSistema WHERE codigo IN ('EMPLEADOS_VER', 'PLANILLA_VER', 'PLANILLA_GESTIONAR');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 7, idPermisoSistema FROM permisoSistema WHERE codigo IN ('EMPLEADOS_VER', 'ASISTENCIA_VER', 'PERMISOS_VER');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 8, idPermisoSistema FROM permisoSistema WHERE codigo IN ('EMPLEADOS_VER');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 9, idPermisoSistema FROM permisoSistema WHERE codigo IN ('PLANILLA_VER', 'REPORTES_VER', 'BITACORA_VER', 'EMPLEADOS_VER');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 10, idPermisoSistema FROM permisoSistema WHERE codigo IN ('PLANILLA_VER', 'PLANILLA_GESTIONAR', 'BOLETAS_VER');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 11, idPermisoSistema FROM permisoSistema WHERE codigo IN ('ASISTENCIA_VER', 'ASISTENCIA_GESTIONAR');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 12, idPermisoSistema FROM permisoSistema WHERE codigo IN ('EMPLEADOS_VER', 'EMPLEADOS_GESTIONAR', 'ACCIONES_VER', 'ACCIONES_GESTIONAR');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 13, idPermisoSistema FROM permisoSistema WHERE codigo IN ('PERMISOS_VER', 'PERMISOS_GESTIONAR', 'ASISTENCIA_VER');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 14, idPermisoSistema FROM permisoSistema WHERE codigo IN ('ASISTENCIA_VER', 'ASISTENCIA_GESTIONAR', 'PERMISOS_VER');
INSERT INTO rolPermiso (idRol, idPermisoSistema) SELECT 15, idPermisoSistema FROM permisoSistema WHERE codigo IN ('BITACORA_VER', 'USUARIOS_GESTIONAR');
-- Usuarios de demostración adicionales (contraseña Demo123*, respuesta de seguridad: demo)
INSERT INTO usuario (idEmpleado, nombreUsuario, nombreCompleto, contrasena, correo, idRol, preguntaSeguridad, respuestaSeguridad, estado) VALUES
(1, 'cmenjivar', 'Carlos Eduardo Menjívar Rivas', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'cmenjivar@empresa.com.sv', 4, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(2, 'ahernandez', 'Ana Patricia Hernández López', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'ahernandez@empresa.com.sv', 7, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(3, 'korellana', 'Karla Beatriz Orellana Cruz', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'korellana@empresa.com.sv', 11, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(5, 'mportillo', 'María Fernanda Portillo Gómez', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'mportillo@empresa.com.sv', 13, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(6, 'jramirez', 'José Luis Ramírez Aguilar', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'jramirez@empresa.com.sv', 14, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(8, 'dflores', 'Daniel Ernesto Flores Alvarado', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'dflores@empresa.com.sv', 8, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(9, 'gescobar', 'Gabriela Isabel Escobar Salazar', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'gescobar@empresa.com.sv', 6, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(10, 'mguzman', 'Miguel Ángel Guzmán Peña', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'mguzman@empresa.com.sv', 5, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(11, 'lcaceres', 'Lucía Carolina Cáceres Vides', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'lcaceres@empresa.com.sv', 8, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(12, 'abonilla', 'Andrés Josué Bonilla Argueta', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'abonilla@empresa.com.sv', 7, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(13, 'fmendoza', 'Fernando José Mendoza Pineda', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'fmendoza@empresa.com.sv', 15, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(14, 'vsandoval', 'Valeria Nicole Sandoval Cortez', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'vsandoval@empresa.com.sv', 9, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo'),
(15, 'oreyes', 'Oscar Armando Reyes Castillo', '$2a$11$d/rZzOgg2EvlpsZb/kuXoeHoDbYNG9gR0slAlYnANdzNH3yQkyCXW', 'oreyes@empresa.com.sv', 10, '¿Cuál es su comida favorita?', '$2a$11$JNzVi0y.X7YSCXmRVOW5zu/rvQOA8e5koy1xJaEYMhgFXFGz1hf2e', 'Activo');
INSERT INTO tipoAsistencia (codigo, nombre, descripcion, descuentaDia, requiereHoras) VALUES
('FER', 'Feriado / asueto', 'Día feriado pagado', 0, 0),
('TEL', 'Teletrabajo', 'Jornada realizada en modalidad remota', 0, 1),
('MIS', 'Misión oficial', 'Trabajo fuera de la oficina', 0, 0),
('CAP', 'Capacitación', 'Asistencia a capacitación', 0, 1),
('LMA', 'Licencia de maternidad', 'Licencia por maternidad', 0, 0),
('LPA', 'Licencia de paternidad', 'Licencia por paternidad', 0, 0),
('DUE', 'Permiso por duelo', 'Fallecimiento de un familiar', 0, 0),
('DCO', 'Descanso compensatorio', 'Descanso por trabajo en día de asueto', 0, 0);
INSERT INTO tipoMovimiento (nombre, naturaleza, gravable) VALUES
('Aguinaldo', 'Ingreso', 0),
('Bono de transporte', 'Ingreso', 1),
('Subsidio de alimentación', 'Ingreso', 0),
('Pensión alimenticia', 'Deducción', 1),
('Préstamo bancario (libranza)', 'Deducción', 1),
('Seguro de vida', 'Deducción', 1),
('Ajuste a favor de la empresa', 'Deducción', 1),
('Reintegro de gastos', 'Ingreso', 0),
('Bono de antigüedad', 'Ingreso', 1);
INSERT INTO parametroLey (codigo, descripcion, valor) VALUES
('INSAFORP_PATRONAL', '(Informativo) INSAFORP - aporte patronal', 0.01),
('DIAS_VACACIONES', '(Informativo) Días de vacaciones anuales', 15),
('RECARGO_VACACIONES', '(Informativo) Recargo sobre el salario de vacaciones', 0.3),
('HORAS_SEMANA', '(Informativo) Horas de la jornada semanal diurna', 44),
('LIMITE_CUOTA_PRESTAMO', '(Informativo) Porcentaje máximo del salario para cuotas de préstamo', 0.2),
('EDAD_MINIMA', '(Informativo) Edad mínima para laborar', 18),
('EDAD_MAXIMA', '(Informativo) Edad máxima registrada en el sistema', 75),
('MESES_AGUINALDO', '(Informativo) Meses de antigüedad para el primer aguinaldo', 12);
INSERT INTO historialSalario (idEmpleado, salarioAnterior, salarioNuevo, fecha, usuarioBd) VALUES
(2, 560.00, 620.00, '2024-01-01', 'sistema'),
(5, 900.00, 980.00, '2023-01-02', 'sistema'),
(11, 650.00, 720.00, '2024-06-01', 'sistema'),
(14, 1250.00, 1350.00, '2025-01-02', 'sistema'),
(13, 1900.00, 2100.00, '2022-01-03', 'sistema'),
(16, 950.00, 1100.00, '2021-03-01', 'sistema'),
(8, 560.00, 610.00, '2024-03-01', 'sistema'),
(10, 1350.00, 1500.00, '2023-07-01', 'sistema'),
(19, 540.00, 590.00, '2025-03-01', 'sistema'),
(18, 700.00, 760.00, '2025-04-01', 'sistema'),
(1, 2900.00, 3200.00, '2023-01-01', 'sistema'),
(4, 1500.00, 1650.00, '2022-01-01', 'sistema'),
(7, 1350.00, 1480.00, '2022-06-01', 'sistema'),
(9, 1100.00, 1250.00, '2023-03-01', 'sistema'),
(12, 720.00, 780.00, '2023-05-01', 'sistema');
INSERT INTO bitacora (nivel, nombreUsuario, modulo, mensaje, fecha) VALUES
('INFO', 'demo', 'Login', 'Inicio de sesión correcto', DATEADD(HOUR, -5, GETDATE())),
('INFO', 'demo', 'Empleados', 'Registro creado', DATEADD(HOUR, -10, GETDATE())),
('INFO', 'demo', 'Empleados', 'Registro actualizado', DATEADD(HOUR, -15, GETDATE())),
('INFO', 'demo', 'Asistencia', 'Registro creado', DATEADD(HOUR, -20, GETDATE())),
('INFO', 'demo', 'Permisos', 'Permiso aprobado', DATEADD(HOUR, -25, GETDATE())),
('INFO', 'demo', 'Acciones personales', 'Acción de personal aplicada', DATEADD(HOUR, -30, GETDATE())),
('ADVERTENCIA', 'demo', 'Login', 'Intento fallido para el usuario ''prueba''', DATEADD(HOUR, -35, GETDATE())),
('INFO', 'demo', 'Planilla mensual', 'Planilla generada', DATEADD(HOUR, -40, GETDATE())),
('INFO', 'demo', 'Planilla mensual', 'Planilla cerrada', DATEADD(HOUR, -45, GETDATE())),
('INFO', 'demo', 'Boletas', 'Boleta generada', DATEADD(HOUR, -50, GETDATE())),
('INFO', 'demo', 'Reportes', 'Reporte exportado a PDF', DATEADD(HOUR, -55, GETDATE())),
('INFO', 'demo', 'Reportes', 'Reporte exportado a Excel', DATEADD(HOUR, -60, GETDATE())),
('ERROR', 'demo', 'Conexión', '[ERR-SQL-001] No se pudo conectar con el servidor', DATEADD(HOUR, -65, GETDATE())),
('INFO', 'demo', 'Usuarios', 'Clave temporal generada', DATEADD(HOUR, -70, GETDATE())),
('INFO', 'demo', 'Login', 'Cierre de sesión', DATEADD(HOUR, -75, GETDATE()));

GO
