using System;
using System.Linq;
using System.Collections.Generic;

namespace AverageStudentsGrades
{
    class Program
    {
        static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var studentBook = new Dictionary<string, List<decimal>>();

            for (var i = 0; i < count; i++)
            {
                var inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = inputArgs[0];
                var grade = decimal.Parse(inputArgs[1]);

                if (!studentBook.ContainsKey(name))
                {
                    studentBook.Add(name, new List<decimal>());
                }
                studentBook[name].Add(grade);
            }

            foreach (var (name, gradeValues) in studentBook)
            {
                var nameCurr = name;
                var currentGrades = string.Join(" ", gradeValues.Select(x => x.ToString("F2")));
                var averageGrade = gradeValues.Average();

                Console.WriteLine($"{name} -> {currentGrades} (avg: {averageGrade:F2})");
            }
        }
    }
}