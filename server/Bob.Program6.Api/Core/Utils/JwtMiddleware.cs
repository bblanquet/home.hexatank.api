using Bob.Program6.Api.Core.Model;
using Bob.Program6.Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;


namespace Bob.Program6.Api.Core.Utils
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appsettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> options)
        {
            _next = next;
            _appsettings = options.Value;
        }

        public async Task InvokeAsync(HttpContext context, 
            ITokenRetriever tokenRtr,
            IPlayerService playerSvc, 
            ITokenManager tokenMgr)
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            var token = tokenRtr.GetToken(authorizationHeader);
            if (token != null) {
                try
                {
                    if (tokenMgr.IsValid(token))
                    {
                        var jwtToken = tokenMgr.GetStatus(token);
                        var playerName = jwtToken.Claims.First(x => x.Type == nameof(Player.Name)).Value;
                        context.Items[nameof(Player)] = (await playerSvc.GetByName(playerName));
                    }
                }
                catch
                {
                    //don't do anything
                }
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

    }
}
