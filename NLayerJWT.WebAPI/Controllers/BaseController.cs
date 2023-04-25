using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs;

namespace NLayerJWT.WebAPI.Controllers;

public class BaseController : ControllerBase
{
    public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}