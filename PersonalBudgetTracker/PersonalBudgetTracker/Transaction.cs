using System;

namespace PersonalBudgetTracker
{
    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }

        public Transaction(string description, decimal amount, string category, string date)
        {
            Description = description;
            Amount = amount;
            Category = category;
            Date = date;
        }

        public void ShowInfo()
        {
            // Använd färg baserat på belopp (bonuskrav)
            Console.ForegroundColor = Amount >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"Datum: {Date}, Beskrivning: {Description}, Belopp: {Amount:C}, Kategori: {Category}");
            Console.ResetColor();
        }
    }
}
