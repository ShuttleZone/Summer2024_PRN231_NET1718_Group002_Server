using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Application.Services.Token;

[AutoRegister]
public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _key;
    private readonly UserManager<User> _userManager;
    
    public TokenService(IConfiguration configuration, UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]!));
    }
    public string CreateToken(User user)
    {
        var roles = _userManager.GetRolesAsync(user).Result;
        
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName!),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
        };
        
        claims.AddRange(roles.Select(c => new Claim(ClaimTypes.Role, c)));

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(30),
            SigningCredentials = creds,
        };

        var tokenHandle = new JwtSecurityTokenHandler();

        var token = tokenHandle.CreateToken(tokenDescriptor);

        return tokenHandle.WriteToken(token);
    }

    public object? GetTokenClaim(string token, string claimName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]!))
        };
        try
        {
            tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
            var jwtSecurityToken = (JwtSecurityToken)validatedToken;
            var propInfo = typeof(JwtSecurityToken).GetProperties().FirstOrDefault(x => x.Name == claimName);
            return propInfo?.GetValue(jwtSecurityToken);
        }
        catch (Exception e)
        {
            throw new Exception("Invalid Token Exception", e.InnerException);
        }
    }

    public AuthModel GetAuthModel(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]!))
        };
        try
        {
            tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
            var jwtSecurityToken = (JwtSecurityToken)validatedToken;
            var userName = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "name")?.Value;
            var userId = jwtSecurityToken.Subject;
            var role = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "role")?.Value ?? "";
            var authModel = new AuthModel
            {
                UserId = Guid.Parse(userId),
                UserName = userId,
                Role = role,
            };
            return authModel;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}