namespace RepuestosMoto.Domain.Entities;

public class CierreCaja
{
    public long CierreCajaId { get; set; }
    public long AperturaCajaId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaCierre { get; set; }
    public decimal MontoEsperado { get; set; }
    public decimal MontoContado { get; set; }
    public decimal Diferencia { get; set; }
    public string? Observacion { get; set; }
}
