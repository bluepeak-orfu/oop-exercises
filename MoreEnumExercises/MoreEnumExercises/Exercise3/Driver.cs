using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreEnumExercises.Exercise3
{
    class Driver
    {
        private TrafficLight _trafficLight;

        public Driver(TrafficLight trafficLight)
        {
            _trafficLight = trafficLight;
        }

        public bool CanGo()
        {
            if (_trafficLight.Status == "green")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
