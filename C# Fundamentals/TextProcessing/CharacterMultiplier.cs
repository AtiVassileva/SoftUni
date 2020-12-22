using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();
            var sum = 0;
            var first = words[0];
            var second = words[1];

            if (first.Length == second.Length)
            {
                for (var i = 0; i < first.Length; i++)
                {
                    sum += (int)(first[i] * second[i]);
                }
            }
            else
            {
                var lenght = Math.Min(first.Length, second.Length);
                var removed = 0;

                for (var i = 0; i < lenght; i++)
                {
                    sum += (int)(first[i] * second[i]);
                    removed++;
                }

                var left = "";
                if (first.Length > second.Length)
                {
                    left = first.Substring(removed);
                }
                else
                {
                    left = second.Substring(removed);
                }
                foreach (char element in left)
                {
                    sum += (int)element;
                }
            }

            Console.WriteLine(sum);
        }
    }
}