using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOArvExercises
{
    class MyBaseClass
    {
        protected int _x;
        private double _y;

        public MyBaseClass(double y)
        {
            _y = y;
        }

        public void BaseAdd()
        {
            double result = _x + _y;
            Console.WriteLine(result);
        }
    }
}
