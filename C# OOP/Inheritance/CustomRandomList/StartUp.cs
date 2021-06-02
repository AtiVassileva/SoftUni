using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new RandomList()
            {
                "Pesho", "Gosho", "Ivan", "Anka", "Maria", "Georgi"
            };
            Console.WriteLine(string.Join(", ", list));
            Console.WriteLine(list.RandomString());
        }
    }
}
