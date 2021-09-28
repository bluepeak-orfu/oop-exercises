using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOGrunderExercises
{
    class Additor
    {
        private int _value1;
        private int _value2;

        public Additor(int value1, int value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        public int Add()
        {
            return _value1 + _value2;
        }
    }
}
