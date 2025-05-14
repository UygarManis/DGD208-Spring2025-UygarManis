using System;
using System.Collections.Generic;
using DGD208_Spring2025_UygarManis.Enums;

namespace DGD208_Spring2025_UygarManis
{
    public class PetManager
    {
        private List<Pet> pets = new List<Pet>();

        public void AdoptPet(string name, PetType type)
        {
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
                Console.WriteLine("Hiç sahiplendiğiniz hayvan yok.");
                return;
            }

            Console.WriteLine("Sahip olduğunuz hayvanlar:");
            foreach (var pet in pets)
            {
                Console.WriteLine($"- {pet.name} ({pet.petType}) | Açlık: {pet.hunger} | Uyku: {pet.sleep} | Eğlence: {pet.fun}");
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
    }
}
