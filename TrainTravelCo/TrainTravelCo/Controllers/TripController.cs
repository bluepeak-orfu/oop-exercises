using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.DTOs;
using TrainTravelCo.Managers;
using TrainTravelCo.Models;

namespace TrainTravelCo.Controllers
{
    [Route("trip")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private TripManager _tripManager;

        public TripController()
        {
            _tripManager = new TripManager();
        }

        [HttpGet]
        public List<AvailableTripDTO> GetTrips()
        {
            List<Trip> trips = _tripManager.ListTrips();
            List<AvailableTripDTO> result = new List<AvailableTripDTO>();
            foreach (Trip trip in trips)
            {
                List<Customer> customers = new List<Customer>();
                foreach (Booking booking in trip.Bookings)
                {
                    customers.Add(booking.Customer);
                }
                AvailableTripDTO tripDto = new AvailableTripDTO()
                {
                    From = trip.From,
                    To = trip.To,
                    Time = trip.Time,
                    TrainId = trip.Train.Id,
                    Customers = customers
                };
                result.Add(tripDto);
            }
            return result;
        }

        [HttpPost]
        public Trip CreateTrip(TripDTO tripDto)
        {
            string from = tripDto.Start;
            string destination = tripDto.Destination;
            string departureTime = tripDto.DepartureTime;
            int trainId = tripDto.TrainId;
            Trip trip = _tripManager.CreateTrip(from, destination, departureTime, trainId);
            return trip;
        }
    }
}
