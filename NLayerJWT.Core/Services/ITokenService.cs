using NLayerJWT.Core.Configurations;
using NLayerJWT.Core.DTOs;
using NLayerJWT.Core.Models;

namespace NLayerJWT.Core.Services;

public interface ITokenService
{
    TokenDto CreateToken(UserApp userApp);
    ClientTokenDto CreateTokenByClient(Client client);
}