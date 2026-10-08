namespace RepuestosMoto.Domain.Entities;

public class AperturaCaja
{
    public long AperturaCajaId { get; set; }
    public int CajaId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaApertura { get; set; }
    public decimal MontoInicial { get; set; }
    public string Estado { get; set; } = string.Empty;
    public string? Observacion { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}
