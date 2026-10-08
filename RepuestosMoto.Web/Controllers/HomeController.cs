using Microsoft.AspNetCore.Mvc;
using RepuestosMoto.Application.Abstractions;
using RepuestosMoto.Domain.Entities;

namespace RepuestosMoto.Web.Controllers;

public sealed class HomeController(IRepository<Producto> products) : Controller
{
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var rows = await products.FindAsync(p => p.Activo, ct);
        return View(rows.Take(50).Select(p => new ProductoListado(p.Codigo, p.Nombre, p.PrecioVenta)).ToList());
    }
}
public sealed record ProductoListado(string Codigo, string Nombre, decimal PrecioVenta);
