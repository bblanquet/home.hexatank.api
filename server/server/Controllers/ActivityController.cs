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
        public async Task<List<Activity>> Get()
        {
            Console.WriteLine("IN");
            var activityService = new ActivityService();
            var result = await activityService.Load();
            Console.WriteLine("OUT");
            return result;
        }
    }
}
