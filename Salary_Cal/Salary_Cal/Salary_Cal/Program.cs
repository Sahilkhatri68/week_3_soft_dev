using System;

namespace SalesCommissionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input sales data
            var (tvSold, smartphoneSold, laptopSold) = InputSalesData();

            // Prices of items
            double tvPrice = 350.89;
            double smartphonePrice = 239.99;
            double laptopPrice = 129.75;

            // Calculate total sales
            double totalSales = CalculateTotalSales(tvSold, tvPrice, smartphoneSold, smartphonePrice, laptopSold, laptopPrice);

            // Calculate total earnings
            double fixedSalary = 500.00; // Fixed salary for the salesperson
            double commissionRate = 0.10; // 10% commission on total sales
            double totalEarnings = CalculateTotalEarnings(fixedSalary, commissionRate, totalSales);

            // Display the total earnings
            Console.WriteLine($"Total Earnings: ${totalEarnings:F2}");
        }

        static (int, int, int) InputSalesData()
        {
            Console.Write("Enter the number of TVs sold: ");
            int tvSold = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of smartphones sold: ");
            int smartphoneSold = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of laptops sold: ");
            int laptopSold = int.Parse(Console.ReadLine());

            return (tvSold, smartphoneSold, laptopSold);
        }

        static double CalculateTotalSales(int tvSold, double tvPrice, int smartphoneSold, double smartphonePrice, int laptopSold, double laptopPrice)
        {
            double tvSales = tvSold * tvPrice;
            double smartphoneSales = smartphoneSold * smartphonePrice;
            double laptopSales = laptopSold * laptopPrice;

            return tvSales + smartphoneSales + laptopSales;
        }

        static double CalculateTotalEarnings(double fixedSalary, double commissionRate, double totalSales)
        {
            double commission = totalSales * commissionRate;
            return fixedSalary + commission;
        }
    }
}
