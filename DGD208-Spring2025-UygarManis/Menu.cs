using System;

namespace DGD208_Spring2025_UygarManis
{
    public static class Menu
    {
        public static void ShowMainMenu()
        {
            Console.WriteLine("\n--- Pet Simulator ---");
            Console.WriteLine("1. Evcil hayvan sahiplen");
            Console.WriteLine("2. Evcil hayvanları görüntüle");
            Console.WriteLine("3. Item kullan");
            Console.WriteLine("4. Proje Sahibi Bilgileri");
            Console.WriteLine("5. Oyundan çık");
            Console.Write("Seçiminiz: ");
        }
    }
}
