namespace ApiDz2.Auth
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDto user);
    }
}
