namespace RepuestosMoto.Domain.Entities;

public class Almacen
{
    public int AlmacenId { get; set; }
    public int SucursalId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Activo { get; set; }
    public DateTime CreadoEn { get; set; }
    public DateTime? ActualizadoEn { get; set; }
}
