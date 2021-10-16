using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreEnumExercises.Exercise3
{
    class TrafficLight
    {
        private string _lastStatus;
        public string Status { get; private set; }

        public TrafficLight()
        {
            _lastStatus = "yellow";
            Status = "red";
        }

        public void NextStatus()
        {
            if (Status == "red" || Status == "green")
            {
                _lastStatus = Status;
                Status = "yellow";
            }
            else if (Status == "yellow")
            {
                if (_lastStatus == "red")
                {
                    Status = "green";
                }
                else if (_lastStatus == "green")
                {
                    Status = "red";
                }
                else
                {
                    Console.WriteLine($"ERROR: unknown last status: {_lastStatus}");
                }
                _lastStatus = "yellow";
            }
            else
            {
                Console.WriteLine($"ERROR: unknown status: {Status}");
            }
        }
    }
}
