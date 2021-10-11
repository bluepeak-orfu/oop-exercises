namespace TheMagicFactory
{
    public abstract class InventoryItem
    {
        protected InventoryItem(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
    }
}