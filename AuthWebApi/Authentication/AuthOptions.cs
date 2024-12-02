using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hospital.Application.Authentication;

internal class AuthOptions
{
    public const string Issuer = "HospitalIsser";
    public const string Audience = "MyAuthUser";
    const string key = "1B306BA1-11BB-4866-916B-47D12F6FB0A2";
    public const int lifeTime = 60;
    public static SymmetricSecurityKey GetSymmetricSecurityKey()=>new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
}
