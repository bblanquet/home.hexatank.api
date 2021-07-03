using Microsoft.AspNetCore.Mvc;
using server.Core.Model;
using server.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionController
    {
        [HttpGet]
        [Route("List")]
        public async Task<List<ExceptionDetail>> List()
        {
            return await new ExceptionService().List();
        }

        [HttpPost]
        [Route("Add")]
        public async Task Add([FromBody] ExceptionDetail exception)
        {
            await new ExceptionService().Add(exception);
        }
    }
}
