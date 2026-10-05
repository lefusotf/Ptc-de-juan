# PlanillaRH - Sistema de Planilla y Recursos Humanos (C# + SQL Server)

1. Abra `PlanillaRH.sln` en Visual Studio 2022 (Desarrollo de escritorio con .NET) y establezca **Vista** como proyecto de inicio.
2. F5. En el formulario de conexión indique el servidor, pruebe la conexión y presione **Crear base de datos**
   (o ejecute `BaseDatos/PlanillaRH.sql` en SSMS).
3. Complete la configuración inicial (empresa y primer administrador).
4. Usuarios de demostración: `rrhh` / `Rrhh123*` y `conta` / `Conta123*`.

Los parámetros de ley (ISSS, AFP, renta, salario mínimo) están en Configuración y deben verificarse antes de usar planillas reales.
El manual de usuario se coloca en `Vista/Ayuda/ManualUsuario.html` (F1).

## Diseño visual de los mantenimientos

Las pantallas de mantenimiento (Empleados, Departamentos, Cargos, Horarios, Asistencia, Permisos, Acciones, Movimientos,
Préstamos, Tipos de asistencia, Tipos de movimiento, Planillas y Usuarios) heredan de `Vista/Comun/frmMantenimiento`.
Cada campo es un control real dentro del diseñador de Visual Studio: una celda `celX` con su etiqueta `lblX` y su control
`txtX` / `cmbX` / `dtpX` / `chkX`. Se pueden mover, cambiar de tamaño, de fuente o de color sin ejecutar el programa
(abra, por ejemplo, `frmEmpleados` con doble clic y use *Compilar → Recompilar solución* si el diseñador lo pide).

* La **apariencia** (posición, tamaño, fuente, color y texto de la etiqueta) es la del diseñador.
* El **comportamiento** (validación de caracteres, máscaras, datos de los combos, mensajes) sigue en `DefinirCampos()`
  de cada formulario. Si agrega un campo nuevo, agréguelo en `DefinirCampos()` y, si quiere dibujarlo, cree la celda
  con los nombres `celX`, `lblX` y `txtX/cmbX/dtpX/chkX` (si no existe, el sistema la crea sola al abrir la pantalla).
* En el diseñador los campos se ven en una columna; al ejecutar se acomodan en una o dos columnas según el ancho.
