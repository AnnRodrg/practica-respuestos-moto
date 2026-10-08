namespace RepuestosMoto.Domain.Entities;

public class CompraDetalle
{
    public long CompraDetalleId { get; set; }
    public long CompraId { get; set; }
    public int ProductoId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal CostoUnitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Impuesto { get; set; }
    public decimal TotalLinea { get; set; }
}
