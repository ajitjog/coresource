using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi1.Controllers
{
    [Route("api/env")]
    [ApiController]
    public class EnvController : ControllerBase
    {

        [HttpGet("{envname}")]
        public IActionResult Get(string envname)
        {
            var hname = Environment.MachineName;
            return Ok($"Hello World to {envname} from {hname}");
        }

    }
}