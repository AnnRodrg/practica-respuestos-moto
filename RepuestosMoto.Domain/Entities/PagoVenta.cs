namespace RepuestosMoto.Domain.Entities;

public class PagoVenta
{
    public long PagoVentaId { get; set; }
    public long VentaId { get; set; }
    public DateTime FechaPago { get; set; }
    public string MetodoPago { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public string? Referencia { get; set; }
}
