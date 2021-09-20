using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Utils
{
    public interface ITokenRetriever
    {
        string GetToken(string authorizationHeader);
    }
}
