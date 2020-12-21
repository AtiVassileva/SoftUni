using System;
using System.Linq;
using System.Collections.Generic;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var coursesInfo = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                var input = line.Split(" : ");

                var courseName = input[0];
                var studentName = input[1];

                if (!coursesInfo.ContainsKey(courseName))
                {
                    coursesInfo.Add(courseName, new List<string>());
                }

                coursesInfo[courseName].Add(studentName);
            }

            Console.WriteLine(string.Join(Environment.NewLine, coursesInfo.
                OrderByDescending(x => x.Value.Count)
                .Select(kvp =>
                    $"{kvp.Key}: {kvp.Value.Count} {Environment.NewLine}" +
                    $"{string.Join(Environment.NewLine, kvp.Value.OrderBy(x => x).Select(x => $"-- {x}"))}")));
        }
    }
}