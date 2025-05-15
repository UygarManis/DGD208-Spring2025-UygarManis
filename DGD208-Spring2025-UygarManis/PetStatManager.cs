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
            // 5 saniyede bir stat düşür
            statTimer = new Timer(DecreaseStats, null, 0, 5000);
        }

        private void DecreaseStats(object state)
        {
            pet.hunger = Math.Max(0, pet.hunger - 1);
            pet.sleep = Math.Max(0, pet.sleep - 1);
            pet.fun = Math.Max(0, pet.fun - 1);

            // Eğer bir stat sıfırlandıysa pet ölsün event çağrılsın
            if (pet.hunger == 0 || pet.sleep == 0 || pet.fun == 0)
            {
                statTimer.Dispose();
                pet.Die();   // 
            }
        }
    }
}
