using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMappings
{
    public class Person
    {
        private static int _idCounter = 0;

        public int Id { get; init; }
        public string Name { get; set; }
        public int Age { get; set; }
        
        public Person()
        {
            Id = _idCounter++;
        }
    }
}
