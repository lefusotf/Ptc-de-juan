# Instalador de PlanillaRH con Setup Project (Visual Studio)

Un `.vdproj` solo lo puede crear y compilar Visual Studio en Windows, por eso se
arma con estos pasos (≈5 minutos).

## 1. Instalar la extensión (una sola vez)
Visual Studio 2022 → **Extensiones → Administrar extensiones** → buscar
**"Microsoft Visual Studio Installer Projects 2022"** → Descargar → cerrar VS
para que se instale → volver a abrirlo.

## 2. Compilar la app en Release
Abrir `PlanillaRH.sln` → configuración **Release** → **Compilar → Compilar solución**.

## 3. Agregar el Setup Project
1. Clic derecho en la solución → **Agregar → Nuevo proyecto** → **Setup Project** → nombre `PlanillaRH.Setup`.
2. Clic derecho en el proyecto → **Propiedades** (ventana F4):
   - `ProductName` = PlanillaRH
   - `Manufacturer` = Instituto Técnico Ricaldone
   - `Title` = PlanillaRH – Planilla y Recursos Humanos
   - `Version` = 1.0.0
   - `InstallAllUsers` = True
3. **File System Editor** → clic derecho en *Application Folder* → **Add → Project Output…**
   → Proyecto `Vista` → **Primary output** → Aceptar.
   Las dependencias (`Modelos.dll`, `BCrypt.Net-Next.dll`, etc.) se agregan solas.
   > Si no aparecen: Add → Assembly… y elegir los `.dll` desde `Vista\bin\Release\net48\`.
   > Agregar también `PlanillaRH.exe.config` (Add → File…).
4. Accesos directos:
   - Clic derecho en *Primary output from Vista* → **Create Shortcut to…** →
     moverlo a *User's Desktop* y a *User's Programs Menu*; renombrar a **PlanillaRH**.
   - En cada acceso directo, propiedad **Icon** → Browse → `Vista\app.ico`.
5. Icono en "Agregar o quitar programas": propiedad `AddRemoveProgramsIcon` del proyecto → `app.ico`.
6. Requisito previo: clic derecho en el proyecto → **Properties → Prerequisites…**
   → marcar **.NET Framework 4.8** (o 4.8 Full) y "Download prerequisites from the same location".

## 4. Generar
Configuración **Release** → clic derecho en `PlanillaRH.Setup` → **Build**.
Salen `Release\setup.exe` y `PlanillaRH.Setup.msi`. Entregar ambos (y la carpeta completa).

## 5. Requisitos en el equipo del usuario
- SQL Server (Express, LocalDB o completo) instalado **aparte**: el instalador no lo incluye.
- Al abrir PlanillaRH por primera vez aparece el formulario de conexión, donde se escribe el
  servidor (ej. `.\SQLEXPRESS`) y se crea la base de datos automáticamente
  (el script va embebido en el programa).
