using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniApp1.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{

    [HttpGet]
    public IActionResult GetStock()
    {
        var userName = HttpContext.User.Identity.Name;

        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);


        return Ok($"UserName:{userName} - UserId:{userIdClaim.Value}");
    }
}