using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOGrunderExercises
{
    class Person
    {
        private string _name;
        private int _age;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 100)
                {
                    value = 100;
                }
                else if (value < 1)
                {
                    value = 1;
                }

                _age = value;
            }
        }

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public void SetAge(int newAge)
        {
            if (newAge > 100)
            {
                newAge = 100;
            }
            else if (newAge < 1)
            {
                newAge = 1;
            }

            _age = newAge;

            //if (newAge > 100)
            //{
            //    _age = 100;
            //}
            //else if (newAge < 1)
            //{
            //    _age = 1;
            //}
            //else
            //{
            //    _age = newAge;
            //}
        }

        public int GetAge()
        {
            return _age;
        }
    }
}
