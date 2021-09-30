using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOGrunderExercises
{
    class Coordinate
    {
        public int X
        {
            get;
        }

        public int Y
        {
            get;
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate MoveLeft()
        {
            return new Coordinate(X - 1, Y);
        }

        public Coordinate MoveRight()
        {
            return new Coordinate(X + 1, Y);
        }
    }
}
