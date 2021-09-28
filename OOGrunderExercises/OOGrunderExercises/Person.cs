﻿using System;
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
