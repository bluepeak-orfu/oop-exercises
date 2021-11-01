using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTravelCo.Models
{
    public class Train
    {
        private static int _idCounter = 0;

        public string RegNumber { get; init; }
        public int MaxSeats { get; init; }
        public int Id { get; init; }

        public Train()
        {
            Id = _idCounter++;
        }
    }
}
