namespace RepuestosMoto.Domain.Entities;

public class Proveedor
{
    public int ProveedorId { get; set; }
    public string? TipoDocumento { get; set; }
    public string? NumeroDocumento { get; set; }
    public string NombreRazonSocial { get; set; } = string.Empty;
    public string? NombreComercial { get; set; }
    public string? Contacto { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? Direccion { get; set; }
    public int DiasCredito { get; set; }
    public bool Activo { get; set; }
    public DateTime CreadoEn { get; set; }
    public DateTime? ActualizadoEn { get; set; }
    public int? CreadoPorUsuarioId { get; set; }
    public int? ActualizadoPorUsuarioId { get; set; }
}
