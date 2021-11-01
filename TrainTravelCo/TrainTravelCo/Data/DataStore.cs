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

        private DataStore()
        {
            _trains = new List<Train>();
        }

        public List<Train> ListTrains()
        {
            return _trains;
        }

        public void SaveTrain(Train train)
        {
            _trains.Add(train);
        }
    }
}
