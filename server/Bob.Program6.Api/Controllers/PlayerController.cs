

using Bob.Program6.Api.Core.Model;
using Bob.Program6.Api.Core.Services;
using Bob.Program6.Api.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private IPlayerService _playerService;
        private ITokenManager _tokenManager;

        public PlayerController(IPlayerService userService, ITokenManager tokenManager)
        {
            _playerService = userService;
            _tokenManager = tokenManager;
        }

        [Route("signIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(AuthenticateRequest request)
        {
            if (!request.IsValid()) {
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
        public async Task<IActionResult> SignUp(AuthenticateRequest request) {
            if (!request.IsValid())
            {
                return BadRequest(new { message = AuthenticateRequestHelper.Error });
            }

            var response = await this._playerService.SignUp(request);
            if(response == null)
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

        [Route("details")]
        [Authorize]
        [HttpGet]
        public IActionResult GetDetails()
        {
            var user = (Player)HttpContext.Items[typeof(Player).Name];
            return Ok(user);
        }

        [Route("rank")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetRank()
        {
            var user = (Player)HttpContext.Items[typeof(Player).Name];
            var rank = await this._playerService.GetRank(user.Name);
            return Ok(rank);
        }

        [Route("update")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(int score)
        {
            var user = HttpContext.Items[typeof(Player).Name];
            await this._playerService.Update((Player)user, score);
            return Ok();
        }


        [Route("top100")]
        [HttpGet]
        public async Task<IActionResult> GetTop100()
        {
            return Ok((await this._playerService.Get100Players()));
        }
    }
}
