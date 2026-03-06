# LoginCompositeWinForms (WinForms .NET Framework 4.8)

Proyecto de ejemplo en C# WinForms con:
- Login de usuario (2 usuarios demo)
- Permisos usando **Composite** (Familia/Patente)
- Menú que se habilita/oculta según permisos (ToolStripMenuItem.Tag)

## Usuarios demo
- **Guido / 1234**  -> Rol ADMIN (USUARIOS + VENTAS)
- **Moor / 1234**   -> Rol VENDEDOR (solo VENTAS)

## Cómo probar
1. Abrí `LoginCompositeWinForms.sln` en Visual Studio
2. F5
3. Probá loguear con Guido y con Moor para ver cómo cambia el menú.

## Dónde están los permisos
- `Domain/Patente.cs` (leaf)
- `Domain/Familia.cs` (composite)
- `Data/UserRepository.cs` (seed de usuarios + roles)
- `Security/PermisoService.cs` (aplica permisos al menú leyendo el Tag)

## Siguiente paso (si querés DB SQL Server)
Podemos reemplazar `UserRepository` por un repositorio real con tu tabla `Usuario`,
y guardar roles/permisos en tablas normalizadas.
