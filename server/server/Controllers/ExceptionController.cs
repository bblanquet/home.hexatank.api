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
        public async Task<List<SmExceptionDetail>> List()
        {
            return await new ExceptionService().List();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ExceptionDetail> Get(int id)
        {
            return await new ExceptionService().Get(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task Add(ExceptionDetail exception)
        {
            exception.Date = System.DateTime.Now;
            await new ExceptionService().Add(exception);
        }
    }
}
