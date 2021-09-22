

using Bob.Program6.Api.Core.Model;
using Bob.Program6.Api.Core.Services;
using Bob.Program6.Api.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService userService)
        {
            _playerService = userService;
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
        public async Task<IActionResult> Update(Player player)
        {
            var user = (Player)HttpContext.Items[typeof(Player).Name];
            user.Update(player);
            await this._playerService.Update(user);
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
