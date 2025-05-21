using System;
using System.Threading;
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

            StartGrowthTimer(); 
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

            StartGrowthTimer(); 
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

            Console.WriteLine($" Hunger: {GetBar(hunger)} {hunger}/100");
            Console.WriteLine($" Sleep:  {GetBar(sleep)} {sleep}/100");
            Console.WriteLine($" Fun:    {GetBar(fun)} {fun}/100");
            Console.WriteLine($" Health: {GetBar(health)} {health}/100");

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

        // Büyüyo
        private void StartGrowthTimer()
        {
            if (!name.StartsWith("Baby ")) return;

            Timer growthTimer = new Timer(_ =>
            {
                string oldName = name;
                name = name.Replace("Baby", "Junior");

                hunger = Math.Max(hunger, 50);
                sleep = Math.Max(sleep, 50);
                fun = Math.Max(fun, 50);
                health = Math.Max(health, 50);

                Console.WriteLine($"\n🍼 {oldName} büyüdü! Artık adı: {name}");

            }, null, 60000, Timeout.Infinite); // 60 saniye sonra bir kez çalışır
        }
        private string GetBar(int value)
        {
            int totalBars = 15;
            int filledBars = (value * totalBars) / 100;
            int emptyBars = totalBars - filledBars;

            string filled = new string('█', filledBars);
            string empty = new string('░', emptyBars);

            return $"[{filled}{empty}]";
        }

    }
}
