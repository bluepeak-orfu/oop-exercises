using System;

namespace TheMagicFactory
{
    public class Product : InventoryItem
    {
        public string SerialNumber { get; private set; }

        public Product(string name) : base(name)
        {
            SerialNumber = new Guid().ToString();
        }
    }
}