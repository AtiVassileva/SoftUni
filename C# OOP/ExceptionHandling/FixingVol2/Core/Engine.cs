using System;
using System.Numerics;

namespace FixingVol2.Core
{
    public class Engine
    {
        public void Run()
        {
            var firstNumber = BigInteger.Parse(Console.ReadLine());
            var secondNumber = BigInteger.Parse(Console.ReadLine());

            var result = firstNumber * secondNumber;
            Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");
        }
    }
}
