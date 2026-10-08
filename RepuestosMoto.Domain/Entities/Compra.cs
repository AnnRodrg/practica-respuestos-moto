namespace RepuestosMoto.Domain.Entities;

public class Compra
{
    public long CompraId { get; set; }
    public int SucursalId { get; set; }
    public int AlmacenId { get; set; }
    public int ProveedorId { get; set; }
    public int UsuarioId { get; set; }
    public string NumeroDocumento { get; set; } = string.Empty;
    public DateTime FechaCompra { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public string TipoCompra { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public decimal Subtotal { get; set; }
    public decimal Descuento { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    public string? Observacion { get; set; }
    public DateTime CreadoEn { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}
