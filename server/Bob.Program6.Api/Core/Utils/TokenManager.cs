using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bob.Program6.Api.Core.Utils
{
    public class TokenManager: ITokenManager
    {
        private AppSettings _appSettings;

        public TokenManager(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public string GetToken(Claim[] claims, DateTime date)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = date,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool IsValid(string token)
        {
            try {
                new JwtSecurityTokenHandler()
                    .ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._appSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                },
                out SecurityToken validatedToken);
                return DateTime.UtcNow < validatedToken.ValidTo;
            }
            catch { 
            
            }
            return false;
        }

        public JwtSecurityToken GetStatus(string token)
        {
            new JwtSecurityTokenHandler()
                .ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._appSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            },
            out SecurityToken validatedToken);
            return (JwtSecurityToken) validatedToken;
        }
    }
}
