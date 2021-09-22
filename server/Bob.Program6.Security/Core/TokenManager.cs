using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bob.Program6.Security.Core
{
    public class TokenManager : ITokenManager
    {
        private string _secret;
        public TokenManager()
        {
            this._secret = Environment.GetEnvironmentVariable("KEY");
        }

        public TokenManager(string key)
        {
            this._secret = key;
        }

        public string GetToken(Claim[] claims, DateTime date)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._secret);
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
            try
            {
                new JwtSecurityTokenHandler()
                    .ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    },
                out SecurityToken validatedToken);
                return DateTime.UtcNow < validatedToken.ValidTo;
            }
            catch
            {

            }
            return false;
        }

        public JwtSecurityToken GetStatus(string token)
        {
            new JwtSecurityTokenHandler()
                .ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                },
            out SecurityToken validatedToken);
            return (JwtSecurityToken)validatedToken;
        }
    }
}
