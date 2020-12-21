using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stack = new MyStack<int>();

            while (true)
            {
                var cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = cmdArgs[0];
                
                if (command == "END")
                {
                    break;
                }
                else if (command == "Push")
                {
                    var elements = cmdArgs.Skip(1).
                        Select(x => x.Split(',').First()).
                        Select(int.Parse).ToArray();

                    stack.Push(elements);
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
            }

            PrintStack(stack);
            PrintStack(stack);
        }

        private static void PrintStack(MyStack<int> stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}