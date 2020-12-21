using System;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split();
            var rotations = int.Parse(Console.ReadLine());

            rotations = rotations % array.Length;

            for (var i = 0; i < rotations; i++)
            {
                var temp = array[0];
                for (var j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = temp;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}