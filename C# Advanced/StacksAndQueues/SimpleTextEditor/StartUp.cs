using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var previousCommands = new Stack<string>();
            var text = "";

            for (var i = 0; i < count; i++)
            {
                var command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "1":
                        previousCommands.Push(text);
                        text += command[1];
                        break;
                    case "2":
                        previousCommands.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(command[1]));
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(command[1]) - 1]);
                        break;
                    case "4":
                        text = previousCommands.Pop();
                        break;
                }
            }
        }
    }
}