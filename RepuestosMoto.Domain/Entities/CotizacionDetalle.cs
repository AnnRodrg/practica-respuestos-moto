namespace RepuestosMoto.Domain.Entities;

public class CotizacionDetalle
{
    public long CotizacionDetalleId { get; set; }
    public long CotizacionId { get; set; }
    public int ProductoId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Impuesto { get; set; }
    public decimal TotalLinea { get; set; }
}
