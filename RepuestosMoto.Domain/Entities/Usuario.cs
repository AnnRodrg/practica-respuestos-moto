namespace RepuestosMoto.Domain.Entities;

public class Usuario
{
    public int UsuarioId { get; set; }
    public int? EmpleadoId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string? Correo { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public bool RequiereCambioPassword { get; set; }
    public int IntentosFallidos { get; set; }
    public DateTime? BloqueadoHasta { get; set; }
    public DateTime? UltimoAccesoEn { get; set; }
    public bool Activo { get; set; }
    public DateTime CreadoEn { get; set; }
    public DateTime? ActualizadoEn { get; set; }
}
