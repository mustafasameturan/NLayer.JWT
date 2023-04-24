using Microsoft.AspNetCore.Mvc;

namespace NLayerJWT.WebAPI.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}