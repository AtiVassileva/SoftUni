using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var given = int.Parse(Console.ReadLine());

            for (var i = 0; i < arr.Length - 1; i++)
            {
                for (var a = i + 1; a < arr.Length; a++)
                {
                    if (arr[i] + arr[a] == given)
                    {
                        Console.WriteLine(arr[i] + " " + arr[a]);
                    }
                }
            }
        }
    }
}