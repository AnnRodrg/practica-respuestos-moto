namespace RepuestosMoto.Domain.Entities;

public class Empleado
{
    public int EmpleadoId { get; set; }
    public int SucursalId { get; set; }
    public string CodigoEmpleado { get; set; } = string.Empty;
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string? TipoDocumento { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? Direccion { get; set; }
    public DateTime? FechaContratacion { get; set; }
    public bool Activo { get; set; }
    public DateTime CreadoEn { get; set; }
    public DateTime? ActualizadoEn { get; set; }
}
