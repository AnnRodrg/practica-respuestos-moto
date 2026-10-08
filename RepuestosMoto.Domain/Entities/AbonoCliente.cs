namespace RepuestosMoto.Domain.Entities;

public class AbonoCliente
{
    public long AbonoClienteId { get; set; }
    public long CuentaPorCobrarId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaAbono { get; set; }
    public string MetodoPago { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public string? Referencia { get; set; }
    public string? Observacion { get; set; }
}
