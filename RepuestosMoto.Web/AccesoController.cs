using Microsoft.AspNetCore.Mvc;

namespace RepuestosMoto.Web.Controllers;

public sealed class AccesoController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
}