namespace RepuestosMoto.Domain.Entities;

public class Subcategoria
{
    public int SubcategoriaId { get; set; }
    public int CategoriaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Activo { get; set; }
    public DateTime CreadoEn { get; set; }
}
