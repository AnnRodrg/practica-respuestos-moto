namespace RepuestosMoto.Domain.Entities;

public class AjusteInventarioDetalle
{
    public long AjusteInventarioDetalleId { get; set; }
    public long AjusteInventarioId { get; set; }
    public int ProductoId { get; set; }
    public decimal Cantidad { get; set; }
}
