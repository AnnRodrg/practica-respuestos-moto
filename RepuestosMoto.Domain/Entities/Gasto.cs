namespace RepuestosMoto.Domain.Entities;

public class Gasto
{
    public long GastoId { get; set; }
    public int SucursalId { get; set; }
    public int CategoriaGastoId { get; set; }
    public int UsuarioId { get; set; }
    public long? AperturaCajaId { get; set; }
    public DateTime FechaGasto { get; set; }
    public string Concepto { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? Observacion { get; set; }
    public string Estado { get; set; } = string.Empty;
}
