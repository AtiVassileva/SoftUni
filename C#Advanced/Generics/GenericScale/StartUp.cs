using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var res = new EqualityScale<int>(5, 5);
            Console.WriteLine(res.AreEqual());
        }
    }
}