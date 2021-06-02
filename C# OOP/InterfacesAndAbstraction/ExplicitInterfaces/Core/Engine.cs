using System;
using System.ComponentModel;
using System.Linq;
using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.IO;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        private const string EndOfInput = "End";
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string line;

            while ((line = this.reader.ReadLine())!= EndOfInput)
            {
                var cmdArgs = line.Split(' ').ToArray();

                var name = cmdArgs[0];
                var country = cmdArgs[1];
                var age = int.Parse(cmdArgs[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                this.writer.WriteLine(person.GetName());
                this.writer.WriteLine(resident.GetName());
            }
        }
    }
}
