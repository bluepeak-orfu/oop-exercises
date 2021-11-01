using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTravelCo.DTOs
{
    public class TripDTO
    {
        public string Start { get; init; }
        public string Destination { get; init; }
        public string DepartureTime { get; init; }
        public int TrainId { get; init; }
    }
}
