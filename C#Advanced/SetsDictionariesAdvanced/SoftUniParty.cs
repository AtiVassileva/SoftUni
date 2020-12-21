using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vips = new HashSet<string>();
            var regulars = new HashSet<string>();

            while (true)
            {
                var guestNumber = Console.ReadLine();
                if (guestNumber == "PARTY")
                {
                    break;
                }

                if (guestNumber.Length == 8)
                {
                    if (char.IsDigit(guestNumber[0]))
                    {
                        vips.Add(guestNumber.ToString());
                    }
                    else
                    {
                        regulars.Add(guestNumber.ToString());
                    }
                }
            }

            while (true)
            {
                var currentGuest = Console.ReadLine();

                if (currentGuest == "END")
                {
                    break;
                }

                if (vips.Contains(currentGuest))
                {
                    vips.Remove(currentGuest);
                }

                if (regulars.Contains(currentGuest))
                {
                    regulars.Remove(currentGuest);
                }
            }

            Console.WriteLine(vips.Count + regulars.Count);

            foreach (var vip in vips)
            {
                Console.WriteLine(vip.ToString());
            }

            foreach (var reg in regulars)
            {
                Console.WriteLine(reg);
            }
        }
    }
}