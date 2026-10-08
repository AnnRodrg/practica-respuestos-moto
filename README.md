# RepuestosMoto — solución base C# / SQL Server

Solución de inicio para **.NET 10 / ASP.NET Core MVC / EF Core 10**. Derivada del archivo `RepuestosMotoDB_Integrado_01_04.sql` (42 tablas).

## Estructura
- `RepuestosMoto.Domain`: 42 entidades POCO, sin dependencia de EF Core.
- `RepuestosMoto.Application`: interfaces genéricas de repositorio y unidad de trabajo.
- `RepuestosMoto.Infrastructure`: `DbContext`, mapeos, repositorios EF Core y DI.
- `RepuestosMoto.Web`: MVC con una página de ejemplo de productos activos (solo lectura).

## Abrir en Visual Studio
1. Extraer el ZIP. Abrir `RepuestosMoto.slnx` en Visual Studio 2026.
2. Restaurar paquetes NuGet (requiere conexión a Internet) y compilar la solución.
3. Verificar que `RepuestosMotoDB` existe en `DESKTOP-T8OEG02\SQLEXPRESS`.
4. En la terminal de Visual Studio, antes de iniciar el proyecto web:

```powershell
$env:REPUESTOSMOTO_CONNECTION = "Server=.\SQLEXPRESS;Database=RepuestosMotoDB;Integrated Security=True;TrustServerCertificate=True;"
dotnet run --project .\RepuestosMoto.Web
```

5. Abrir la URL que aparece en la terminal. Si ejecutas desde el botón de Visual Studio, define la variable en el entorno que inicia Visual Studio o utiliza secretos de usuario / `appsettings.Development.json` **no versionado**.

## Advertencias y siguientes pasos
- Este proyecto **no crea ni modifica** el esquema SQL; se conecta al existente.
- Los repositorios de escritura están disponibles como infraestructura, **pero no hay endpoints de escritura** hasta agregar autenticación, permisos y reglas transaccionales.
- No exponer entidades como `Usuario`, `RecuperacionPassword`, `Auditoria` o campos `PasswordHash` en APIs públicas.
- Compras, ventas, inventario y caja requieren servicios de aplicación transaccionales; no deben ejecutarse mediante CRUD simple.
- Verificar el modelo contra el esquema real de SQL Server; si tu BD difiere del SQL integrado, actualizar las entidades y los mapeos.
- El proyecto fue generado estáticamente. No se compiló aquí porque `dotnet` no está disponible en este entorno.
