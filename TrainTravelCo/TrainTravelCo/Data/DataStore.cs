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

            Train train1 = new Train() { MaxSeats = 10, RegNumber = "ABC" };
            Train train2 = new Train() { MaxSeats = 12, RegNumber = "DEF" };
            SaveTrain(train1);
            SaveTrain(train2);
            Trip trip1 = new Trip()
            {
                From = "A",
                To = "B",
                Time = "2021-01-01",
                Train = train1
            };
            Trip trip2 = new Trip()
            {
                From = "A",
                To = "C",
                Time = "2021-11-01",
                Train = train1
            };
            Trip trip3 = new Trip()
            {
                From = "B",
                To = "C",
                Time = "2021-01-07",
                Train = train2
            };
            SaveTrip(trip1);
            SaveTrip(trip2);
            SaveTrip(trip3);
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
