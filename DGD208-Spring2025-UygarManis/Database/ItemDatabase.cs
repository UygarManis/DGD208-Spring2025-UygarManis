using System.Collections.Generic;

namespace DGD208_Spring2025_UygarManis.Database
{
    public static class ItemDatabase
    {
        public static List<Item> GetAllItems()
        {
            return new List<Item>
            {
                new Item("Dog Chow", Enums.ItemType.Food, 20, 2000),
                new Item("Cat Toy", Enums.ItemType.Toy, 15, 1500),
                new Item("Healing Herb", Enums.ItemType.Medicine, 10, 3000),
                new Item("Carrot", Enums.ItemType.Food, 10, 1000),
                new Item("Ball", Enums.ItemType.Toy, 10, 1200),
                new Item("Sleeping Pill", Enums.ItemType.Bed, 5, 1000),
                new Item("Feather Bed", Enums.ItemType.Bed, 25, 8000),
                new Item("Rabies Vaccine", Enums.ItemType.Medicine, 25, 8000),
                new Item("Girls Night", Enums.ItemType.Toy, 30, 9000),
            };
        }
    }
}
