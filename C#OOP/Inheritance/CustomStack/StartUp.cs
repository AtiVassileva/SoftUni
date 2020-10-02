using System;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var names = new string[]{"Gosho", "Maria", "Pesho", "Ivan"};

            var myStack = new StackOfStrings();
            
            foreach (var name in names)
            {
                myStack.Push(name);
            }
            Console.WriteLine($"Is it empty? {myStack.IsEmpty()}");
            Console.WriteLine("Natural stack:");
            Console.WriteLine(string.Join(", ", myStack));

            var newNames = new string[] {"Atan", "Tonka", "Gallinski", "Alex"};
            myStack.AddRange(newNames);
            Console.WriteLine("Extended stack:");
            Console.WriteLine(string.Join(", ", myStack));

            myStack.Clear();
            Console.WriteLine($"Check again if it is empty : {myStack.IsEmpty()}");
        }
    }
}
