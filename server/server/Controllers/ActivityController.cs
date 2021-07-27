using Microsoft.AspNetCore.Mvc;
using server.Core;
using server.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        [HttpGet]
        [Route("List")]
        public async Task<List<Activity>> List()
        {
            Console.WriteLine($"[${DateTime.Now.ToString("f")}] [ACTIVITY] [LIST]");
            return await new ActivityService().List();
        }

        [HttpPost]
        [Route("Add")]
        public async Task Add(Activity activity)
        {
            Console.WriteLine($"[${DateTime.Now.ToString("f")}] [ACTIVITY] [ADD]");
            await new ActivityService().Add(activity);
        }
    }
}
