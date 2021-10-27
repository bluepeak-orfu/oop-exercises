using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMappings.Managers
{
    public class PersonManager
    {
        private static PersonManager _instance;

        public static PersonManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PersonManager();
                }
                return _instance;
            }
        }


        private List<Person> _persons;

        private PersonManager()
        {
            _persons = new List<Person>();
        }

        public List<Person> List()
        {
            return _persons;
        }

        public bool Create(Person person)
        {
            _persons.Add(person);
            return true;
        }

        public Person Get(int personId)
        {
            foreach (Person person in _persons)
            {
                if (person.Id == personId)
                {
                    return person;
                }
            }
            return null;
        }
    }
}
