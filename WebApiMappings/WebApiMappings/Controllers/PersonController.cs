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
        private static List<Person> persons = new List<Person>();

        [HttpGet("{personId}")]
        public Person GetPerson(int personId)
        {
            foreach (Person person in persons)
            {
                if (person.Id == personId)
                {
                    return person;
                }
            }
            return null;
        }

        [HttpGet]
        public List<Person> ListPersons()
        {
            return persons;
        }

        [HttpPost]
        public bool CreatePerson([FromBody] Person person)
        {
            persons.Add(person);
            return true;
        }
    }
}
