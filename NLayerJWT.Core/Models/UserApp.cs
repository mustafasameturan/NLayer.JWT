using Microsoft.AspNetCore.Identity;

namespace NLayerJWT.Core.Models;

public class UserApp : IdentityUser
{
    public string City { get; set; }
}