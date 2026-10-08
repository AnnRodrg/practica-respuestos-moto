namespace RepuestosMoto.Domain.Entities;

public class InventarioExistencia
{
    public long InventarioExistenciaId { get; set; }
    public int ProductoId { get; set; }
    public int SucursalId { get; set; }
    public int AlmacenId { get; set; }
    public decimal Cantidad { get; set; }
    public DateTime ActualizadoEn { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}
