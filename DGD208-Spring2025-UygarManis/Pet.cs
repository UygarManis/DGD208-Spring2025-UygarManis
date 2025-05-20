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
        public int health;

        public event Action<Pet> OnPetDied;

        public Pet(string name, PetType type)
        {
            this.name = name;
            this.petType = type;
            hunger = 50;
            sleep = 50;
            fun = 50;
            health = 50;

            PetStatManager statManager = new PetStatManager(this);
            statManager.StartStatDecrease();
        }

        public Pet(string name, PetType type, int statBase)
        {
            this.name = name;
            this.petType = type;
            hunger = statBase;
            sleep = statBase;
            fun = statBase;
            health = statBase;

            PetStatManager statManager = new PetStatManager(this);
            statManager.StartStatDecrease();
        }

        public void Feed(int amount) => hunger = Math.Min(100, hunger + amount);
        public void Play(int amount) => fun = Math.Min(100, fun + amount);
        public void Rest(int amount) => sleep = Math.Min(100, sleep + amount);
        public void Heal(int amount) => health = Math.Min(100, health + amount);

        public bool warnedHunger = false;
        public bool warnedSleep = false;
        public bool warnedFun = false;
        public bool warnedHealth = false;

        public void Die() => OnPetDied?.Invoke(this);

        public void DisplayStats()
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine(GetAsciiArt());
            Console.WriteLine($" Name: {name}    Type: {petType}");
            Console.WriteLine($" Hunger: {hunger}   Sleep: {sleep}   Fun: {fun}   Health: {health}");
            Console.WriteLine("------------------------------------\n");
        }

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
