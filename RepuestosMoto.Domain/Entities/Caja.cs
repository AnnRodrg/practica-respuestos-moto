namespace RepuestosMoto.Domain.Entities;

public class Caja
{
    public int CajaId { get; set; }
    public int SucursalId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public bool Activo { get; set; }
}
