using System;
using System.Linq;
using System.Collections.Generic;

namespace ListyOperator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> myList = null;

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                switch (cmdArgs[0])
                {
                    case "Create":
                        myList = new ListyIterator<string>(cmdArgs.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(myList.Move());
                        break;
                    case "Print":
                        try
                        {
                            myList.Print();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(myList.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", myList));
                        break;
                }
            }
        }
    }
}