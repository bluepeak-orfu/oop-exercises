using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMappings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("get")]
        public Person GetPerson()
        {
            Person person;
            person = new Person()
            {
                Name = "Pelle",
                Age = 12
            };
            return person;
        }

        [HttpGet("list")]
        public List<Person> ListPersons()
        {
            return new List<Person>()
            {
                new Person() { Name = "Adam", Age = 22 },
                new Person() { Name = "Berit", Age = 33 },
                new Person() { Name = "Calle", Age = 44 }
            };
        }

        [HttpPost("create")]
        public bool CreatePerson([FromBody] Person person)
        {
            return true;
        }
    }
}
