namespace RepuestosMoto.Domain.Entities;

public class VentaDetalle
{
    public long VentaDetalleId { get; set; }
    public long VentaId { get; set; }
    public int ProductoId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal CostoUnitario { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Impuesto { get; set; }
    public decimal TotalLinea { get; set; }
}
