using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayerJWT.Core.DTOs;
using NLayerJWT.Core.Services;

namespace NLayerJWT.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
    }

    [Authorize]
    [HttpGet, Route("getUserByName")]
    public async Task<IActionResult> GetUser(string userName)
    {
        //Token üzerinden Name parametresini bulur. 
        return ActionResultInstance(await _userService.GetUserByName(userName));
    }
}