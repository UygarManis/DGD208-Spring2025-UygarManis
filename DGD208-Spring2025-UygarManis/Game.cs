using System;
using DGD208_Spring2025_UygarManis.Database;
using DGD208_Spring2025_UygarManis.Enums;

namespace DGD208_Spring2025_UygarManis
{
    public class Game
    {
        private PetManager petManager = new PetManager();
        private ItemManager itemManager = new ItemManager();
        private bool isRunning = true;

        public void Start()
        {
            Console.WriteLine("Pet Simulator'a hoş geldiniz!");

            while (isRunning)
            {
                Menu.ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdoptPet();
                        break;
                    case "2":
                        petManager.ShowAllPets();
                        break;
                    case "3":
                        UseItem();
                        break;
                    case "4":
                        ShowCreatorInfo();
                        break;
                    case "5":
                        ExitGame();
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        private void AdoptPet()
        {
            Console.Write("Evcil hayvan adı girin: ");
            string name = Console.ReadLine();

            Console.WriteLine("Evcil hayvan tipi seçin:");
            foreach (var type in Enum.GetValues(typeof(PetType)))
            {
                Console.WriteLine($"- {type}");
            }

            string typeInput = Console.ReadLine();
            if (Enum.TryParse(typeInput, true, out PetType petType))
            {
                petManager.AdoptPet(name, petType);
            }
            else
            {
                Console.WriteLine("Geçersiz hayvan tipi.");
            }
        }

        private async void UseItem()
        {
            petManager.ShowAllPets();
            Console.Write("Item kullanmak istediğiniz hayvanın adını girin: ");
            string petName = Console.ReadLine();
            var pet = petManager.GetPetByName(petName);

            if (pet == null)
            {
                Console.WriteLine("Böyle bir hayvan bulunamadı.");
                return;
            }

            itemManager.ShowAvailableItems();
            Console.Write("Kullanmak istediğiniz item adını yazın: ");
            string itemName = Console.ReadLine();
            var item = ItemDatabase.GetAllItems().Find(i => i.name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                Console.WriteLine("Böyle bir item bulunamadı.");
                return;
            }

            await itemManager.UseItemAsync(pet, item);
        }

        private void ShowCreatorInfo()
        {
            Console.WriteLine("\n--- Proje Sahibi ---");
            Console.WriteLine("Uygar Manis - Öğrenci No: 12345678");
        }

        private void ExitGame()
        {
            isRunning = false;
            Console.WriteLine("Oyun kapatılıyor...");
        }
    }
}
