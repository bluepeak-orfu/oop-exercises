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
        public List<Trip> Search(string from)
        {
            return _bookingManager.Search(from);
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
