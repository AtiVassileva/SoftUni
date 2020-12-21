using System;
using System.Linq;
using System.Collections.Generic;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyEmployees = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                var input = line.Split(" -> ");
                var companyName = input[0];
                var employeeID = input[1];

                if (!companyEmployees.ContainsKey(companyName))
                {
                    companyEmployees.Add(companyName, new List<string>());
                }

                if (!companyEmployees[companyName].Contains(employeeID))
                {
                    companyEmployees[companyName].Add(employeeID);
                }

            }

            foreach (var kvp in companyEmployees.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var value in kvp.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}