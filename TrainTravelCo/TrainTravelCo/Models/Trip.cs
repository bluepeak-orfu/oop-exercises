using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTravelCo.Models
{
    public class Trip
    {
        private static int _idCounter = 0;

        public string From { get; init; }
        public string To { get; init; }
        public string Time { get; init; }
        public Train Train { get; init; }
        public List<Booking> Bookings { get; init; }
        public int Id { get; init; }

        public Trip()
        {
            Id = _idCounter++;
            Bookings = new List<Booking>();
        }

        public Trip(int id)
        {
            Id = id;
            Bookings = new List<Booking>();
        }

    }
}
