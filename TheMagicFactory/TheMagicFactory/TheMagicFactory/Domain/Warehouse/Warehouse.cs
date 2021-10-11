using System.Collections.Generic;

namespace TheMagicFactory
{
    public class Warehouse : StoragePlace
    {
        public Warehouse()
        {
            Items = new List<InventoryItem>
            {
                new Material("Iron"),
                new Material("Iron"),
                new Material("Rubber"),
                new Material("Rubber"),
                new Material("Rubber"),
                new Material("Rubber"),
                new Material("Steel"),
                new Material("Steel"),
                new Material("Steel"),
                new Material("Steel"),
                new Material("Steel")
            };
        }
    }
}