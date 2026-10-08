namespace RepuestosMoto.Domain.Entities;

public class MovimientoCaja
{
    public long MovimientoCajaId { get; set; }
    public long AperturaCajaId { get; set; }
    public int UsuarioId { get; set; }
    public string TipoMovimiento { get; set; } = string.Empty;
    public string Concepto { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public string? TipoReferencia { get; set; }
    public long? ReferenciaId { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaMovimiento { get; set; }
}
