using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOArvExercises
{
    class Chair : IMovable
    {
        public void Move(int x, int y)
        {
            Console.WriteLine($"En stol flyttas till ({x}, {y})");
        }
    }
}
