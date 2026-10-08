namespace RepuestosMoto.Domain.Entities;

public class ConfiguracionSistema
{
    public int ConfiguracionId { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string? Valor { get; set; }
    public string? Descripcion { get; set; }
    public DateTime ActualizadoEn { get; set; }
    public int? ActualizadoPorUsuarioId { get; set; }
}
