namespace RepuestosMoto.Domain.Entities;

public class TransferenciaDetalle
{
    public long TransferenciaDetalleId { get; set; }
    public long TransferenciaId { get; set; }
    public int ProductoId { get; set; }
    public decimal Cantidad { get; set; }
}
