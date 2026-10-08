namespace RepuestosMoto.Domain.Entities;

public class Cotizacion
{
    public long CotizacionId { get; set; }
    public string NumeroCotizacion { get; set; } = string.Empty;
    public int SucursalId { get; set; }
    public int? ClienteId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime? ValidaHasta { get; set; }
    public string Estado { get; set; } = string.Empty;
    public decimal Subtotal { get; set; }
    public decimal Descuento { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    public string? Observacion { get; set; }
}
