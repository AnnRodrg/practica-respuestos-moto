namespace RepuestosMoto.Domain.Entities;

public class CuentaPorCobrar
{
    public long CuentaPorCobrarId { get; set; }
    public long VentaId { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaEmision { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public decimal MontoOriginal { get; set; }
    public decimal SaldoPendiente { get; set; }
    public string Estado { get; set; } = string.Empty;
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}
