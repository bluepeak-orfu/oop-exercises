using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.Models;

namespace TrainTravelCo.Data
{
    public abstract class DataStore
    {
        private static DataStore _instance;
        public static DataStoreType Type { get; set; }

        public static DataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (Type == DataStoreType.MultiFile)
                    {
                        _instance = new MultiFileDataStore();
                    }
                    else
                    {
                        Console.WriteLine("Unsupported data type format");
                    }
                }
                return _instance;
            }
        }

        private List<Trip> _trips;

        protected DataStore()
        {
            _trips = new List<Trip>();

            if (!Directory.Exists("application-data"))
            {
                Directory.CreateDirectory("application-data");
            }
        }

        public abstract List<Train> ListTrains();

        public abstract Train GetTrain(int trainId);

        public abstract void SaveTrain(Train train);

        public abstract List<Trip> ListTrips();

        public abstract void SaveTrip(Trip trip);
    }
}
