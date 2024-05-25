using System;
using System.Collections.Generic;

namespace InventoryManagement
{
    class Program
    {
        static Dictionary<string, int> inventory = new Dictionary<string, int>()
        {
            { "novels", 50 },
            { "science books", 40 }
        };

        static void Main(string[] args)
        {
            // Input sales and restock data
            var (salesData, restockData) = InputSalesAndRestockData();

            // Update inventory levels
            UpdateInventoryLevels(salesData, restockData);

            // Display inventory status
            DisplayInventoryStatus();
        }

        static (Dictionary<string, int>, Dictionary<string, int>) InputSalesAndRestockData()
        {
            var salesData = new Dictionary<string, int>();
            var restockData = new Dictionary<string, int>();

            Console.WriteLine("Enter sales data. Type 'done' when finished.");
            while (true)
            {
                Console.Write("Enter item sold: ");
                string item = Console.ReadLine();
                if (item.ToLower() == "done") break;

                Console.Write("Enter quantity sold: ");
                int quantity = int.Parse(Console.ReadLine());
                if (salesData.ContainsKey(item))
                {
                    salesData[item] += quantity;
                }
                else
                {
                    salesData[item] = quantity;
                }
            }

            Console.WriteLine("Enter restock data. Type 'done' when finished.");
            while (true)
            {
                Console.Write("Enter item restocked: ");
                string item = Console.ReadLine();
                if (item.ToLower() == "done") break;

                Console.Write("Enter quantity restocked: ");
                int quantity = int.Parse(Console.ReadLine());
                if (restockData.ContainsKey(item))
                {
                    restockData[item] += quantity;
                }
                else
                {
                    restockData[item] = quantity;
                }
            }

            return (salesData, restockData);
        }

        static void UpdateInventoryLevels(Dictionary<string, int> salesData, Dictionary<string, int> restockData)
        {
            foreach (var sale in salesData)
            {
                if (inventory.ContainsKey(sale.Key))
                {
                    inventory[sale.Key] -= sale.Value;
                }
                else
                {
                    inventory[sale.Key] = -sale.Value;
                }
            }

            foreach (var restock in restockData)
            {
                if (inventory.ContainsKey(restock.Key))
                {
                    inventory[restock.Key] += restock.Value;
                }
                else
                {
                    inventory[restock.Key] = restock.Value;
                }
            }
        }

        static void DisplayInventoryStatus()
        {
            Console.WriteLine("\nCurrent Inventory Levels:");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
