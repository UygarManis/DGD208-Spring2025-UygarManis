using System;
using System.Collections.Generic;
using System.Linq;
using DGD208_Spring2025_UygarManis.Enums;

namespace DGD208_Spring2025_UygarManis
{
    public class PetManager
    {
        private List<Pet> pets = new List<Pet>();
        private HashSet<PetType> bredTypes = new HashSet<PetType>();

        public void AdoptPet(string name, PetType type)
        {
            if (pets.Exists(p => p.name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"\nAgent with codename {name} already exists. Choose a different name.\n");
                return;
            }

            Pet newPet = new Pet(name, type);
            newPet.OnPetDied += RemovePet;
            pets.Add(newPet);
            Console.WriteLine($"Agent {name} ({type}) successfully recruited into the squad!");
        }

        private void RemovePet(Pet pet)
        {
            pets.Remove(pet);
            Console.WriteLine($"⚠️ Agent {pet.name} ({pet.petType}) has been lost in action.");
        }

        public void ShowAllPets()
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("\nNo active agents on the field.\n");
                return;
            }

            Console.WriteLine("\nActive Agents:\n");

            foreach (var pet in pets)
            {
                pet.DisplayStats();
            }
        }

        public Pet GetPetByName(string name)
        {
            return pets.Find(p => p.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Pet> GetAllPets()
        {
            return pets;
        }

        public void CheckForBreeding()
        {
            var grouped = pets
                .GroupBy(p => p.petType)
                .Where(g => g.Count() >= 2 && !bredTypes.Contains(g.Key));

            foreach (var group in grouped)
            {
                var parentName = group.First().name;
                string babyName = $"Baby {parentName} Jr.";

                Pet baby = new Pet(babyName, group.Key, 25);
                baby.OnPetDied += RemovePet;
                pets.Add(baby);
                bredTypes.Add(group.Key);

                Console.WriteLine($"\n🍼 New recruit has joined the mission! Codename: {babyName} (Species: {group.Key})");
            }
        }
    }
}
