using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Backpack
    {
        public string[] Snacks { get; set; } 
        public string BackpackBrand { get; set; }

        public Backpack(string brandName)
        {
            BackpackBrand = brandName;
            Snacks = new string[] { "Cake", "Sandwich", "Chips" };
        }

        public Backpack()
        {
            BackpackBrand = "Fjällräven";
            Snacks = new string[] { "Cake", "Sandwich", "Chips" };
        }
    }
}
