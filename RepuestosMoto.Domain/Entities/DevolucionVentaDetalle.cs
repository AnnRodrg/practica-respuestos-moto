namespace RepuestosMoto.Domain.Entities;

public class DevolucionVentaDetalle
{
    public long DevolucionVentaDetalleId { get; set; }
    public long DevolucionVentaId { get; set; }
    public long VentaDetalleId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal MontoDevuelto { get; set; }
}
