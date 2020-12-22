using System;
using System.Linq;
using System.Collections.Generic;

namespace Students.Exercise
{
    class Program
    {
        static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var students = new List<Student>();

            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                var currStudent = new Student(double.Parse(input[2]), input[0], input[1]);
                students.Add(currStudent);
            }

            var orderedStudents = students.OrderByDescending(s => s.Grade).ToList();

            foreach (var item in orderedStudents)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Student
    {
        public Student(double grade, string firstName, string lastName)
        {
            this.Grade = grade;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public double Grade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}