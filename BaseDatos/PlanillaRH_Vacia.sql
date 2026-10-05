-- =====================================================================
-- SISTEMA DE PLANILLA Y RECURSOS HUMANOS  (PlanillaRH) - BASE DE DATOS LIMPIA PARA UNA EMPRESA NUEVA
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
--   6. Solo los datos indispensables (roles, permisos, parámetros de ley, tipos de asistencia); sin empleados ni usuarios
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
-- 6. DATOS INDISPENSABLES (la empresa y el primer administrador se registran en la Configuración Inicial)
-- =====================================================================

-- ---------------------------------------------------------------------
-- 6.1  Configuración, roles y permisos
-- ---------------------------------------------------------------------
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

-- ---------------------------------------------------------------------
-- 6.2  Parámetros de ley y retención de renta (editables desde la aplicación)
-- ---------------------------------------------------------------------
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

INSERT INTO tramoRenta (nombre, desde, hasta, porcentaje, excesoSobre, cuotaFija) VALUES
('Tramo I',   0.01,    550.00,  0, 0.00,    0.00),
('Tramo II',  550.01,  895.24, 10, 550.00,  17.67),
('Tramo III', 895.25, 2038.10, 20, 895.24,  60.00),
('Tramo IV', 2038.11, 99999999.99, 30, 2038.10, 288.57);

-- ---------------------------------------------------------------------
-- 6.3  Tipos de asistencia (los usan los procedimientos almacenados)
-- ---------------------------------------------------------------------
INSERT INTO tipoAsistencia (codigo, nombre, descripcion, descuentaDia, requiereHoras) VALUES
('PRE', 'Presente', 'Asistió y cumplió su jornada', 0, 1),
('TAR', 'Tardanza', 'Llegó después de la tolerancia del horario', 0, 1),
('AUS', 'Ausencia injustificada', 'No se presentó y no tiene permiso; se descuenta el día', 1, 0),
('PCG', 'Permiso con goce de sueldo', 'Permiso aprobado sin descuento', 0, 0),
('PSG', 'Permiso sin goce de sueldo', 'Permiso aprobado con descuento del día', 1, 0),
('INC', 'Incapacidad', 'Incapacidad médica comprobada', 0, 0),
('VAC', 'Vacaciones', 'Día de vacaciones aprobado', 0, 0);
GO
