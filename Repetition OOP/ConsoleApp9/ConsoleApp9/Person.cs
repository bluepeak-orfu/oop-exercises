using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Person
    {
        public int Speed { get; set; }

        public Backpack Backpack { get; set; }

        public Person()
        {
            Backpack = new Backpack();
            Speed = 10;
        }

        public Person(Backpack backpack)
        {
            Backpack = backpack;
            Speed = 10;
        } 
        public void Run()
        {
            Console.WriteLine("The person runs at " + Speed + "km/h");

        }

        public void LookInBag()
        {
            Console.Write("The person looks in the " + Backpack.BackpackBrand + " ");
            Console.Write("and sees ");
            for (int i = 0; i < Backpack.Snacks.Length; i++)
            {
                Console.Write(Backpack.Snacks[i]);
            }
        }
    }
}
