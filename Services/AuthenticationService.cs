namespace Leden.API.Services;

public record UserInfo(string username, string name, string city);
public record AuthenticationRequestBody(string username, string password);

public interface IAuthenticationService
{
    string Authenticate(AuthenticationRequestBody authenticationRequestBody);
    UserInfo ValidateUser(string username, string password);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly AuthenticationSettings _authSettings;

    public AuthenticationService(IOptions<AuthenticationSettings> authSettings)
    {
        _authSettings = authSettings.Value;
    }

    public UserInfo ValidateUser(string username, string password)
    {
        return new UserInfo("antonl", "Labeeuw Anton", "Lichtervelde");
    }

    // public string Authenticate (AuthenticationRequestBody authenticationRequestBody){
    //     UserInfo userInfo = ValidateUser(authenticationRequestBody.username, authenticationRequestBody.password);

    //     if (userI)
    // }

    public string Authenticate(AuthenticationRequestBody authenticationRequestBody)
    {
        UserInfo userInfo = ValidateUser(authenticationRequestBody.username, authenticationRequestBody.password);

        if (userInfo == null) return null;

        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(_authSettings.SecretForKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_authSettings.Issuer, _authSettings.Audience, new[]{
            new Claim("username", userInfo.username),
            new Claim("name", userInfo.name),
            new Claim("city", userInfo.city)
        },
        expires: DateTime.Now.AddHours(2),
        signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}