using System;
using System.Collections.Generic;
using System.IO;
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

        private List<Trip> _trips;

        private DataStore()
        {
            _trips = new List<Trip>();

            if (!Directory.Exists("application-data"))
            {
                Directory.CreateDirectory("application-data");
            }
        }

        public List<Train> ListTrains()
        {
            List<Train> result = new List<Train>();
            string[] files = Directory.GetFiles("application-data");
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName.StartsWith("train_"))
                {
                    string[] data = File.ReadAllLines(file);
                    string idString = data[0];
                    string regNumber = data[1];
                    string maxSeatsString = data[2];
                    int id = Convert.ToInt32(idString);
                    int maxSeats = Convert.ToInt32(maxSeatsString);
                    Train train = new Train(id)
                    {
                        RegNumber = regNumber,
                        MaxSeats = maxSeats
                    };
                    result.Add(train);
                }
            }
            return result;
        }

        public Train GetTrain(int trainId)
        {
            string fileName = $"application-data/train_{trainId}.txt";
            string[] data = File.ReadAllLines(fileName);
            string idString = data[0];
            string regNumber = data[1];
            string maxSeatsString = data[2];
            int id = Convert.ToInt32(idString);
            int maxSeats = Convert.ToInt32(maxSeatsString);
            Train train = new Train(id)
            {
                RegNumber = regNumber,
                MaxSeats = maxSeats
            };
            return train;
        }

        public void SaveTrain(Train train)
        {
            int trainId = train.Id;
            string fileName = $"application-data/train_{trainId}.txt";
            string[] data = new string[]
            {
                trainId.ToString(),
                train.RegNumber,
                train.MaxSeats.ToString()
            };
            File.WriteAllLines(fileName, data);
        }

        public List<Trip> ListTrips()
        {
            List<Trip> result = new List<Trip>();
            string[] files = Directory.GetFiles("application-data");
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName.StartsWith("trip_"))
                {
                    FileStream fileStream = File.OpenRead(file);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        int id = Convert.ToInt32(reader.ReadLine());
                        string from = reader.ReadLine();
                        string to = reader.ReadLine();
                        string time = reader.ReadLine();
                        int trainId = Convert.ToInt32(reader.ReadLine());
                        Train train = GetTrain(trainId);

                        Trip trip = new Trip(id)
                        {
                            From = from,
                            To = to,
                            Time = time,
                            Train = train
                        };
                        result.Add(trip);

                        while (!reader.EndOfStream)
                        {
                            string customerName = reader.ReadLine();
                            string customerPhone = reader.ReadLine();
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

        public void SaveTrip(Trip trip)
        {
            int tripid = trip.Id;
            string fileName = $"application-data/trip_{tripid}.txt";
            FileStream fileStream = File.Create(fileName);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine(trip.Id);
                writer.WriteLine(trip.From);
                writer.WriteLine(trip.To);
                writer.WriteLine(trip.Time);

                writer.WriteLine(trip.Train.Id);

                foreach (Booking booking in trip.Bookings)
                {
                    writer.WriteLine(booking.Customer.Name);
                    writer.WriteLine(booking.Customer.Phone);
                }
            }
        }
    }
}
