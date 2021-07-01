using Microsoft.AspNetCore.Mvc;
using server.Core;
using server.Core.Dao;
using server.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return new DataContext().Activities.ToList();
        }
    }
}
