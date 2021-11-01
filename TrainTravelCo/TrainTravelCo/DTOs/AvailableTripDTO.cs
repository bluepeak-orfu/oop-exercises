using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.Models;

namespace TrainTravelCo.DTOs
{
    public class AvailableTripDTO
    {
        public string From { get; init; }
        public string To { get; init; }
        public string Time { get; init; }
        public int TrainId { get; init; }
        public List<Customer> Customers { get; init; }
        public int Id { get; init; }
    }
}
