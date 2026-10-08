using Microsoft.EntityFrameworkCore;
using RepuestosMoto.Domain.Entities;

namespace RepuestosMoto.Infrastructure.Persistence;

public sealed class RepuestosMotoDbContext(DbContextOptions<RepuestosMotoDbContext> options) : DbContext(options)
{
    public DbSet<Sucursal> Sucursal => Set<Sucursal>();
    public DbSet<Almacen> Almacen => Set<Almacen>();
    public DbSet<Empleado> Empleado => Set<Empleado>();
    public DbSet<Rol> Rol => Set<Rol>();
    public DbSet<Permiso> Permiso => Set<Permiso>();
    public DbSet<RolPermiso> RolPermiso => Set<RolPermiso>();
    public DbSet<Usuario> Usuario => Set<Usuario>();
    public DbSet<UsuarioRol> UsuarioRol => Set<UsuarioRol>();
    public DbSet<RecuperacionPassword> RecuperacionPassword => Set<RecuperacionPassword>();
    public DbSet<ConfiguracionSistema> ConfiguracionSistema => Set<ConfiguracionSistema>();
    public DbSet<Categoria> Categoria => Set<Categoria>();
    public DbSet<Subcategoria> Subcategoria => Set<Subcategoria>();
    public DbSet<Producto> Producto => Set<Producto>();
    public DbSet<ProductoSucursal> ProductoSucursal => Set<ProductoSucursal>();
    public DbSet<Cliente> Cliente => Set<Cliente>();
    public DbSet<Proveedor> Proveedor => Set<Proveedor>();
    public DbSet<Compra> Compra => Set<Compra>();
    public DbSet<CompraDetalle> CompraDetalle => Set<CompraDetalle>();
    public DbSet<CuentaPorPagar> CuentaPorPagar => Set<CuentaPorPagar>();
    public DbSet<PagoProveedor> PagoProveedor => Set<PagoProveedor>();
    public DbSet<Cotizacion> Cotizacion => Set<Cotizacion>();
    public DbSet<CotizacionDetalle> CotizacionDetalle => Set<CotizacionDetalle>();
    public DbSet<Venta> Venta => Set<Venta>();
    public DbSet<VentaDetalle> VentaDetalle => Set<VentaDetalle>();
    public DbSet<PagoVenta> PagoVenta => Set<PagoVenta>();
    public DbSet<CuentaPorCobrar> CuentaPorCobrar => Set<CuentaPorCobrar>();
    public DbSet<AbonoCliente> AbonoCliente => Set<AbonoCliente>();
    public DbSet<DevolucionVenta> DevolucionVenta => Set<DevolucionVenta>();
    public DbSet<DevolucionVentaDetalle> DevolucionVentaDetalle => Set<DevolucionVentaDetalle>();
    public DbSet<InventarioExistencia> InventarioExistencia => Set<InventarioExistencia>();
    public DbSet<MovimientoInventario> MovimientoInventario => Set<MovimientoInventario>();
    public DbSet<AjusteInventario> AjusteInventario => Set<AjusteInventario>();
    public DbSet<AjusteInventarioDetalle> AjusteInventarioDetalle => Set<AjusteInventarioDetalle>();
    public DbSet<Transferencia> Transferencia => Set<Transferencia>();
    public DbSet<TransferenciaDetalle> TransferenciaDetalle => Set<TransferenciaDetalle>();
    public DbSet<Caja> Caja => Set<Caja>();
    public DbSet<AperturaCaja> AperturaCaja => Set<AperturaCaja>();
    public DbSet<MovimientoCaja> MovimientoCaja => Set<MovimientoCaja>();
    public DbSet<CierreCaja> CierreCaja => Set<CierreCaja>();
    public DbSet<CategoriaGasto> CategoriaGasto => Set<CategoriaGasto>();
    public DbSet<Gasto> Gasto => Set<Gasto>();
    public DbSet<Auditoria> Auditoria => Set<Auditoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.ToTable("Sucursal", "dbo");
            entity.HasKey(e => e.SucursalId);
            entity.Property(e => e.SucursalId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.Codigo).HasColumnType("varchar(20)");
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(120)");
            entity.Property(e => e.Direccion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.Telefono).HasColumnType("varchar(25)");
            entity.Property(e => e.Correo).HasColumnType("varchar(150)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)");
            entity.HasIndex(e => new { e.Codigo }).IsUnique();
        });

        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.ToTable("Almacen", "dbo");
            entity.HasKey(e => e.AlmacenId);
            entity.Property(e => e.AlmacenId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.Codigo).HasColumnType("varchar(20)");
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(120)");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)");
            entity.HasIndex(e => new { e.SucursalId, e.AlmacenId }).IsUnique();
            entity.HasIndex(e => new { e.SucursalId, e.Codigo }).IsUnique();
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.ToTable("Empleado", "dbo");
            entity.HasKey(e => e.EmpleadoId);
            entity.Property(e => e.EmpleadoId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.CodigoEmpleado).HasColumnType("varchar(30)");
            entity.Property(e => e.Nombres).HasColumnType("nvarchar(100)");
            entity.Property(e => e.Apellidos).HasColumnType("nvarchar(100)");
            entity.Property(e => e.TipoDocumento).HasColumnType("varchar(20)");
            entity.Property(e => e.NumeroDocumento).HasColumnType("varchar(40)");
            entity.Property(e => e.Telefono).HasColumnType("varchar(25)");
            entity.Property(e => e.Correo).HasColumnType("varchar(150)");
            entity.Property(e => e.Direccion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.FechaContratacion).HasColumnType("date");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)");
            entity.HasIndex(e => new { e.CodigoEmpleado }).IsUnique();
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Rol", "dbo");
            entity.HasKey(e => e.RolId);
            entity.Property(e => e.RolId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(80)");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.HasIndex(e => new { e.Nombre }).IsUnique();
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.ToTable("Permiso", "dbo");
            entity.HasKey(e => e.PermisoId);
            entity.Property(e => e.PermisoId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.Codigo).HasColumnType("varchar(100)");
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(120)");
            entity.Property(e => e.Modulo).HasColumnType("nvarchar(80)");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.HasIndex(e => new { e.Codigo }).IsUnique();
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.ToTable("RolPermiso", "dbo");
            entity.HasKey(e => new { e.RolId, e.PermisoId });
            entity.Property(e => e.RolId).HasColumnType("int");
            entity.Property(e => e.PermisoId).HasColumnType("int");
            entity.HasOne<Permiso>().WithMany().HasForeignKey(e => e.PermisoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Rol>().WithMany().HasForeignKey(e => e.RolId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario", "dbo");
            entity.HasKey(e => e.UsuarioId);
            entity.Property(e => e.UsuarioId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.EmpleadoId).HasColumnType("int");
            entity.Property(e => e.NombreUsuario).HasColumnType("varchar(80)");
            entity.Property(e => e.Correo).HasColumnType("varchar(150)");
            entity.Property(e => e.PasswordHash).HasColumnType("nvarchar(500)");
            entity.Property(e => e.RequiereCambioPassword).HasColumnType("bit").HasDefaultValueSql("0");
            entity.Property(e => e.IntentosFallidos).HasColumnType("int").HasDefaultValueSql("0");
            entity.Property(e => e.BloqueadoHasta).HasColumnType("datetime2(0)");
            entity.Property(e => e.UltimoAccesoEn).HasColumnType("datetime2(0)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)");
            entity.HasIndex(e => new { e.NombreUsuario }).IsUnique();
            entity.HasOne<Empleado>().WithMany().HasForeignKey(e => e.EmpleadoId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.ToTable("UsuarioRol", "dbo");
            entity.HasKey(e => new { e.UsuarioId, e.RolId });
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.RolId).HasColumnType("int");
            entity.HasOne<Rol>().WithMany().HasForeignKey(e => e.RolId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<RecuperacionPassword>(entity =>
        {
            entity.ToTable("RecuperacionPassword", "dbo");
            entity.HasKey(e => e.RecuperacionPasswordId);
            entity.Property(e => e.RecuperacionPasswordId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.TokenHash).HasColumnType("nvarchar(500)");
            entity.Property(e => e.ExpiraEn).HasColumnType("datetime2(0)");
            entity.Property(e => e.UsadoEn).HasColumnType("datetime2(0)");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<ConfiguracionSistema>(entity =>
        {
            entity.ToTable("ConfiguracionSistema", "dbo");
            entity.HasKey(e => e.ConfiguracionId);
            entity.Property(e => e.ConfiguracionId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.Clave).HasColumnType("varchar(100)");
            entity.Property(e => e.Valor).HasColumnType("nvarchar(max)");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ActualizadoPorUsuarioId).HasColumnType("int");
            entity.HasIndex(e => new { e.Clave }).IsUnique();
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.ActualizadoPorUsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categoria", "dbo");
            entity.HasKey(e => e.CategoriaId);
            entity.Property(e => e.CategoriaId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(120)");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.HasIndex(e => new { e.Nombre }).IsUnique();
        });

        modelBuilder.Entity<Subcategoria>(entity =>
        {
            entity.ToTable("Subcategoria", "dbo");
            entity.HasKey(e => e.SubcategoriaId);
            entity.Property(e => e.SubcategoriaId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.CategoriaId).HasColumnType("int");
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(120)");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.HasIndex(e => new { e.CategoriaId, e.Nombre }).IsUnique();
            entity.HasOne<Categoria>().WithMany().HasForeignKey(e => e.CategoriaId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto", "dbo");
            entity.HasKey(e => e.ProductoId);
            entity.Property(e => e.ProductoId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.SubcategoriaId).HasColumnType("int");
            entity.Property(e => e.Codigo).HasColumnType("varchar(50)");
            entity.Property(e => e.CodigoBarras).HasColumnType("varchar(80)");
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(200)");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(500)");
            entity.Property(e => e.Marca).HasColumnType("nvarchar(100)");
            entity.Property(e => e.UnidadMedida).HasColumnType("varchar(20)").HasDefaultValueSql("'UNIDAD'");
            entity.Property(e => e.CostoReferencia).HasColumnType("decimal(18,4)").HasDefaultValueSql("0");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18,2)");
            entity.Property(e => e.CantidadMinima).HasColumnType("decimal(18,3)").HasDefaultValueSql("0");
            entity.Property(e => e.PermiteVentaCredito).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)");
            entity.Property(e => e.RowVersion).HasColumnType("rowversion").IsRowVersion();
            entity.Property(e => e.CreadoPorUsuarioId).HasColumnType("int");
            entity.Property(e => e.ActualizadoPorUsuarioId).HasColumnType("int");
            entity.HasIndex(e => new { e.Codigo }).IsUnique();
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.ActualizadoPorUsuarioId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.CreadoPorUsuarioId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Subcategoria>().WithMany().HasForeignKey(e => e.SubcategoriaId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<ProductoSucursal>(entity =>
        {
            entity.ToTable("ProductoSucursal", "dbo");
            entity.HasKey(e => e.ProductoSucursalId);
            entity.Property(e => e.ProductoSucursalId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.ProductoId).HasColumnType("int");
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18,2)");
            entity.Property(e => e.CantidadMinima).HasColumnType("decimal(18,3)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.HasIndex(e => new { e.ProductoId, e.SucursalId }).IsUnique();
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente", "dbo");
            entity.HasKey(e => e.ClienteId);
            entity.Property(e => e.ClienteId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.TipoPersona).HasColumnType("char(1)").HasDefaultValueSql("'N'");
            entity.Property(e => e.TipoDocumento).HasColumnType("varchar(20)");
            entity.Property(e => e.NumeroDocumento).HasColumnType("varchar(40)");
            entity.Property(e => e.NombreRazonSocial).HasColumnType("nvarchar(200)");
            entity.Property(e => e.NombreComercial).HasColumnType("nvarchar(150)");
            entity.Property(e => e.Telefono).HasColumnType("varchar(25)");
            entity.Property(e => e.Correo).HasColumnType("varchar(150)");
            entity.Property(e => e.Direccion).HasColumnType("nvarchar(300)");
            entity.Property(e => e.LimiteCredito).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.DiasCredito).HasColumnType("int").HasDefaultValueSql("0");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)");
            entity.Property(e => e.CreadoPorUsuarioId).HasColumnType("int");
            entity.Property(e => e.ActualizadoPorUsuarioId).HasColumnType("int");
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.ActualizadoPorUsuarioId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.CreadoPorUsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.ToTable("Proveedor", "dbo");
            entity.HasKey(e => e.ProveedorId);
            entity.Property(e => e.ProveedorId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.TipoDocumento).HasColumnType("varchar(20)");
            entity.Property(e => e.NumeroDocumento).HasColumnType("varchar(40)");
            entity.Property(e => e.NombreRazonSocial).HasColumnType("nvarchar(200)");
            entity.Property(e => e.NombreComercial).HasColumnType("nvarchar(150)");
            entity.Property(e => e.Contacto).HasColumnType("nvarchar(150)");
            entity.Property(e => e.Telefono).HasColumnType("varchar(25)");
            entity.Property(e => e.Correo).HasColumnType("varchar(150)");
            entity.Property(e => e.Direccion).HasColumnType("nvarchar(300)");
            entity.Property(e => e.DiasCredito).HasColumnType("int").HasDefaultValueSql("0");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)");
            entity.Property(e => e.CreadoPorUsuarioId).HasColumnType("int");
            entity.Property(e => e.ActualizadoPorUsuarioId).HasColumnType("int");
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.ActualizadoPorUsuarioId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.CreadoPorUsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.ToTable("Compra", "dbo");
            entity.HasKey(e => e.CompraId);
            entity.Property(e => e.CompraId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.AlmacenId).HasColumnType("int");
            entity.Property(e => e.ProveedorId).HasColumnType("int");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.NumeroDocumento).HasColumnType("varchar(50)");
            entity.Property(e => e.FechaCompra).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.TipoCompra).HasColumnType("varchar(10)");
            entity.Property(e => e.Estado).HasColumnType("varchar(15)").HasDefaultValueSql("'REGISTRADA'");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Descuento).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(500)");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.RowVersion).HasColumnType("rowversion").IsRowVersion();
            entity.HasOne<Almacen>().WithMany().HasForeignKey(e => new { e.SucursalId, e.AlmacenId }).HasPrincipalKey(p => new { p.SucursalId, p.AlmacenId }).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Proveedor>().WithMany().HasForeignKey(e => e.ProveedorId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<CompraDetalle>(entity =>
        {
            entity.ToTable("CompraDetalle", "dbo");
            entity.HasKey(e => e.CompraDetalleId);
            entity.Property(e => e.CompraDetalleId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.CompraId).HasColumnType("bigint");
            entity.Property(e => e.ProductoId).HasColumnType("int");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18,3)");
            entity.Property(e => e.CostoUnitario).HasColumnType("decimal(18,4)");
            entity.Property(e => e.Descuento).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.TotalLinea).HasColumnType("decimal(18,2)");
            entity.HasOne<Compra>().WithMany().HasForeignKey(e => e.CompraId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<CuentaPorPagar>(entity =>
        {
            entity.ToTable("CuentaPorPagar", "dbo");
            entity.HasKey(e => e.CuentaPorPagarId);
            entity.Property(e => e.CuentaPorPagarId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.CompraId).HasColumnType("bigint");
            entity.Property(e => e.ProveedorId).HasColumnType("int");
            entity.Property(e => e.FechaEmision).HasColumnType("date");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.MontoOriginal).HasColumnType("decimal(18,2)");
            entity.Property(e => e.SaldoPendiente).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Estado).HasColumnType("varchar(15)").HasDefaultValueSql("'PENDIENTE'");
            entity.Property(e => e.RowVersion).HasColumnType("rowversion").IsRowVersion();
            entity.HasIndex(e => new { e.CompraId }).IsUnique();
            entity.HasOne<Compra>().WithMany().HasForeignKey(e => e.CompraId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Proveedor>().WithMany().HasForeignKey(e => e.ProveedorId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<PagoProveedor>(entity =>
        {
            entity.ToTable("PagoProveedor", "dbo");
            entity.HasKey(e => e.PagoProveedorId);
            entity.Property(e => e.PagoProveedorId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.CuentaPorPagarId).HasColumnType("bigint");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.FechaPago).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.MetodoPago).HasColumnType("varchar(20)");
            entity.Property(e => e.Monto).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Referencia).HasColumnType("varchar(100)");
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(300)");
            entity.HasOne<CuentaPorPagar>().WithMany().HasForeignKey(e => e.CuentaPorPagarId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.ToTable("Cotizacion", "dbo");
            entity.HasKey(e => e.CotizacionId);
            entity.Property(e => e.CotizacionId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.NumeroCotizacion).HasColumnType("varchar(30)");
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.ClienteId).HasColumnType("int");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.Fecha).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.ValidaHasta).HasColumnType("date");
            entity.Property(e => e.Estado).HasColumnType("varchar(15)").HasDefaultValueSql("'VIGENTE'");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Descuento).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(500)");
            entity.HasIndex(e => new { e.NumeroCotizacion }).IsUnique();
            entity.HasOne<Cliente>().WithMany().HasForeignKey(e => e.ClienteId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<CotizacionDetalle>(entity =>
        {
            entity.ToTable("CotizacionDetalle", "dbo");
            entity.HasKey(e => e.CotizacionDetalleId);
            entity.Property(e => e.CotizacionDetalleId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.CotizacionId).HasColumnType("bigint");
            entity.Property(e => e.ProductoId).HasColumnType("int");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18,3)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Descuento).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.TotalLinea).HasColumnType("decimal(18,2)");
            entity.HasOne<Cotizacion>().WithMany().HasForeignKey(e => e.CotizacionId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.ToTable("Venta", "dbo");
            entity.HasKey(e => e.VentaId);
            entity.Property(e => e.VentaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.NumeroVenta).HasColumnType("varchar(30)");
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.AlmacenId).HasColumnType("int");
            entity.Property(e => e.ClienteId).HasColumnType("int");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.CotizacionId).HasColumnType("bigint");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.TipoVenta).HasColumnType("varchar(10)");
            entity.Property(e => e.Estado).HasColumnType("varchar(15)").HasDefaultValueSql("'REGISTRADA'");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Descuento).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(500)");
            entity.Property(e => e.CreadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.RowVersion).HasColumnType("rowversion").IsRowVersion();
            entity.HasIndex(e => new { e.NumeroVenta }).IsUnique();
            entity.HasOne<Almacen>().WithMany().HasForeignKey(e => new { e.SucursalId, e.AlmacenId }).HasPrincipalKey(p => new { p.SucursalId, p.AlmacenId }).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Cliente>().WithMany().HasForeignKey(e => e.ClienteId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Cotizacion>().WithMany().HasForeignKey(e => e.CotizacionId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<VentaDetalle>(entity =>
        {
            entity.ToTable("VentaDetalle", "dbo");
            entity.HasKey(e => e.VentaDetalleId);
            entity.Property(e => e.VentaDetalleId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.VentaId).HasColumnType("bigint");
            entity.Property(e => e.ProductoId).HasColumnType("int");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18,3)");
            entity.Property(e => e.CostoUnitario).HasColumnType("decimal(18,4)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Descuento).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18,2)").HasDefaultValueSql("0");
            entity.Property(e => e.TotalLinea).HasColumnType("decimal(18,2)");
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Venta>().WithMany().HasForeignKey(e => e.VentaId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<PagoVenta>(entity =>
        {
            entity.ToTable("PagoVenta", "dbo");
            entity.HasKey(e => e.PagoVentaId);
            entity.Property(e => e.PagoVentaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.VentaId).HasColumnType("bigint");
            entity.Property(e => e.FechaPago).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.MetodoPago).HasColumnType("varchar(20)");
            entity.Property(e => e.Monto).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Referencia).HasColumnType("varchar(100)");
            entity.HasOne<Venta>().WithMany().HasForeignKey(e => e.VentaId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<CuentaPorCobrar>(entity =>
        {
            entity.ToTable("CuentaPorCobrar", "dbo");
            entity.HasKey(e => e.CuentaPorCobrarId);
            entity.Property(e => e.CuentaPorCobrarId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.VentaId).HasColumnType("bigint");
            entity.Property(e => e.ClienteId).HasColumnType("int");
            entity.Property(e => e.FechaEmision).HasColumnType("date");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.MontoOriginal).HasColumnType("decimal(18,2)");
            entity.Property(e => e.SaldoPendiente).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Estado).HasColumnType("varchar(15)").HasDefaultValueSql("'PENDIENTE'");
            entity.Property(e => e.RowVersion).HasColumnType("rowversion").IsRowVersion();
            entity.HasIndex(e => new { e.VentaId }).IsUnique();
            entity.HasOne<Cliente>().WithMany().HasForeignKey(e => e.ClienteId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Venta>().WithMany().HasForeignKey(e => e.VentaId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<AbonoCliente>(entity =>
        {
            entity.ToTable("AbonoCliente", "dbo");
            entity.HasKey(e => e.AbonoClienteId);
            entity.Property(e => e.AbonoClienteId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.CuentaPorCobrarId).HasColumnType("bigint");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.FechaAbono).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.MetodoPago).HasColumnType("varchar(20)");
            entity.Property(e => e.Monto).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Referencia).HasColumnType("varchar(100)");
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(300)");
            entity.HasOne<CuentaPorCobrar>().WithMany().HasForeignKey(e => e.CuentaPorCobrarId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<DevolucionVenta>(entity =>
        {
            entity.ToTable("DevolucionVenta", "dbo");
            entity.HasKey(e => e.DevolucionVentaId);
            entity.Property(e => e.DevolucionVentaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.VentaId).HasColumnType("bigint");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.Motivo).HasColumnType("nvarchar(300)");
            entity.Property(e => e.TotalDevuelto).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Estado).HasColumnType("varchar(15)").HasDefaultValueSql("'APLICADA'");
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Venta>().WithMany().HasForeignKey(e => e.VentaId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<DevolucionVentaDetalle>(entity =>
        {
            entity.ToTable("DevolucionVentaDetalle", "dbo");
            entity.HasKey(e => e.DevolucionVentaDetalleId);
            entity.Property(e => e.DevolucionVentaDetalleId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.DevolucionVentaId).HasColumnType("bigint");
            entity.Property(e => e.VentaDetalleId).HasColumnType("bigint");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18,3)");
            entity.Property(e => e.MontoDevuelto).HasColumnType("decimal(18,2)");
            entity.HasOne<DevolucionVenta>().WithMany().HasForeignKey(e => e.DevolucionVentaId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<VentaDetalle>().WithMany().HasForeignKey(e => e.VentaDetalleId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<InventarioExistencia>(entity =>
        {
            entity.ToTable("InventarioExistencia", "dbo");
            entity.HasKey(e => e.InventarioExistenciaId);
            entity.Property(e => e.InventarioExistenciaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.ProductoId).HasColumnType("int");
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.AlmacenId).HasColumnType("int");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18,3)").HasDefaultValueSql("0");
            entity.Property(e => e.ActualizadoEn).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.RowVersion).HasColumnType("rowversion").IsRowVersion();
            entity.HasIndex(e => new { e.ProductoId, e.AlmacenId }).IsUnique();
            entity.HasOne<Almacen>().WithMany().HasForeignKey(e => new { e.SucursalId, e.AlmacenId }).HasPrincipalKey(p => new { p.SucursalId, p.AlmacenId }).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<MovimientoInventario>(entity =>
        {
            entity.ToTable("MovimientoInventario", "dbo");
            entity.HasKey(e => e.MovimientoInventarioId);
            entity.Property(e => e.MovimientoInventarioId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.ProductoId).HasColumnType("int");
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.AlmacenId).HasColumnType("int");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.TipoMovimiento).HasColumnType("varchar(30)");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18,3)");
            entity.Property(e => e.ExistenciaAnterior).HasColumnType("decimal(18,3)");
            entity.Property(e => e.ExistenciaNueva).HasColumnType("decimal(18,3)");
            entity.Property(e => e.CostoUnitario).HasColumnType("decimal(18,4)");
            entity.Property(e => e.TipoReferencia).HasColumnType("varchar(30)");
            entity.Property(e => e.ReferenciaId).HasColumnType("bigint");
            entity.Property(e => e.Motivo).HasColumnType("nvarchar(300)");
            entity.Property(e => e.FechaMovimiento).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.HasOne<Almacen>().WithMany().HasForeignKey(e => new { e.SucursalId, e.AlmacenId }).HasPrincipalKey(p => new { p.SucursalId, p.AlmacenId }).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<AjusteInventario>(entity =>
        {
            entity.ToTable("AjusteInventario", "dbo");
            entity.HasKey(e => e.AjusteInventarioId);
            entity.Property(e => e.AjusteInventarioId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.AlmacenId).HasColumnType("int");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.TipoAjuste).HasColumnType("varchar(10)");
            entity.Property(e => e.Motivo).HasColumnType("nvarchar(300)");
            entity.Property(e => e.FechaAjuste).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.HasOne<Almacen>().WithMany().HasForeignKey(e => new { e.SucursalId, e.AlmacenId }).HasPrincipalKey(p => new { p.SucursalId, p.AlmacenId }).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<AjusteInventarioDetalle>(entity =>
        {
            entity.ToTable("AjusteInventarioDetalle", "dbo");
            entity.HasKey(e => e.AjusteInventarioDetalleId);
            entity.Property(e => e.AjusteInventarioDetalleId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.AjusteInventarioId).HasColumnType("bigint");
            entity.Property(e => e.ProductoId).HasColumnType("int");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18,3)");
            entity.HasOne<AjusteInventario>().WithMany().HasForeignKey(e => e.AjusteInventarioId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Transferencia>(entity =>
        {
            entity.ToTable("Transferencia", "dbo");
            entity.HasKey(e => e.TransferenciaId);
            entity.Property(e => e.TransferenciaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.SucursalOrigenId).HasColumnType("int");
            entity.Property(e => e.AlmacenOrigenId).HasColumnType("int");
            entity.Property(e => e.SucursalDestinoId).HasColumnType("int");
            entity.Property(e => e.AlmacenDestinoId).HasColumnType("int");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.FechaSolicitud).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.FechaRecepcion).HasColumnType("datetime2(0)");
            entity.Property(e => e.Estado).HasColumnType("varchar(15)").HasDefaultValueSql("'PENDIENTE'");
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(500)");
            entity.HasOne<Almacen>().WithMany().HasForeignKey(e => new { e.SucursalDestinoId, e.AlmacenDestinoId }).HasPrincipalKey(p => new { p.SucursalId, p.AlmacenId }).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Almacen>().WithMany().HasForeignKey(e => new { e.SucursalOrigenId, e.AlmacenOrigenId }).HasPrincipalKey(p => new { p.SucursalId, p.AlmacenId }).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalDestinoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalOrigenId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<TransferenciaDetalle>(entity =>
        {
            entity.ToTable("TransferenciaDetalle", "dbo");
            entity.HasKey(e => e.TransferenciaDetalleId);
            entity.Property(e => e.TransferenciaDetalleId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.TransferenciaId).HasColumnType("bigint");
            entity.Property(e => e.ProductoId).HasColumnType("int");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18,3)");
            entity.HasOne<Producto>().WithMany().HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Transferencia>().WithMany().HasForeignKey(e => e.TransferenciaId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.ToTable("Caja", "dbo");
            entity.HasKey(e => e.CajaId);
            entity.Property(e => e.CajaId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.Codigo).HasColumnType("varchar(20)");
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(100)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<AperturaCaja>(entity =>
        {
            entity.ToTable("AperturaCaja", "dbo");
            entity.HasKey(e => e.AperturaCajaId);
            entity.Property(e => e.AperturaCajaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.CajaId).HasColumnType("int");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.FechaApertura).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.MontoInicial).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Estado).HasColumnType("varchar(10)").HasDefaultValueSql("'ABIERTA'");
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(300)");
            entity.Property(e => e.RowVersion).HasColumnType("rowversion").IsRowVersion();
            entity.HasOne<Caja>().WithMany().HasForeignKey(e => e.CajaId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<MovimientoCaja>(entity =>
        {
            entity.ToTable("MovimientoCaja", "dbo");
            entity.HasKey(e => e.MovimientoCajaId);
            entity.Property(e => e.MovimientoCajaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.AperturaCajaId).HasColumnType("bigint");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.TipoMovimiento).HasColumnType("varchar(10)");
            entity.Property(e => e.Concepto).HasColumnType("varchar(30)");
            entity.Property(e => e.Monto).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TipoReferencia).HasColumnType("varchar(30)");
            entity.Property(e => e.ReferenciaId).HasColumnType("bigint");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(300)");
            entity.Property(e => e.FechaMovimiento).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.HasOne<AperturaCaja>().WithMany().HasForeignKey(e => e.AperturaCajaId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<CierreCaja>(entity =>
        {
            entity.ToTable("CierreCaja", "dbo");
            entity.HasKey(e => e.CierreCajaId);
            entity.Property(e => e.CierreCajaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.AperturaCajaId).HasColumnType("bigint");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.FechaCierre).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.MontoEsperado).HasColumnType("decimal(18,2)");
            entity.Property(e => e.MontoContado).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Diferencia).HasColumnType("decimal(18,2)").HasComputedColumnSql("[MontoContado] - [MontoEsperado]", stored: true);
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(300)");
            entity.HasIndex(e => new { e.AperturaCajaId }).IsUnique();
            entity.HasOne<AperturaCaja>().WithMany().HasForeignKey(e => e.AperturaCajaId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<CategoriaGasto>(entity =>
        {
            entity.ToTable("CategoriaGasto", "dbo");
            entity.HasKey(e => e.CategoriaGastoId);
            entity.Property(e => e.CategoriaGastoId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasColumnType("nvarchar(100)");
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(250)");
            entity.Property(e => e.Activo).HasColumnType("bit").HasDefaultValueSql("1");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.ToTable("Gasto", "dbo");
            entity.HasKey(e => e.GastoId);
            entity.Property(e => e.GastoId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.SucursalId).HasColumnType("int");
            entity.Property(e => e.CategoriaGastoId).HasColumnType("int");
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.AperturaCajaId).HasColumnType("bigint");
            entity.Property(e => e.FechaGasto).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.Property(e => e.Concepto).HasColumnType("nvarchar(200)");
            entity.Property(e => e.Monto).HasColumnType("decimal(18,2)");
            entity.Property(e => e.NumeroDocumento).HasColumnType("varchar(50)");
            entity.Property(e => e.Observacion).HasColumnType("nvarchar(300)");
            entity.Property(e => e.Estado).HasColumnType("varchar(10)").HasDefaultValueSql("'ACTIVO'");
            entity.HasOne<AperturaCaja>().WithMany().HasForeignKey(e => e.AperturaCajaId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<CategoriaGasto>().WithMany().HasForeignKey(e => e.CategoriaGastoId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Sucursal>().WithMany().HasForeignKey(e => e.SucursalId).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Auditoria>(entity =>
        {
            entity.ToTable("Auditoria", "dbo");
            entity.HasKey(e => e.AuditoriaId);
            entity.Property(e => e.AuditoriaId).HasColumnType("bigint").ValueGeneratedOnAdd();
            entity.Property(e => e.UsuarioId).HasColumnType("int");
            entity.Property(e => e.Tabla).HasColumnType("sysname");
            entity.Property(e => e.RegistroId).HasColumnType("nvarchar(100)");
            entity.Property(e => e.Accion).HasColumnType("varchar(20)");
            entity.Property(e => e.DatosAnteriores).HasColumnType("nvarchar(max)");
            entity.Property(e => e.DatosNuevos).HasColumnType("nvarchar(max)");
            entity.Property(e => e.DireccionIP).HasColumnType("varchar(45)");
            entity.Property(e => e.Fecha).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            entity.HasOne<Usuario>().WithMany().HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.NoAction);
        });

    }
}
