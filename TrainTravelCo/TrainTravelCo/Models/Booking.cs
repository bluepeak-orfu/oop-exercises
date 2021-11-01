using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTravelCo.Models
{
    public class Booking
    {
        public Customer Customer { get; init; }
        public Trip Trip { get; init; }
    }
}
