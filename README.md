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

## Planillas: mensual, quincenal y aguinaldo

Cada tipo de planilla (menú *Planilla*) tiene una **periodicidad**:

* **Mensual:** se paga el mes completo (base de 30 días). Se pagan los *días efectivos*: los días del período menos los que descuentan (ausencia injustificada o permiso sin goce).
* **Quincenal:** se genera por quincena (1.ª: del 1 al 15; 2.ª: del 16 al fin de mes). Base de 15 días, topes de ISSS y AFP a la mitad y tabla de renta quincenal (la mensual dividida entre 2). Los bonos, anticipos y descuentos del mes se pagan en la 2.ª quincena; la cuota de cada préstamo se divide entre las dos.
* **Anual (aguinaldo):** incluye a todos los empleados activos y solo puede generarse del **1 de octubre al 20 de diciembre**. Días de salario según la antigüedad al 12 de diciembre (menos de 1 año: proporcional a 10 días; 1 a menos de 3 años: 10; 3 a menos de 10: 15; 10 o más: 18). No lleva ISSS ni AFP y la renta solo grava lo que pase de 2 salarios mínimos.

La **boleta de pago** muestra los días del período, los días efectivos pagados, los ingresos extra (bonos, comisiones, viáticos), los anticipos y descuentos del período, los préstamos con su cuota y saldo, y la deuda total pendiente.

## Crear la base de datos desde la aplicación

Al presionar **Crear base de datos** en el formulario de conexión, el sistema crea la base **limpia** (script `PlanillaRH_Vacia.sql`: tablas, vistas, procedimientos y triggers, más roles, permisos, parámetros de ley, tipos de asistencia, horarios, planillas y tipos de movimiento; sin empleados ni departamentos). Para probar el sistema marque **Incluir datos de demostración** y se cargará `PlanillaRH.sql` (empleados, asistencia, préstamos y planillas de ejemplo).
