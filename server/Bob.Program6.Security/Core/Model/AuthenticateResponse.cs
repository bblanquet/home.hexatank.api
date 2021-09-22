
namespace Bob.Program6.Security.Core.Model
{
    public class AuthenticateResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(string name, string token)
        {
            Name = name;
            Token = token;
        }
    }
}
