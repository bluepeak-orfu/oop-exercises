using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.Data;
using TrainTravelCo.Models;

namespace TrainTravelCo.Managers
{
    public class TrainManager
    {
        public List<Train> List()
        {
            return DataStore.Instance.ListTrains();
        }

        public Train Save(Train train)
        {
            DataStore.Instance.SaveTrain(train);
            return train;
        }
    }
}
