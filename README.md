# RepuestosMoto

Sistema de gestión para repuestos y ventas de motocicletas, desarrollado en .NET con una arquitectura en capas y acceso a datos basado en Entity Framework Core y SQL Server.

## 1. Descripción general

La solución está organizada en proyectos claramente separados por responsabilidad:

- `RepuestosMoto.Web`: capa de presentación, basada en ASP.NET Core MVC y Razor Views.
- `RepuestosMoto.Application`: contratos y abstracciones de la lógica de aplicación.
- `RepuestosMoto.Domain`: entidades del negocio y modelo de dominio.
- `RepuestosMoto.Infrastructure`: implementación del acceso a datos, inyección de dependencias y persistencia con Entity Framework Core.
- `RepuestosMoto.AdminSetup`: herramienta de consola para crear el usuario administrador inicial del sistema.

El objetivo de la solución es proporcionar una base sólida para la administración de inventario, ventas, compras, clientes, proveedores, caja, usuarios y permisos en un entorno de taller o negocio de repuestos para motos.

## 2. Arquitectura del sistema

La solución sigue un enfoque de arquitectura en capas con separación de responsabilidades:

- Capa de dominio (`RepuestosMoto.Domain`): define las entidades del negocio, como `Producto`, `Cliente`, `Proveedor`, `Venta`, `Compra`, `Categoria`, `Usuario`, entre otras.
- Capa de aplicación (`RepuestosMoto.Application`): expone contratos reutilizables para la persistencia (`IRepository<TEntity>` y `IUnitOfWork`).
- Capa de infraestructura (`RepuestosMoto.Infrastructure`): implementa el repositorio genérico y el contexto de EF Core.
- Capa web (`RepuestosMoto.Web`): gestiona las vistas, los controladores y la configuración del host de la aplicación.

## 3. Flujo de información

El flujo principal del sistema se puede describir de la siguiente manera:

1. Inicio de la aplicación
   - `RepuestosMoto.Web/Program.cs` inicializa la aplicación ASP.NET Core.
   - Se registran los servicios MVC y la infraestructura con `builder.Services.AddControllersWithViews();` y `builder.Services.AddInfrastructure(builder.Configuration);`.

2. Configuración de conexión a datos
   - La configuración de conexión se obtiene desde `appsettings.json`.
   - El valor configurado es:
     - `Server=.\SQLEXPRESS;Database=RepuestosMotoDB;Integrated Security=True;TrustServerCertificate=True;`
   - La infraestructura intenta leer esta cadena desde `ConnectionStrings:RepuestosMotoDB` y, si no existe, usa la variable de entorno `REPUESTOSMOTO_CONNECTION`.

3. Registro de dependencias
   - En `RepuestosMoto.Infrastructure/DependencyInjection.cs`, se registra el `DbContext` y los servicios de acceso a datos:
     - `AddDbContext<RepuestosMotoDbContext>(...)`
     - `AddScoped(typeof(IRepository<>), typeof(EfRepository<>));`
     - `AddScoped<IUnitOfWork, UnitOfWork>();`
   - Esto permite que los controladores consuman repositorios genéricos sin acoplarse directamente a la infraestructura.

4. Petición HTTP desde el cliente
   - El usuario accede a la vista de autenticación o al inicio de la aplicación.
   - La ruta por defecto se define en `Program.cs` como:
     - `{controller=Home}/{action=Index}/{id?}`
   - La vista de login se gestiona mediante `AccesoController` y la vista `Views/Acceso/Login.cshtml`.

5. Carga de datos desde la capa de aplicación
   - El controlador `HomeController` recibe la solicitud y usa `IRepository<Producto>`.
   - La acción `Index` ejecuta la consulta:
     - `products.FindAsync(p => p.Activo, ct)`
   - Esto produce una búsqueda filtrada por productos activos en la base de datos.

6. Persistencia con Entity Framework Core
   - `EfRepository<TEntity>` implementa las operaciones CRUD y consultas usando `DbSet<TEntity>`.
   - Ejemplo:
     - `GetByIdAsync`, `ListAsync`, `FindAsync`, `AddAsync`, `Update`, `Remove`.
   - La consulta usa `AsNoTracking()` para evitar seguimiento innecesario de entidades y optimizar la lectura.

7. Respuesta al usuario
   - Los resultados se proyectan a un modelo de vista (`ProductoListado`) y se envían a la Razor View.
   - La vista renderiza la información para el usuario final, mostrando el catálogo disponible de productos.

## 4. Modelo de dominio

Las entidades del dominio representan los principales procesos del negocio, entre otros:

