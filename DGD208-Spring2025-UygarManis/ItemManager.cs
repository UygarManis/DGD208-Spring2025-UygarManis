using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGD208_Spring2025_UygarManis.Database;
using DGD208_Spring2025_UygarManis.Enums;

namespace DGD208_Spring2025_UygarManis
{
    public class ItemManager
    {
        private List<Item> items = ItemDatabase.GetAllItems();

        public List<Item> Items => items;

        public void ShowAvailableItems()
        {
            Console.WriteLine("\nAvailable items:");

            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                Console.WriteLine($"{i + 1}. {item.name} - Type: {item.itemType}, Effect: {item.effectAmount}, Duration: {item.duration}ms");
            }

            Console.WriteLine();
        }

        public async Task UseItemAsync(Pet pet, Item item)
        {
            Console.WriteLine($"\nUsing {item.name}...");
            await Task.Delay(item.duration);

            switch (item.itemType)
            {
                case ItemType.Food:
                    pet.Feed(item.effectAmount);
                    break;
                case ItemType.Medicine:
                    pet.Heal(item.effectAmount);
                    break;
                case ItemType.Bed:
                    pet.Rest(item.effectAmount);
                    break;
                case ItemType.Toy:
                    pet.Play(item.effectAmount);
                    break;
            }

            Console.WriteLine($"{item.name} successfully used!\n");
        }

        public List<Item> GetItemsByType(ItemType type)
        {
            return items.Where(i => i.itemType == type).ToList();
        }
    }
}
