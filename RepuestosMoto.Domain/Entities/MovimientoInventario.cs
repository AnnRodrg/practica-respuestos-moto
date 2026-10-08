namespace RepuestosMoto.Domain.Entities;

public class MovimientoInventario
{
    public long MovimientoInventarioId { get; set; }
    public int ProductoId { get; set; }
    public int SucursalId { get; set; }
    public int AlmacenId { get; set; }
    public int UsuarioId { get; set; }
    public string TipoMovimiento { get; set; } = string.Empty;
    public decimal Cantidad { get; set; }
    public decimal ExistenciaAnterior { get; set; }
    public decimal ExistenciaNueva { get; set; }
    public decimal? CostoUnitario { get; set; }
    public string? TipoReferencia { get; set; }
    public long? ReferenciaId { get; set; }
    public string? Motivo { get; set; }
    public DateTime FechaMovimiento { get; set; }
}
