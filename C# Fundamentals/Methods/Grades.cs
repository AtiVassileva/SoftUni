using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var grade = double.Parse(Console.ReadLine());
            PrintGrade(grade);
        }
        static void PrintGrade(double grade)
        {
            var result = string.Empty;
            if (grade >= 2 && grade <= 2.99)
            {
                result = "Fail";
            }
            else if (grade >= 3 && grade <= 3.49)
            {
                result = "Poor";
            }
            else if (grade >= 3.5 && grade <= 4.49)
            {
                result = "Good";
            }
            else if (grade >= 4.5 && grade <= 5.49)
            {
                result = "Very good";
            }
            else if (grade >= 5.5 && grade <= 6)
            {
                result = "Excellent";
            }
            Console.WriteLine(result);
        }
    }
}