using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOArvExercises
{
    class FriendlyGreeter : Greeter
    {
        public override void SayHello()
        {
            Console.WriteLine("Hello! How are you?");
        }
    }
}
