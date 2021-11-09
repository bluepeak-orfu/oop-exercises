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
    [Route("booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingManager _bookingManager;

        public BookingController()
        {
            _bookingManager = new BookingManager();
        }

        [HttpGet]
        public List<AvailableTripDTO> Search(string from)
        {
            List<Trip> trips = _bookingManager.Search(from);
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
                    Id = trip.Id,
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
        public void BookTrip(BookTripDTO bookTripDto)
        {
            int tripId = bookTripDto.TripId;
            string customerName = bookTripDto.CustomerName;
            string customerPhone = bookTripDto.CustomerPhone;

            _bookingManager.BookTrip(tripId, customerName, customerPhone);
        }
    }
}
