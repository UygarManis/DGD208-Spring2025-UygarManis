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
                Console.WriteLine($"\n{name} adında bir hayvan zaten var. Lütfen farklı bir isim seçin.\n");
                return;
            }

            Pet newPet = new Pet(name, type);
            newPet.OnPetDied += RemovePet;
            pets.Add(newPet);
            Console.WriteLine($"{name} adlı {type} başarıyla sahiplendi!");
        }

        private void RemovePet(Pet pet)
        {
            pets.Remove(pet);
            Console.WriteLine($"{pet.name} adlı {pet.petType} öldü. Listeden çıkarıldı.");
        }

        public void ShowAllPets()
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("\nHiç sahiplendiğiniz hayvan yok.\n");
                return;
            }

            Console.WriteLine("\nSahip olduğunuz hayvanlar:\n");

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

                Console.WriteLine($"\n👶 Yeni bir {group.Key} doğdu! Adı: {babyName}");
            }
        }
    }
}
