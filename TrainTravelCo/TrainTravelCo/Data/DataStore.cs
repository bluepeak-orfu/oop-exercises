using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.Models;

namespace TrainTravelCo.Data
{
    public class DataStore
    {
        private static DataStore _instance;

        public static DataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataStore();
                }
                return _instance;
            }
        }

        private List<Train> _trains;
        private List<Trip> _trips;

        private DataStore()
        {
            _trains = new List<Train>();
            _trips = new List<Trip>();
        }

        public List<Train> ListTrains()
        {
            return _trains;
        }

        public void SaveTrain(Train train)
        {
            _trains.Add(train);
        }

        public List<Trip> ListTrips()
        {
            return _trips;
        }

        public void SaveTrip(Trip trip)
        {
            _trips.Add(trip);
        }
    }
}
