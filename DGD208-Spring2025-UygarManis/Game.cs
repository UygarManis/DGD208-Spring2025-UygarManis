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
            Console.Write("\nKullanmak istediğiniz item numarasını girin: ");
            if (!int.TryParse(Console.ReadLine(), out int itemChoice) || itemChoice < 1 || itemChoice > itemManager.Items.Count)
            {
                Console.WriteLine("\nGeçersiz seçim.\n");
                return;
            }

            var item = itemManager.Items[itemChoice - 1];
            await itemManager.UseItemAsync(pet, item);
            Console.WriteLine();
        }

        private void ShowCreatorInfo()
        {
            Console.WriteLine("\n--- Proje Sahibi ---");
            Console.WriteLine("Uygar Manis - Öğrenci No: 225040059\n - ChatGPT");
        }

        private void ExitGame()
        {
            Console.Write("\nAre you sure you want to exit? (y/n): ");
            string response = Console.ReadLine().ToLower();

            if (response == "y")
            {
                isRunning = false;
                Console.WriteLine("\nExiting game...\n");
            }
            else if (response == "n")
            {
                Console.WriteLine("\nGame continues...\n");
            }
            else
            {
                Console.WriteLine("\nInvalid input. Game continues...\n");
            }
        }
    }
}
