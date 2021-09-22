using Bob.Program6.Api.Core.Services;
using Bob.Program6.Security.Core;
using Bob.Program6.Security.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthentificationController : ControllerBase
    {
        private IPlayerService _playerService;
        private ITokenManager _tokenManager;

        public AuthentificationController(IPlayerService userService, ITokenManager tokenManager)
        {
            _playerService = userService;
            _tokenManager = tokenManager;
        }


        [Route("signIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(AuthenticateRequest request)
        {
            if (!request.IsValid())
            {
                return BadRequest(new { message = AuthenticateRequestHelper.Error });
            }

            var response = await this._playerService.SignIn(request);
            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(response);
        }


        [Route("signUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(AuthenticateRequest request)
        {
            if (!request.IsValid())
            {
                return BadRequest(new { message = AuthenticateRequestHelper.Error });
            }

            var response = await this._playerService.SignUp(request);
            if (response == null)
            {
                return BadRequest(new { message = "Username is already used" });
            }
            return Ok(response);
        }

        [Route("isValid")]
        [HttpGet]
        public IActionResult IsValid(string token)
        {
            return Ok(this._tokenManager.IsValid(token));
        }
    }
}
