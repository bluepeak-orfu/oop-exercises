using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOArvExercises
{
    class MyDerivedClass1 : MyBaseClass
    {
        public MyDerivedClass1() : base(12.3)
        {
            _x = 5;
        }

        public void DerivedMessage()
        {
            Console.WriteLine("hej");
        }
    }
}
