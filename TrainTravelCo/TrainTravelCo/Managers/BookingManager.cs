using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.Data;
using TrainTravelCo.Models;

namespace TrainTravelCo.Managers
{
    public class BookingManager
    {
        public List<Trip> Search(string from)
        {
            List<Trip> result = new List<Trip>();
            List<Trip> allTrips = DataStore.Instance.ListTrips();
            foreach (Trip trip in allTrips)
            {
                if (trip.From == from)
                {
                    result.Add(trip);
                }
            }
            return result;
        }
    }
}
