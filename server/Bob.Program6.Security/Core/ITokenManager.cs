using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bob.Program6.Security.Core
{
    public interface ITokenManager
    {
        string GetToken(Claim[] claims, DateTime date);
        bool IsValid(string token);
        JwtSecurityToken GetStatus(string token);
    }
}
