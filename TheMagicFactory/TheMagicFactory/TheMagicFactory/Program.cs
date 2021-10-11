using System;
using System.Collections.Generic;

namespace TheMagicFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("It`s a start");

            bool programIsActive = true;
            var warehouse = new Warehouse();
            var factory = new Factory();

            while (programIsActive)
            {
                warehouse.ListInventory();

                Console.WriteLine("Lets sent stock from Warehouse to Factory");

                List<InventoryItem> itemsToTransfer = warehouse.TransferAllItems();

                factory.AddItems(itemsToTransfer);

                factory.ListInventory();
                
                List<InventoryItem> leftovers = factory.RunFactoryAndReturnLeftovers();

                warehouse.AddItems(leftovers);
                warehouse.ListInventory();

                Console.ReadLine();

                // End
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    programIsActive = false;
                }
            }
        }
    }
}
