namespace RepuestosMoto.Domain.Entities;

public class ProductoSucursal
{
    public int ProductoSucursalId { get; set; }
    public int ProductoId { get; set; }
    public int SucursalId { get; set; }
    public decimal? PrecioVenta { get; set; }
    public decimal? CantidadMinima { get; set; }
    public bool Activo { get; set; }
}
