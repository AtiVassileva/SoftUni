using System;
using System.Linq;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var box = new Box<int>();
            var count = int.Parse(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                var input = int.Parse(Console.ReadLine());
                box.Add(input);
            }

            var indexesToSwap = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var firstIndex = indexesToSwap[0];
            var secondIndex = indexesToSwap[1];

            box.Swap(firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}