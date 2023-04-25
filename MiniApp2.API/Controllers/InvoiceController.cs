using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniApp2.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var userName = HttpContext.User.Identity.Name;

        var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);


        return Ok($"UserName:{userName} - UserId:{userIdClaim.Value}");
    }
}