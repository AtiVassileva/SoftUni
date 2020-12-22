using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = double.Parse(Console.ReadLine());
            var second = double.Parse(Console.ReadLine());
            var third = double.Parse(Console.ReadLine());

            var biggest = 0;
            var smallest = 0;
            var middle = 0;

            if (first > second && first > third)
            {
                biggest = first;

                if (second > third)
                {
                    middle = second;
                    smallest = third;
                }
                else
                {
                    middle = third;
                    smallest = second;
                }
            }
            else if (second > first && second > third)
            {
                biggest = second;

                if (first > third)
                {
                    middle = first;
                    smallest = third;
                }
                else
                {
                    middle = third;
                    smallest = first;
                }
            }
            else if (third > second && third > first)
            {
                biggest = third;

                if (second > first)
                {
                    middle = second;
                    smallest = first;
                }
                else
                {
                    middle = first;
                    smallest = second;
                }
            }

            Console.WriteLine(biggest);
            Console.WriteLine(middle);
            Console.WriteLine(smallest);
        }
    }
}