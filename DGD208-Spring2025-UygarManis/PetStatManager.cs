using System;
using System.Threading;

namespace DGD208_Spring2025_UygarManis
{
    public class PetStatManager
    {
        private readonly Pet pet;
        private Timer statTimer;

        public PetStatManager(Pet pet)
        {
            this.pet = pet;
        }

        public void StartStatDecrease()
        {
            statTimer = new Timer(DecreaseStats, null, 0, 5000);
        }

        private void DecreaseStats(object state)
        {
            pet.hunger = Math.Max(0, pet.hunger - 1);
            pet.sleep = Math.Max(0, pet.sleep - 1);
            pet.fun = Math.Max(0, pet.fun - 1);
            pet.health = Math.Max(0, pet.health - 1);

            // ⚠️ Uyarılar sadece bir kez gösterilsin
            if (pet.hunger <= 10 && !pet.warnedHunger)
            {
                Console.WriteLine($"  {pet.name} çok aç görünüyor!");
                pet.warnedHunger = true;
            }
            else if (pet.hunger > 10)
            {
                pet.warnedHunger = false;
            }

            if (pet.sleep <= 10 && !pet.warnedSleep)
            {
                Console.WriteLine($"  {pet.name} kendini çok yorgun hissediyor!");
                pet.warnedSleep = true;
            }
            else if (pet.sleep > 10)
            {
                pet.warnedSleep = false;
            }

            if (pet.fun <= 10 && !pet.warnedFun)
            {
                Console.WriteLine($"  {pet.name} çok sıkılmış!");
                pet.warnedFun = true;
            }
            else if (pet.fun > 10)
            {
                pet.warnedFun = false;
            }

            if (pet.health <= 10 && !pet.warnedHealth)
            {
                Console.WriteLine($"  {pet.name}'in sağlığı çok kötü!");
                pet.warnedHealth = true;
            }
            else if (pet.health > 10)
            {
                pet.warnedHealth = false;
            }

            if (pet.hunger == 0 || pet.sleep == 0 || pet.fun == 0 || pet.health == 0)
            {
                statTimer.Dispose();
                pet.Die();
            }
        }

    }
}
