using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var maxName = names =>
            {
                var maxName = string.Empty;

                foreach (var name in names)
                {
                    var currSum = 0;
                    var curr = name.ToCharArray();

                    foreach (var symbol in curr)
                    {
                        currSum += (int)symbol;
                    }

                    if (currSum > number)
                    {
                        maxName = name;
                        break;
                    }

                }

                return maxName;
            };

            Console.WriteLine(maxName(names));
        }
    }
}