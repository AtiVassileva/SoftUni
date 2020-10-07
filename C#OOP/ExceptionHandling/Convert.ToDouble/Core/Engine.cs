using System;

namespace Convert.ToDouble.Core
{
    public class Engine
    {
        private const string InputMessage =
            "How many numbers you want to read? Range {1 - 2 147 483 647}";

        public void Run()
        {
            Console.WriteLine(InputMessage);

            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                try
                {
                    var number = Console.ReadLine();
                    var result = System.Convert.ToDouble(number);
                    Console.WriteLine($"Success! Result is {result:F2}");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }

                catch (InvalidCastException ice)
                {
                    Console.WriteLine(ice.Message);
                }

                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
            }
        }
    }
}
