using AuthWebApi.FContext;
using AuthWebApi.Models;
using Hospital.Application.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthWebApi.Services;
    
public class AuthService 
{
    private readonly MyContext _repository;
    public AuthService(MyContext context)
    {
        _repository = context;
    }
    public async Task<string> Login(User user)
    {
        var Checkuser = _repository.Users.FirstOrDefault(k => k.Login == user.Login && k.Password == user.Password);
        if (Checkuser != null)
        {
            return await GeneratedJWt(Checkuser);
        }
        return "This is User not found from Db";
    }

    private async Task<string> GeneratedJWt(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.Login),
            new Claim("Id",user.Id.ToString()),
        };

        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.Now.Add(TimeSpan.FromMinutes(AuthOptions.lifeTime)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        return accessToken;
    }
}
