using System;
using System.Collections.Generic;
using ValidPerson.Exceptions;
using ValidPerson.Models;

namespace ValidPerson.Core
{
    public class Engine
    {
        private const int PersonsCount = 6;
        private const int StudentsCount = 3;

        private List<string> personFirstNames;
        private List<string> personLastNames;
        private List<int> ages;

        private List<string> studentNames;
        private List<string> studentEmails;

        public Engine()
        {
            this.InitializeFirstNames();
            this.InitializeLastNames();
            this.InitializeAges();
            this.InitializeStudentNames();
            this.InitializeEmails();
        }

        public void Run()
        {
            Console.WriteLine("Validate person cases:");
            this.ValidatePersons();

            Console.WriteLine("Validate student cases:");

            this.ValidateStudents();

        }

        private void ValidatePersons()
        {
            for (var i = 0; i < PersonsCount; i++)
            {
                var firstName = this.personFirstNames[i];
                var lastName = this.personLastNames[i];
                var age = this.ages[i];

                try
                {
                    var person = new Person(firstName, lastName, age);
                    Console.WriteLine("Success!");
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine($"Exception caught: {ane.Message}");
                }
                catch (ArgumentOutOfRangeException aor)
                {
                    Console.WriteLine($"Exception caught: {aor.Message}");
                }
            }
        }

        private void ValidateStudents()
        {
            for (var i = 0; i < StudentsCount; i++)
            {
                var name = this.studentNames[i];
                var email = this.studentEmails[i];

                try
                {
                    var student = new Student(name, email);
                    Console.WriteLine("Success!");
                }
                catch (InvalidPersonNameException ipne)
                {
                    Console.WriteLine(ipne.Message);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
            }
        }

        private void InitializeAges()
        {
            this.ages = new List<int>
            {
                34,
                18,
                90,
                53,
                -40,
                139
            };
        }

        private void InitializeLastNames()
        {
            this.personLastNames = new List<string>
            {
                "Holmes",
                "Dude",
                string.Empty,
                "Rodgerson",
                "Rodrigez",
                "Tompson"
            };
        }

        private void InitializeFirstNames()
        {
            this.personFirstNames = new List<string>
            {
                "Sherlock",
                null,
                "George",
                "          ",
                "Hammer",
                "Boomer"
            };
        }

        private void InitializeStudentNames()
        {
            this.studentNames = new List<string>()
            {
                "Harry",
                "Mic5el",
                "J8sh"
            };
        }
        
        private void InitializeEmails()
        {
            this.studentEmails = new List<string>
            {
                "harold.3681@gmail.com",
                "Mic5el29.du@yahoo.com",
                "J8shRoberts@abv.bg"
            };
        }
    }
}
