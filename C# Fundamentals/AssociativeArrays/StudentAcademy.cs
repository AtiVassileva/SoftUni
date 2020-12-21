using System;
using System.Linq;
using System.Collections.Generic;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsDiary = new Dictionary<string, List<double>>();
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var name = Console.ReadLine();
                var currentGrade = double.Parse(Console.ReadLine());

                if (!studentsDiary.ContainsKey(name))
                {
                    studentsDiary.Add(name, new List<double>());
                }
                studentsDiary[name].Add(currentGrade);
            }

            foreach (var student in studentsDiary.OrderByDescending(x => x.Value.Average()))
            {
                if (student.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
                }
            }
        }
    }
}