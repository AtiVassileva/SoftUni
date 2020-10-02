using System;
using System.Linq;
using Telephony.Common;
using Telephony.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var numbers = reader.ReadLine().Split(' ').ToArray();
            var addresses = reader.ReadLine().Split( ' ').ToArray();

            CallNumbers(numbers);

            BrowseWebsites(addresses);
        }

        private void BrowseWebsites(string[] addresses)
        {
            foreach (var address in addresses)
            {
                try
                {
                    writer.WriteLine(this.smartphone.Browse(address));
                }
                catch (InvalidWebsiteException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var num in numbers)
            {
                try
                {
                    switch (num.Length)
                    {
                        case 10:
                            writer.WriteLine(this.smartphone.Call(num));
                            break;
                        case 7:
                            writer.WriteLine(this.stationaryPhone.Call(num));
                            break;
                        default:
                            throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException e)
                {
                    writer.WriteLine(e.Message);
                }
            }
        }
    }
}
