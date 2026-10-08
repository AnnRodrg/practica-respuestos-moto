namespace RepuestosMoto.Domain.Entities;

public class PagoProveedor
{
    public long PagoProveedorId { get; set; }
    public long CuentaPorPagarId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaPago { get; set; }
    public string MetodoPago { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public string? Referencia { get; set; }
    public string? Observacion { get; set; }
}
