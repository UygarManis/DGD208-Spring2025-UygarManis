using System;

namespace DGD208_Spring2025_UygarManis
{
    public static class Menu
    {
        public static void ShowMainMenu()
        {
            Console.WriteLine("\n--- Agent Animal Ops Mission Control ---\n");
            Console.WriteLine("1. Recruit New Agent");
            Console.WriteLine("2. View All Agents");
            Console.WriteLine("3. Use Item");
            Console.WriteLine("4. Credit");
            Console.WriteLine("5. Exit Mission\n");
            Console.Write("Your selection: ");
        }
    }
}
