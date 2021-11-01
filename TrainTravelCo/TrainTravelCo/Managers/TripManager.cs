using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.Models;
using TrainTravelCo.Data;

namespace TrainTravelCo.Managers
{
    public class TripManager
    {
        public List<Trip> ListTrips()
        {
            return DataStore.Instance.ListTrips();
        }

        public Trip CreateTrip(string start, string destination, string departureTime, int trainId)
        {
            Train train = GetTrain(trainId);

            Trip trip = new Trip()
            {
                From = start,
                To = destination,
                Time = departureTime,
                Train = train
            };
            DataStore.Instance.SaveTrip(trip);
            return trip;
        }

        private Train GetTrain(int trainId)
        {
            Train train = null;
            List<Train> allTrains = DataStore.Instance.ListTrains();
            foreach (Train aTrain in allTrains)
            {
                if (aTrain.Id == trainId)
                {
                    train = aTrain;
                    break;
                }
            }
            if (train == null)
            {
                throw new Exception($"Train not found for Id {trainId}");
            }
            return train;
        }
    }
}
