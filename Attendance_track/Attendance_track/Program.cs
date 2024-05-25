using System;
using System.Collections.Generic;

namespace EventAttendanceTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input attendance data
            var events = InputAttendanceData();

            // Process each event
            foreach (var eventData in events)
            {
                double attendanceRate = CalculateAttendanceRate(eventData.Item2, eventData.Item3);
                string category = CategorizeAttendance(attendanceRate);

                Console.WriteLine($"Event: {eventData.Item1}");
                Console.WriteLine($"Registrants: {eventData.Item2}");
                Console.WriteLine($"Attendees: {eventData.Item3}");
                Console.WriteLine($"Attendance Rate: {attendanceRate:F2}%");
                Console.WriteLine($"Category: {category}");
                Console.WriteLine();
            }
        }

        static List<Tuple<string, int, int>> InputAttendanceData()
        {
            var events = new List<Tuple<string, int, int>>();
            Console.WriteLine("Enter event attendance data. Type 'done' when finished.");

            while (true)
            {
                Console.Write("Enter event name: ");
                string eventName = Console.ReadLine();
                if (eventName.ToLower() == "done")
                {
                    break;
                }

                Console.Write("Enter number of registrants: ");
                int registrants = int.Parse(Console.ReadLine());

                Console.Write("Enter number of attendees: ");
                int attendees = int.Parse(Console.ReadLine());

                events.Add(Tuple.Create(eventName, registrants, attendees));
            }

            return events;
        }

        static double CalculateAttendanceRate(int registrants, int attendees)
        {
            if (registrants == 0)
            {
                return 0;
            }
            return (double)attendees / registrants * 100;
        }

        static string CategorizeAttendance(double attendanceRate)
        {
            if (attendanceRate >= 75)
            {
                return "High";
            }
            else if (attendanceRate >= 50)
            {
                return "Medium";
            }
            else
            {
                return "Low";
            }
        }
    }
}
