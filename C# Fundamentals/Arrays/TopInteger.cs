using System;
using System.Linq;

namespace TopInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            var result = "";

            for (var i = 0; i < array.Length; i++)
            {
                var current = array[i];
                var isTopInteger = true;

                for (var j = i + 1; j < array.Length; j++)
                {
                    if (current <= array[j])
                    {
                        isTopInteger = false;
                        break;
                    }
                }
                if (isTopInteger)
                {
                    result += current + " ";
                }
            }
            Console.WriteLine(result);
        }
    }
}