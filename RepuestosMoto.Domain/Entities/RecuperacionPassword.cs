namespace RepuestosMoto.Domain.Entities;

public class RecuperacionPassword
{
    public long RecuperacionPasswordId { get; set; }
    public int UsuarioId { get; set; }
    public string TokenHash { get; set; } = string.Empty;
    public DateTime ExpiraEn { get; set; }
    public DateTime? UsadoEn { get; set; }
    public DateTime CreadoEn { get; set; }
}
