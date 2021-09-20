using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Model
{
    public class AuthenticateResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Player user, string token)
        {
            Name = user.Name;
            Token = token;
        }
    }
}
