using System;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine().Split();
            var arr2 = Console.ReadLine().Split();
            var result = "";

            foreach (var word1 in arr2)
            {
                foreach (var word2 in arr1)
                {
                    if (word1 == word2)
                    {
                        result += word1 + " ";
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}