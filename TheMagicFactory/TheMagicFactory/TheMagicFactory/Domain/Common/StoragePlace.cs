using System;
using System.Collections.Generic;
using System.Linq;

namespace TheMagicFactory
{
    public abstract class StoragePlace
    {
        protected List<InventoryItem> Items;

        protected StoragePlace()
        {
            Items = new List<InventoryItem>();
        }

        public void AddItems(List<InventoryItem> items)
        {
            Items.AddRange(items);
        }

        public void RemoveItem(InventoryItem item)
        {
            int count = Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (Items[i].Name == item.Name)
                {
                    Items.RemoveAt(i);
                    return;
                }
            }
        }
        
        public void RemoveItems(List<InventoryItem> items)
        {
            foreach (InventoryItem item in items)
            {
                RemoveItem(item);
            }
        }
        
        public List<InventoryItem> TransferAllItems()
        {
            List<InventoryItem> itemsToTransfer = Items.ToList();
            Items.Clear();

            return itemsToTransfer;
        }
        
        public int CountExistingInventory()
        {
            return Items.Count;
        }

        public void ListInventory()
        {
            Console.WriteLine($"--- Current {this.GetType().Name} inventory ---");

            foreach (InventoryItem item in Items)
            {
                Console.WriteLine($"{item.Name}");
            }

            Console.WriteLine($"--- End ---");
        }
    }
}