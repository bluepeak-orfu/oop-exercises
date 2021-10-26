using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBasics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        [HttpGet("ping")]
        public string Ping()
        {
            return "pong";
        }

        [HttpGet("concat")]
        public string Concat(string part1, string part2)
        {
            return part1 + part2;
        }
    }
}
