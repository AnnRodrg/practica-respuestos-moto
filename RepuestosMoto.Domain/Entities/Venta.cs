namespace RepuestosMoto.Domain.Entities;

public class Venta
{
    public long VentaId { get; set; }
    public string NumeroVenta { get; set; } = string.Empty;
    public int SucursalId { get; set; }
    public int AlmacenId { get; set; }
    public int? ClienteId { get; set; }
    public int UsuarioId { get; set; }
    public long? CotizacionId { get; set; }
    public DateTime FechaVenta { get; set; }
    public string TipoVenta { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public decimal Subtotal { get; set; }
    public decimal Descuento { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    public string? Observacion { get; set; }
    public DateTime CreadoEn { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}
