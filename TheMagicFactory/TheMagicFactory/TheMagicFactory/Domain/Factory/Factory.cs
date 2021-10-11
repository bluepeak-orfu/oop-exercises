using System.Collections.Generic;
using System.Linq;

namespace TheMagicFactory
{
    public class Factory : StoragePlace
    {
        protected List<ProductBlueprint> ProductBlueprintList;

        public Factory()
        {
            var steelMaterial = new Material("Steel");
            var wheelProduct = new Product("Wheel");

            ProductBlueprint wheelBluePrint = new ProductBlueprint(new List<InventoryItem>
            {
                steelMaterial,
                new Material("Rubber")
            }, "Wheel");

            ProductBlueprintList = new List<ProductBlueprint>
            {
                wheelBluePrint,
                new ProductBlueprint(new List<InventoryItem>
                {
                    steelMaterial,
                    steelMaterial,
                    wheelProduct,
                    wheelProduct,
                    wheelProduct,
                    wheelProduct
                }, "Car"),
            };
        }

        public List<InventoryItem> RunFactoryAndReturnLeftovers()
        {
            var blueprintsByComplexity = ProductBlueprintList.OrderByDescending(x => x.ItemsToCheck.Count);

            foreach (var blueprint in blueprintsByComplexity)
            {
                while (blueprint.ItemsToProduce.Count() <= CountExistingInventory() && blueprint.IsComponentsFit(Items))
                {
                    RemoveItems(blueprint.ItemsToProduce);
                    Items.Add(new Product(blueprint.Name));
                }
            }

            List<InventoryItem> itemsToReturn = Items.ToList();
            RemoveItems(itemsToReturn);

            return itemsToReturn;
        }
    }
}