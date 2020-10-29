using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Stack<char>(Console.ReadLine().ToCharArray());
            Console.WriteLine(string.Join("", result));
        }
    }
}