using System;

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            (double weight, double height) = InputWeightAndHeight();
            double bmi = CalculateBMI(weight, height);
            string category = CategorizeBMI(bmi);

            Console.WriteLine($"BMI: {bmi:F2}");
            Console.WriteLine($"Category: {category}");

            // Sample data for validation
            var users = new[]
            {
                new { Weight = 70.0, Height = 1.75 },
                new { Weight = 60.0, Height = 1.65 }
            };

            foreach (var user in users)
            {
                double userBmi = CalculateBMI(user.Weight, user.Height);
                string userCategory = CategorizeBMI(userBmi);
                Console.WriteLine($"Weight: {user.Weight} kg, Height: {user.Height} m");
                Console.WriteLine($"BMI: {userBmi:F2}");
                Console.WriteLine($"Category: {userCategory}");
                Console.WriteLine();
            }
        }

        static (double, double) InputWeightAndHeight()
        {
            try
            {
                Console.Write("Enter weight in kg: ");
                double weight = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter height in meters: ");
                double height = Convert.ToDouble(Console.ReadLine());
                return (weight, height);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numeric values for weight and height.");
                return InputWeightAndHeight();
            }
        }

        static double CalculateBMI(double weight, double height)
        {
            return weight / (height * height);
        }

        static string CategorizeBMI(double bmi)
        {
            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                return "Normal weight";
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                return "Overweight";
            }
            else
            {
                return "Obese";
            }
        }
    }
}
