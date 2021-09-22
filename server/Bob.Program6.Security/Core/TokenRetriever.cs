using System.Text.RegularExpressions;

namespace Bob.Program6.Security.Core
{
    public class TokenRetriever : ITokenRetriever
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
