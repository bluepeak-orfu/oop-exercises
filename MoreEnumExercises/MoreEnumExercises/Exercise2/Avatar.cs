using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreEnumExercises.Exercise2
{
    class Avatar
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public string CurrentPosition
        {
            get
            {
                return $"({X}, {Y})";
            }
        }

        public Avatar()
        {
            X = 50;
            Y = 50;
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "north":
                    Y--;
                    break;
                case "east":
                    X++;
                    break;
                case "south":
                    Y++;
                    break;
                case "west":
                    X--;
                    break;
                default:
                    Console.WriteLine("I don't know about that direction");
                    break;
            }
        }
    }
}
