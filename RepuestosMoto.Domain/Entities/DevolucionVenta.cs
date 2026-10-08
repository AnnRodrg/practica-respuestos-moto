namespace RepuestosMoto.Domain.Entities;

public class DevolucionVenta
{
    public long DevolucionVentaId { get; set; }
    public long VentaId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaDevolucion { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public decimal TotalDevuelto { get; set; }
    public string Estado { get; set; } = string.Empty;
}
