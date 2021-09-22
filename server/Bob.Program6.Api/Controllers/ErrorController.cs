using Microsoft.AspNetCore.Mvc;
using Bob.Program6.Api.Core.Model;
using Bob.Program6.Api.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bob.Program6.Api.Core.Utils;

namespace Bob.Program6.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController
        : ControllerBase
    {
        private IExceptionService _exceptionService;

        public ErrorController(IExceptionService exceptionService)
        {
            _exceptionService = exceptionService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<List<LightErrorDetails>> List()
        {
            Logger.Log(LogKind.Info, "EXP LIST");
            return await this._exceptionService.List();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ErrorDetails> Get(int id)
        {
            Logger.Log(LogKind.Info, "EXP GET");
            return await this._exceptionService.Get(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task Add(ErrorDetails exception)
        {
            Logger.Log(LogKind.Info, "EXP ADD");
            await this._exceptionService.Add(exception);
        }
    }
}
