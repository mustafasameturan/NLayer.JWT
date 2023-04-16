namespace SharedLibrary.Configurations;

public class CustomTokenOption
{
    public List<string> Auidence { get; set; }
    public string Issuer { get; set; }
    public int AccessTokenExpiration { get; set; }
    public int RefreshTokenExpiration { get; set; }
    public string SecurityKey { get; set; }
}