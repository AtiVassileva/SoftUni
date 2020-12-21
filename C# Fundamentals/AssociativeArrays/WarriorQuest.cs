using System;
using System.Linq;
using System.Collections.Generic;

namespace WarriorQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var enter = Console.ReadLine();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "For Azeroth")
                {
                    break;
                }

                var input = line.Split();

                switch (input[0])
                {
                    case "GladiatorStance":
                        var result = enter.ToUpper();
                        Console.WriteLine(result);
                        break;
                    case "DefensiveStance":
                        var resulted = enter.ToLower();
                        Console.WriteLine(resulted);
                        break;
                    case "Dispel":
                        var index = int.Parse(input[1]);
                        var letter = char.Parse(input[2]);

                        if (index > -1 && index < enter.Length)
                        {
                            var temp = enter.ToCharArray();
                            temp[index] = letter;
                            enter = new string(temp);
                            Console.WriteLine("Success!");
                        }
                        else
                        {
                            Console.WriteLine("Dispel too weak.");
                        }
                        break;
                    case "Target":
                        if (input[1] == "Change")
                        {
                            var first = input[2];
                            var second = input[3];

                            if (enter.Contains(first))
                            {
                                enter = enter.Replace(first, second);
                                Console.WriteLine(enter);
                            }

                        }
                        else
                        {
                            var substring = input[2];

                            if (enter.Contains(substring))
                            {
                                var index1 = enter.IndexOf(substring);
                                enter.Remove(index1, substring.Length);
                                Console.WriteLine(enter);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;
                }
            }

        }
    }
}