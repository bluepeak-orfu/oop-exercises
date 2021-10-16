using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreEnumExercises.Exercise1
{
    class StovePlate
    {
        public string Hotness { get; private set; }

        public StovePlate()
        {
            Hotness = "none";
        }

        public void IncreaseHeat()
        {
            if (Hotness == "none")
            {
                Hotness = "low";
            }
            else if (Hotness == "low")
            {
                Hotness = "high";
            }
            else
            {
                Console.WriteLine("At max heat");
            }
        }

        public void DecreaseHeat()
        {
            /* Vi använder en switch här för att ge er en chans att öva
             * både på if- och switch-syntax. I normala fall hade vi
             * förmodligen använt samma lösning för increase och decrease.
             */
            switch (Hotness)
            {
                case "high":
                    Hotness = "low";
                    break;
                case "low":
                    Hotness = "none";
                    break;
                default:
                    Console.WriteLine("Heat already off");
                    break;
            }
        }
    }
}
