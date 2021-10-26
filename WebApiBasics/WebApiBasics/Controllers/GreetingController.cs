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
    public class GreetingController : ControllerBase
    {
        [HttpGet("ping")]
        public string Ping()
        {
            return "pong";
        }

        [HttpGet("hello")]
        public string Hello(string name)
        {
            return $"Hello {name}!";
        }
    }
}
