using NLayerJWT.Core.DTOs;
using SharedLibrary.DTOs;

namespace NLayerJWT.Core.Services;

public interface IUserService
{
    Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto userDto);
    Task<Response<UserAppDto>> GetUserByName(string userName);
}