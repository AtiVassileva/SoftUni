using System;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // RANDOM TESTS FOR CUSTOM STACK'S FUNCTIONALITY 

            var stack = new MyStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);

            Console.WriteLine(stack.Count); // 4

            foreach (var number in stack)
            {
                Console.WriteLine(number); // 40 30 20 10
            }

            var result = stack.Pop();
            Console.WriteLine(result); // 40

            var peekResult = stack.Peek();

            Console.WriteLine(peekResult); // 30

            Console.WriteLine(stack.Count); // 3

            stack.Clear();

            Console.WriteLine($"Clean stack count: {stack.Count}"); // 0

            var newStack = new MyStack<int>();

            for (int i = 1; i <= 3; i++)
            {
                newStack.Push(i);
            }

            Console.WriteLine(newStack.Pop()); // 3

            Console.WriteLine("Peek:");
            Console.WriteLine(newStack.Peek()); // 2

            newStack.Clear();

            newStack.Push(7281);
            newStack.Push(7623);
            newStack.Push(5216);
            newStack.Push(1389);

            Console.WriteLine("ForEach Logic: ");
            newStack.ForEach(Console.WriteLine);
            // 1389 5216 7623 7281
        }
    }
}