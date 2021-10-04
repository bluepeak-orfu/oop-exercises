using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOArvExercises
{
    class MyDerivedClass2 : MyBaseClass
    {
        public MyDerivedClass2(double y) : base(y)
        {
            _x = 8;
        }
    }
}
