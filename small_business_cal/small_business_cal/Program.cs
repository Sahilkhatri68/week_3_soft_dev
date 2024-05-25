using System;

namespace SalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data for validation
            var employees = new[]
            {
                new { Name = "Manager", HourlyRate = 30.0, HoursWorked = 45 },
                new { Name = "Technician", HourlyRate = 25.0, HoursWorked = 50 }
            };

            foreach (var employee in employees)
            {
                double pay = CalculatePay(employee.HourlyRate, employee.HoursWorked);
                DisplayGrossPay(employee.Name, pay);
            }
        }

        static (string, double, int) InputWorkData()
        {
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();

            Console.Write("Enter hourly rate: ");
            double hourlyRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter hours worked: ");
            int hoursWorked = Convert.ToInt32(Console.ReadLine());

            return (name, hourlyRate, hoursWorked);
        }

        static double CalculatePay(double hourlyRate, int hoursWorked)
        {
            const int regularHours = 40;
            const double overtimeRate = 1.5;

            if (hoursWorked <= regularHours)
            {
                return hourlyRate * hoursWorked;
            }
            else
            {
                int overtimeHours = hoursWorked - regularHours;
                return (hourlyRate * regularHours) + (hourlyRate * overtimeRate * overtimeHours);
            }
        }

        static void DisplayGrossPay(string employeeName, double grossPay)
        {
            Console.WriteLine($"Employee: {employeeName}");
            Console.WriteLine($"Gross Pay: ${grossPay:F2}");
            Console.WriteLine();
        }
    }
}
