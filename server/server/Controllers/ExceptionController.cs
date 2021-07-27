using Microsoft.AspNetCore.Mvc;
using server.Core.Model;
using server.Core.Services;
using System;
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
            Console.WriteLine($"[${DateTime.Now.ToString("f")}] [EXCEPTION] [LIST]");
            return await new ExceptionService().List();
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ExceptionDetail> Get(int id)
        {
            Console.WriteLine($"[${DateTime.Now.ToString("f")}] [EXCEPTION] [GET]");
            return await new ExceptionService().Get(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task Add(ExceptionDetail exception)
        {
            Console.WriteLine($"[${DateTime.Now.ToString("f")}] [EXCEPTION] [ADD]");
            exception.Date = System.DateTime.Now;
            await new ExceptionService().Add(exception);
        }
    }
}
