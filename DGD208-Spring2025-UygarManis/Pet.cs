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

        // Event → Pet öldüğünde bildirim için
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

        // Item kullanımı için stat artırıcı methodlar
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

        // Pet öldüğünde event tetikleme
        public void Die()
        {
            OnPetDied?.Invoke(this);
        }

        // Geliştirilmiş stat + ascii gösterimi
        public void DisplayStats()
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine(GetAsciiArt());   // ✅ ascii resmi
            Console.WriteLine($" Name: {name}    Type: {petType}");
            Console.WriteLine($" Hunger: {hunger}   Sleep: {sleep}   Fun: {fun}");
            Console.WriteLine("------------------------------------\n");
        }

        // PetType'a göre ascii art döndür
        private string GetAsciiArt()
        {
            switch (petType)
            {
                case PetType.Dog:
                    return @"  / \__
 (    @\___
 /         O
/   (_____/
/_____/  U ";
                case PetType.Cat:
                    return @" /\_/\ 
( o.o )
 > ^ <";
                case PetType.Rabbit:
                    return @"( \_/ )
( • . • )
/ >🍎";
                case PetType.Dragon:
                    return @"      /^\/^\
    _|__|  O|
\/     /~  \_/ \
 \____|_________\
        \_______/";
                default:
                    return "";
            }
        }
    }
}