using System;
using DGD208_Spring2025_UygarManis.Enums;

namespace DGD208_Spring2025_UygarManis
{
    public class Pet
    {
        public string name;
        public PetType petType;
        public int hunger;
        public int sleep;
        public int fun;

        //  Pet öldüğünde Game'e bildirim için
        public event Action<Pet> OnPetDied;

        public Pet(string name, PetType type)
        {
            this.name = name;
            this.petType = type;
            hunger = 50;
            sleep = 50;
            fun = 50;

            // Stat düşürme yöneticisini başlat
            PetStatManager statManager = new PetStatManager(this);
            statManager.StartStatDecrease();
        }

        // Stat artırıcı metodlar (item kullanımı için)
        public void Feed(int amount)
        {
            hunger = Math.Min(100, hunger + amount);
        }

        public void Play(int amount)
        {
            fun = Math.Min(100, fun + amount);
        }

        public void Rest(int amount)
        {
            sleep = Math.Min(100, sleep + amount);
        }

        // Ölüm durumunu dışarı bildir
        public void Die()
        {
            OnPetDied?.Invoke(this);
        }

        // Konsola pet bilgilerini yaz
        public void DisplayStats()
        {
            Console.WriteLine($"\n{name} ({petType}) → Hunger: {hunger}, Sleep: {sleep}, Fun: {fun}");
        }
    }
}
