namespace RepuestosMoto.Domain.Entities;

public class Transferencia
{
    public long TransferenciaId { get; set; }
    public int SucursalOrigenId { get; set; }
    public int AlmacenOrigenId { get; set; }
    public int SucursalDestinoId { get; set; }
    public int AlmacenDestinoId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRecepcion { get; set; }
    public string Estado { get; set; } = string.Empty;
    public string? Observacion { get; set; }
}
