using Microsoft.AspNetCore.Mvc;
using Bob.Program6.Api.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bob.Program6.Api.Core.Utils;
using Bob.Program6.Api.Core.Services;

namespace Bob.Program6.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordController : ControllerBase
    {
        private IRecordService _recordService;

        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<List<Record>> List()
        {
            Logger.Log(LogKind.Info, "EXP LIST");
            return await this._recordService.List();
        }

        [HttpPost]
        [Route("Add")]
        public async Task Add(Record activity)
        {
            Logger.Log(LogKind.Info, "EXP ADD");
            await this._recordService.Add(activity);
        }
    }
}
