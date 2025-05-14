using System;
using Timer = System.Timers.Timer;
using System.Timers;
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

        private Timer statTimer;

        public event Action<Pet> OnPetDied;

        public Pet(string name, PetType type)
        {
            this.name = name;
            this.petType = type;
            hunger = 50;
            sleep = 50;
            fun = 50;

            // 5 saniyede bir statları azalt
            statTimer = new Timer(5000);
            statTimer.Elapsed += UpdateStats;
            statTimer.Start();
        }

        private void UpdateStats(object sender, ElapsedEventArgs e)
        {
            hunger = Math.Max(0, hunger - 1);
            sleep = Math.Max(0, sleep - 1);
            fun = Math.Max(0, fun - 1);

            if (hunger == 0 || sleep == 0 || fun == 0)
            {
                statTimer.Stop();
                OnPetDied?.Invoke(this);
            }
        }

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
    }
}
