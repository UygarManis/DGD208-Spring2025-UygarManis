using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGD208_Spring2025_UygarManis.Enums;
using DGD208_Spring2025_UygarManis.Database;

namespace DGD208_Spring2025_UygarManis
{
    public class ItemManager
    {
        private List<Item> items = ItemDatabase.GetAllItems();

        public void ShowAvailableItems()
        {
            Console.WriteLine("Kullanılabilir item'lar:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.name} ({item.itemType}) | Etki: {item.effectAmount} | Süre: {item.duration}ms");
            }
        }

        public List<Item> GetItemsByType(ItemType type)
        {
            return items.Where(i => i.itemType == type).ToList();
        }

        public async Task UseItemAsync(Pet pet, Item item)
        {
            Console.WriteLine($"{item.name} kullanılıyor... Lütfen bekleyin...");
            await Task.Delay(item.duration); // Item kullanım süresi kadar bekle

            switch (item.itemType)
            {
                case ItemType.Food:
                    pet.Feed(item.effectAmount);
                    break;
                case ItemType.Toy:
                    pet.Play(item.effectAmount);
                    break;
                case ItemType.Medicine:
                    pet.Rest(item.effectAmount);
                    break;
            }

            Console.WriteLine($"{item.name} başarıyla kullanıldı.");
        }
    }
}
