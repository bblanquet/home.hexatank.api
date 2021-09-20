using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bob.Program6.Api.Core.Utils
{
    public interface ITokenManager
    {
        string GetToken(Claim[] claims, DateTime date);
        bool IsValid(string token);
        JwtSecurityToken GetStatus(string token);
    }
}
