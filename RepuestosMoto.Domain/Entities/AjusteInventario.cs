namespace RepuestosMoto.Domain.Entities;

public class AjusteInventario
{
    public long AjusteInventarioId { get; set; }
    public int SucursalId { get; set; }
    public int AlmacenId { get; set; }
    public int UsuarioId { get; set; }
    public string TipoAjuste { get; set; } = string.Empty;
    public string Motivo { get; set; } = string.Empty;
    public DateTime FechaAjuste { get; set; }
}
