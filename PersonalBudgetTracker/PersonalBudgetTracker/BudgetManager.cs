using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PersonalBudgetTracker
{
    public class BudgetManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(string description, decimal amount, string category, string date)
        {
            // Validering av inmatning
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Beskrivning kan inte vara tom!");
                return;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Kategori kan inte vara tom!");
                return;
            }

            if (!Regex.IsMatch(date, @"^\d{4}-\d{2}-\d{2}$"))
            {
                Console.WriteLine("Ogiltigt datumformat! Använd ÅÅÅÅ-MM-DD.");
                return;
            }

            transactions.Add(new Transaction(description, amount, category, date));
            Console.WriteLine("Transaktion tillagd!");
        }

        public void ShowAll()
        {
            if (transactions.Count == 0)
            {
                Console.WriteLine("Inga transaktioner finns.");
                return;
            }

            for (int i = 0; i < transactions.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                transactions[i].ShowInfo();
            }
        }

        public decimal CalculateBalance()
        {
            return transactions.Sum(t => t.Amount);
        }

        public void DeleteTransaction(int index)
        {
            if (index >= 0 && index < transactions.Count)
            {
                transactions.RemoveAt(index);
                Console.WriteLine("Transaktion borttagen!");
            }
            else
            {
                Console.WriteLine("Ogiltigt index!");
            }
        }

        // Bonus: Visa transaktioner per kategori
        public void ShowByCategory(string category)
        {
            var filtered = transactions.Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            if (filtered.Count == 0)
            {
                Console.WriteLine($"Inga transaktioner i kategorin '{category}'.");
                return;
            }

            foreach (var transaction in filtered)
            {
                transaction.ShowInfo();
            }
        }

        // Bonus: Visa statistik
        public void ShowStatistics()
        {
            int totalTransactions = transactions.Count;
            decimal totalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
            decimal totalExpenses = transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);

            Console.WriteLine($"Antal transaktioner: {totalTransactions}");
            Console.WriteLine($"Total inkomst: {totalIncome:C}");
            Console.WriteLine($"Total utgift: {totalExpenses:C}");
        }
    }
}
