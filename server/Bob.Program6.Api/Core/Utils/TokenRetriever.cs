using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Utils
{
    public class TokenRetriever: ITokenRetriever
    {
        public string GetToken(string authorizationHeader)
        {
            if (authorizationHeader != null)
            {
                var rx = new Regex(@"Bearer (?<token>.*)");
                var result = rx.Match(authorizationHeader);
                if (result.Success)
                {
                    return result.Groups[1].Value;
                }
            }
            return null;
        }
    }
}
