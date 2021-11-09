using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.Models;

namespace TrainTravelCo.Data
{
    public class SingleFileDataStore : DataStore
    {
        public SingleFileDataStore()
        {
            if (!Directory.Exists("single-file-data"))
            {
                Directory.CreateDirectory("single-file-data");
            }
        }

        public override Train GetTrain(int trainId)
        {
            string trainRowStart = $"{trainId},";
            string[] rows = File.ReadAllLines("single-file-data/trains.txt");
            foreach (string row in rows)
            {
                if (row.StartsWith(trainRowStart))
                {
                    string[] parts = row.Split(",");
                    int id = Convert.ToInt32(parts[0]);
                    string regNumber = parts[1];
                    int maxSeats = Convert.ToInt32(parts[2]);
                    Train train = new Train(id)
                    {
                        RegNumber = regNumber,
                        MaxSeats = maxSeats
                    };
                    return train;
                }
            }
            return null;
        }

        public override List<Train> ListTrains()
        {
            List<Train> result = new List<Train>();
            string[] input = File.ReadAllLines("single-file-data/trains.txt");
            foreach (string row in input)
            {
                if (row == "")
                {
                    continue;
                }

                string[] parts = row.Split(",");
                int id = Convert.ToInt32(parts[0]);
                string regNumber = parts[1];
                int maxSeats = Convert.ToInt32(parts[2]);
                Train train = new Train(id)
                {
                    RegNumber = regNumber,
                    MaxSeats = maxSeats
                };
                result.Add(train);
            }
            return result;
        }

        public override List<Trip> ListTrips()
        {
            List<Trip> result = new List<Trip>();
            string[] input = File.ReadAllLines("single-file-data/trips.txt");
            foreach (string row in input)
            {
                if (row != "")
                {
                    string[] parts = row.Split(",");
                    int id = Convert.ToInt32(parts[0]);
                    string from = parts[1];
                    string to = parts[2];
                    string time = parts[3];
                    int trainId = Convert.ToInt32(parts[4]);
                    Train train = GetTrain(trainId);
                    Trip trip = new Trip(id)
                    {
                        From = from,
                        To = to,
                        Time = time,
                        Train = train
                    };
                    result.Add(trip);

                    string bookinsData = parts[5];
                    if (bookinsData != "")
                    {
                        string[] bookingParts = bookinsData.Split("|");
                        foreach (string bookingPart in bookingParts)
                        {
                            string[] customerParts = bookingPart.Split("&");
                            string customerName = customerParts[0];
                            string customerPhone = customerParts[1];
                            Customer customer = new Customer()
                            {
                                Name = customerName,
                                Phone = customerPhone
                            };
                            Booking booking = new Booking()
                            {
                                Trip = trip,
                                Customer = customer
                            };
                            trip.Bookings.Add(booking);
                        }
                    }
                }
            }

            return result;
        }

        public override void SaveTrain(Train train)
        {
            string output = $"{train.Id},{train.RegNumber},{train.MaxSeats}" + Environment.NewLine;
            File.AppendAllText("single-file-data/trains.txt", output);
        }

        public override void SaveTrip(Trip trip)
        {
            string tripRowStart = $"{trip.Id},";
            List<string> rows = File.ReadAllLines("single-file-data/trips.txt").ToList();
            bool tripExists = false;
            for(int i = 0; i < rows.Count; i++)
            {
                if (rows[i].StartsWith(tripRowStart))
                {
                    rows[i] = TripToString(trip);
                    tripExists = true;
                    break;
                }
            }
            if (!tripExists)
            {
                string output = TripToString(trip);
                rows.Add(output);
            }
            File.WriteAllLines("single-file-data/trips.txt", rows);
        }

        private string TripToString(Trip trip)
        {
            string bookingsOutput = "";
            foreach (Booking booking in trip.Bookings)
            {
                string bookingOutput = $"{booking.Customer.Name}&{booking.Customer.Phone}";
                if (bookingsOutput == "")
                {
                    bookingsOutput += $"{bookingOutput}";
                }
                else
                {
                    bookingsOutput += $"|{bookingOutput}";
                }
            }
            return $"{trip.Id},{trip.From},{trip.To},{trip.Time},{trip.Train.Id},{bookingsOutput}";
        }
    }
}
