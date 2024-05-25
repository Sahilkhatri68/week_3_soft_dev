using System;
using System.Collections.Generic;

namespace ExpenseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input expenses
            Dictionary<string, double> expenses = InputExpenses();

            // Categorize and sum expenses
            Dictionary<string, double> categorizedExpenses = CategorizeAndSumExpenses(expenses);

            // Display the monthly expenses
            DisplayMonthlyExpenses(categorizedExpenses);
        }

        static Dictionary<string, double> InputExpenses()
        {
            var expenses = new Dictionary<string, double>();

            Console.WriteLine("Enter your monthly expenses. Type 'done' when finished.");

            while (true)
            {
                Console.Write("Enter expense category: ");
                string category = Console.ReadLine();

                if (category.ToLower() == "done")
                {
                    break;
                }

                Console.Write("Enter amount for " + category + ": $");
                double amount;
                if (double.TryParse(Console.ReadLine(), out amount))
                {
                    if (expenses.ContainsKey(category))
                    {
                        expenses[category] += amount;
                    }
                    else
                    {
                        expenses.Add(category, amount);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number.");
                }
            }

            return expenses;
        }

        static Dictionary<string, double> CategorizeAndSumExpenses(Dictionary<string, double> expenses)
        {
            // This function just returns the original dictionary in this simple example.
            // In a more complex scenario, this could involve more sophisticated categorization.
            return expenses;
        }

        static void DisplayMonthlyExpenses(Dictionary<string, double> categorizedExpenses)
        {
            double total = 0;

            Console.WriteLine("\nMonthly Expenses:");

            foreach (var category in categorizedExpenses)
            {
                Console.WriteLine($"{category.Key}: ${category.Value:F2}");
                total += category.Value;
            }

            Console.WriteLine($"\nTotal Expenses: ${total:F2}");
        }
    }
}
