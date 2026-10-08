namespace RepuestosMoto.Domain.Entities;

public class Auditoria
{
    public long AuditoriaId { get; set; }
    public int? UsuarioId { get; set; }
    public string Tabla { get; set; } = string.Empty;
    public string? RegistroId { get; set; }
    public string Accion { get; set; } = string.Empty;
    public string? DatosAnteriores { get; set; }
    public string? DatosNuevos { get; set; }
    public string? DireccionIP { get; set; }
    public DateTime Fecha { get; set; }
}
