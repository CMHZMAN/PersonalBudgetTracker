using System;

namespace PersonalBudgetTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            BudgetManager manager = new BudgetManager();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Personal Budget Tracker ===");
                Console.WriteLine("1. Lägg till transaktion");
                Console.WriteLine("2. Visa alla transaktioner");
                Console.WriteLine("3. Visa total balans");
                Console.WriteLine("4. Ta bort transaktion");
                Console.WriteLine("5. Avsluta");
                Console.WriteLine("6. Visa transaktioner per kategori");
                Console.WriteLine("7. Visa statistik");
                Console.Write("Välj ett alternativ (1-7): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Beskrivning: ");
                        string description = Console.ReadLine();

                        Console.Write("Belopp (positivt för inkomst, negativt för utgift): ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                        {
                            Console.WriteLine("Ogiltigt belopp!");
                            break;
                        }

                        Console.Write("Kategori: ");
                        string category = Console.ReadLine();

                        Console.Write("Datum (ÅÅÅÅ-MM-DD): ");
                        string date = Console.ReadLine();

                        manager.AddTransaction(description, amount, category, date);
                        break;
                    case "2":
                        manager.ShowAll();
                        break;
                    case "3":
                        Console.WriteLine($"Total balans: {manager.CalculateBalance():C}");
                        break;
                    case "4":
                        manager.ShowAll();
                        Console.Write("Ange index för transaktion att ta bort: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            manager.DeleteTransaction(index - 1);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig inmatning!");
                        }
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Programmet avslutas...");
                        break;
                    case "6":
                        Console.Write("Ange kategori: ");
                        category = Console.ReadLine();
                        manager.ShowByCategory(category);
                        break;
                    case "7":
                        manager.ShowStatistics();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
        }
                
    }
}
