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
                int maxCapacity = trip.Train.MaxSeats;
                int currentBookingCount = trip.Bookings.Count;
                if (trip.From == from && currentBookingCount < maxCapacity)
                {
                    result.Add(trip);
                }
            }
            return result;
        }

        public void BookTrip(int tripId, string customerName, string customerPhone)
        {
            Customer customer = new Customer()
            {
                Name = customerName,
                Phone = customerPhone
            };
            Trip trip = GetTrip(tripId);

            int maxCapacity = trip.Train.MaxSeats;
            int currentBookingCount = trip.Bookings.Count;
            if (currentBookingCount == maxCapacity)
            {
                throw new Exception("Trip already fully booked");
            }

            Booking booking = new Booking()
            {
                Customer = customer,
                Trip = trip
            };

            trip.Bookings.Add(booking);
        }

        private Trip GetTrip(int tripId)
        {
            List<Trip> allTrips = DataStore.Instance.ListTrips();
            foreach (Trip trip in allTrips)
            {
                if (trip.Id == tripId)
                {
                    return trip;
                }
            }
            throw new Exception($"No trip found for Id {tripId}");
        }
    }
}