- `Producto`
- `Categoria`
- `Subcategoria`
- `Cliente`
- `Proveedor`
- `Venta` y `VentaDetalle`
- `Compra` y `CompraDetalle`
- `Caja`, `AperturaCaja`, `CierreCaja`, `MovimientoCaja`
- `Usuario`, `Rol`, `Permiso`, `UsuarioRol`
- `InventarioExistencia`, `MovimientoInventario`, `AjusteInventario`
- `CuentaPorCobrar`, `CuentaPorPagar`, `PagoVenta`, `PagoProveedor`

La entidad `Producto` es un ejemplo representativo del dominio y expone propiedades como:

- `ProductoId`
- `SubcategoriaId`
- `Codigo`
- `Nombre`
- `PrecioVenta`
- `Activo`
- `CreadoEn`
- `ActualizadoEn`

Esto permite modelar de forma clara la estructura operativa del sistema de repuestos y ventas.

## 5. Tecnologías y versiones

La solución utiliza las siguientes tecnologías principales:

- .NET: `net10.0`
- ASP.NET Core: `10.0.0` (aplicación web MVC)
- C#: lenguaje principal del proyecto
- Entity Framework Core: `10.0.0`
- Entity Framework Core SQL Server: `10.0.0`
- Entity Framework Core Design: `10.0.0`
- SQL Server: Express local (`SQLEXPRESS`)
- Microsoft.Data.SqlClient: `7.1.1`
- Microsoft.Extensions.Identity.Core: `10.0.12`
- HTML/CSS/Razor Views para la interfaz de usuario

### Información técnica por proyecto

- `RepuestosMoto.Web.csproj`
  - `TargetFramework`: `net10.0`
  - Referencia a `RepuestosMoto.Infrastructure`
  - Configuración de MVC Web para ASP.NET Core

- `RepuestosMoto.Infrastructure.csproj`
  - `TargetFramework`: `net10.0`
  - Referencia a `RepuestosMoto.Application`
  - Paquetes:
    - `Microsoft.EntityFrameworkCore.SqlServer` `10.0.0`
    - `Microsoft.EntityFrameworkCore.Design` `10.0.0`

- `RepuestosMoto.Application.csproj`
  - `TargetFramework`: `net10.0`
  - Capa de abstracciones y contratos de aplicación

- `RepuestosMoto.Domain.csproj`
  - `TargetFramework`: `net10.0`
  - Entidades del dominio

- `RepuestosMoto.AdminSetup.csproj`
  - `TargetFramework`: `net10.0`
  - `Microsoft.Data.SqlClient` `7.1.1`
  - `Microsoft.Extensions.Identity.Core` `10.0.12`

## 6. Seguridad y administración

La solución incluye una utilidad de consola para crear un usuario administrador inicial de forma segura:

- `RepuestosMoto.AdminSetup/Program.cs`
- Se usa `PasswordHasher<string>` para generar un hash seguro.
- Se valida la contraseña con requisitos de complejidad (longitud mínima, mayúsculas, minúsculas, número y símbolo).
- Se crea el usuario `admin` y se asigna el rol `Administrador`.
- La ejecución requiere:
  - `REPUESTOSMOTO_CONNECTION`
  - `REPUESTOSMOTO_ADMIN_PASSWORD`

Esto garantiza un procedimiento inicial de configuración más seguro y controlado.

## 7. Requisitos para ejecutar el proyecto

- .NET SDK 10.0 o compatible
- SQL Server Express o una instancia SQL Server accesible
- Conexión configurada en `appsettings.json` o mediante variable de entorno
- Acceso a la base de datos `RepuestosMotoDB`

## 8. Estado actual del avance

El proyecto ya cuenta con la base de su arquitectura funcional:

- estructura por capas bien definida
- dominio modelado con entidades del negocio
- abstracciones de repositorio y unidad de trabajo
- infraestructura de persistencia con EF Core
- configuración de conexión SQL Server
- aplicación web con MVC y vistas Razor
- página de login visual y flujo inicial de autenticación
- utilidad para creación del usuario administrador

## 9. Conclusión

El sistema se encuentra en una etapa sólida de base arquitectónica y funcional, con una separación clara entre dominio, aplicación, infraestructura y presentación. El diseño permite escalar la solución, agregar nuevas funcionalidades y mantener una estructura ordenada conforme se desarrollen módulos como ventas, inventario, compras, caja y reportes.

Este avance establece una base profesional para continuar con la implementación de casos de uso del negocio y la integración completa de la capa de negocio con la base de datos.

---

Proyecto: `AnnRodrg/practica-respuestos-moto`

