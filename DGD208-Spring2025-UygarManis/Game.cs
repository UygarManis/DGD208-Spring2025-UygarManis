using System;
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
            Console.WriteLine("\n\nPet Simulator'a hoş geldiniz!\n");

            while (isRunning)
            {
                Menu.ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        AdoptPet();
                        break;
                    case "2":
                        Console.WriteLine();
                        petManager.ShowAllPets();
                        break;
                    case "3":
                        Console.WriteLine();
                        UseItem();
                        break;
                    case "4":
                        Console.WriteLine();
                        ShowCreatorInfo();
                        break;
                    case "5":
                        ExitGame();
                        break;
                    default:
                        Console.WriteLine("\nGeçersiz seçim. Lütfen tekrar deneyin.\n");
                        break;
                }
            }
        }

        private void AdoptPet()
        {
            var petTypes = Enum.GetValues(typeof(PetType));
            int index = 1;

            Console.WriteLine("\nEvcil hayvan tipi seçin:\n");
            foreach (var type in petTypes)
            {
                Console.WriteLine($"{index}. {type}");
                index++;
            }

            Console.Write("\nSeçiminiz (1-4): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= petTypes.Length)
            {
                PetType selectedType = (PetType)petTypes.GetValue(choice - 1);

                Console.Write("\nEvcil hayvanınıza vermek istediğiniz ismi yazın: ");
                string name = Console.ReadLine();

                petManager.AdoptPet(name, selectedType);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nGeçersiz seçim.\n");
            }
        }

        private async void UseItem()
        {
            petManager.ShowAllPets();
            Console.Write("\nItem kullanmak istediğiniz hayvanın adını girin: ");
            string petName = Console.ReadLine();
            var pet = petManager.GetPetByName(petName);

            if (pet == null)
            {
                Console.WriteLine("\nBöyle bir hayvan bulunamadı.\n");
                return;
            }

            itemManager.ShowAvailableItems();
            Console.Write("\nKullanmak istediğiniz item adını yazın: ");
            string itemName = Console.ReadLine();
            var item = Database.ItemDatabase.GetAllItems().Find(i => i.name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                Console.WriteLine("\nBöyle bir item bulunamadı.\n");
                return;
            }

            await itemManager.UseItemAsync(pet, item);
            Console.WriteLine();
        }

        private void ShowCreatorInfo()
        {
            Console.WriteLine("\n--- Proje Sahibi ---");
            Console.WriteLine("Uygar Manis - Öğrenci No: 225040059\n");
        }

        private void ExitGame()
        {
            isRunning = false;
            Console.WriteLine("\nOyun kapatılıyor...\n");
        }
    }
}
