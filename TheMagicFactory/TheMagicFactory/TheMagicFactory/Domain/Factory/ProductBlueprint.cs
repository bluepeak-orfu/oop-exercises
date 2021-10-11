using System.Collections.Generic;
using System.Linq;

namespace TheMagicFactory
{
    public class ProductBlueprint
    {
        public Dictionary<string, int> ItemsToCheck { get; private set; }

        public List<InventoryItem> ItemsToProduce { get; private set; }

        public string Name { get; protected set; }

        public ProductBlueprint(List<InventoryItem> items, string name)
        {
            Name = name;

            ItemsToProduce = items;

            ItemsToCheck = new Dictionary<string, int>();

            foreach (InventoryItem item in items)
            {
                if (ItemsToCheck.ContainsKey(item.Name))
                {
                    ItemsToCheck[item.Name] += 1;
                }
                else
                {
                    ItemsToCheck.Add(item.Name, 1);
                }
            }
        }

        public bool IsComponentsFit(List<InventoryItem> items)
        {
            bool isEnough = false;

            foreach (var entry in ItemsToCheck)
            {
                isEnough = entry.Value <= items.Count(m => m.Name.Contains(entry.Key));
            }

            return isEnough;
        }
    }
}