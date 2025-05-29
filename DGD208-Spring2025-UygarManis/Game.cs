using System;
using System.Collections.Generic;
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
            Console.WriteLine("\n\n🕵️ Welcome to Agent Animal Ops HQ!\nYour mission is to train and protect your undercover pets.\n");

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
                        Console.WriteLine("\n❌ Invalid selection. Please try again.\n");
                        break;
                }

                petManager.CheckForBreeding();
            }
        }

        private void AdoptPet()
        {
            var petTypes = Enum.GetValues(typeof(PetType));
            int index = 1;

            Console.WriteLine("\nSelect agent species:\n");
            foreach (var type in petTypes)
            {
                Console.WriteLine($"{index}. {type}");
                index++;
            }

            Console.Write("\nYour choice (1-4): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= petTypes.Length)
            {
                PetType selectedType = (PetType)petTypes.GetValue(choice - 1);

                Console.Write("\nEnter agent's code name: ");
                string name = Console.ReadLine();

                petManager.AdoptPet(name, selectedType);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\n❌ Invalid selection.\n");
            }
        }

        private async void UseItem()
        {
            var allPets = petManager.GetAllPets();
            if (allPets.Count == 0)
            {
                Console.WriteLine("\n⚠️ You have no agents to deploy items on.\n");
                return;
            }

            Console.WriteLine("\nSelect an agent to use an item:\n");
            for (int i = 0; i < allPets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allPets[i].name} ({allPets[i].petType})");
            }

            Console.Write("\nEnter agent number: ");
            if (!int.TryParse(Console.ReadLine(), out int petIndex) || petIndex < 1 || petIndex > allPets.Count)
            {
                Console.WriteLine("\n❌ Invalid selection.\n");
                return;
            }

            var pet = allPets[petIndex - 1];

            itemManager.ShowAvailableItems();
            Console.Write("\nEnter item number: ");
            if (!int.TryParse(Console.ReadLine(), out int itemChoice) || itemChoice < 1 || itemChoice > itemManager.Items.Count)
            {
                Console.WriteLine("\n❌ Invalid item.\n");
                return;
            }

            var item = itemManager.Items[itemChoice - 1];
            await itemManager.UseItemAsync(pet, item);
            Console.WriteLine();
        }

        private void ShowCreatorInfo()
        {
            Console.WriteLine("\n--- Project Developer ---");
            Console.WriteLine("Uygar Manış - Student ID: 225040059\n- Assistant: ChatGPT");
        }

        private void ExitGame()
        {
            Console.Write("\nAre you sure you want to exit the mission? (y/n): ");
            string response = Console.ReadLine().ToLower();

            if (response == "y")
            {
                isRunning = false;
                Console.WriteLine("\n🛑 Mission terminated. See you soon, Commander.\n");
            }
            else if (response == "n")
            {
                Console.WriteLine("\n🔁 Continuing mission...\n");
            }
            else
            {
                Console.WriteLine("\n❓ Unknown input. Resuming operation.\n");
            }
        }
    }
}
