using System.Collections.Generic;

namespace DGD208_Spring2025_UygarManis.Database
{
    public static class ItemDatabase
    {
        public static List<Item> GetAllItems()
        {
            return new List<Item>
            {
                new Item("Köpek Maması", Enums.ItemType.Food, 20, 2000),
                new Item("Kedi Oyuncağı", Enums.ItemType.Toy, 15, 1500),
                new Item("Şifalı Bitki", Enums.ItemType.Medicine, 10, 3000),
                new Item("Havuç", Enums.ItemType.Food, 10, 1000),
                new Item("Top", Enums.ItemType.Toy, 10, 1200),
                new Item("Kuduz Aşısı", Enums.ItemType.Medicine,25, 8000),
               
            };
        }
    }
}
