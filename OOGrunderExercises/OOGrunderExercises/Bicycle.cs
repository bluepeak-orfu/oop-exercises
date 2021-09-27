using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOGrunderExercises
{
    class Bicycle
    {
        private int _age;
        private int _currentGear;

        public Bicycle(int age, int currentGear)
        {
            _age = age;
            _currentGear = currentGear;
        }

        public Bicycle(int age) : this(age, 1)
        {
        }

        public Bicycle() : this(0)
        {
        }
    }
}
