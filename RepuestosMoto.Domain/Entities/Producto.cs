using System.ComponentModel.DataAnnotations;

namespace RepuestosMoto.Domain.Entities;

public class Producto
{
    //[Key]
    //[Required]
    public int ProductoId { get; set; }
    public int SubcategoriaId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string? CodigoBarras { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string? Marca { get; set; }
    public string UnidadMedida { get; set; } = string.Empty;
    public decimal CostoReferencia { get; set; }
    public decimal PrecioVenta { get; set; }
    public decimal CantidadMinima { get; set; }
    public bool PermiteVentaCredito { get; set; }
    public bool Activo { get; set; }
    public DateTime CreadoEn { get; set; }
    public DateTime? ActualizadoEn { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    public int? CreadoPorUsuarioId { get; set; }
    public int? ActualizadoPorUsuarioId { get; set; }
}
