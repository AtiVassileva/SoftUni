using System;
using System.Linq;
using System.Collections.Generic;

namespace ListManipulations
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var isChanged = false;

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                var input = command.Split();
                switch (input[0])
                {
                    case "Add":
                        var numToAdd = int.Parse(input[1]);
                        nums.Add(numToAdd);
                        isChanged = true;
                        break;
                    case "Remove":
                        var numToRemove = int.Parse(input[1]);
                        nums.Remove(numToRemove);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        var index = int.Parse(input[1]);
                        nums.RemoveAt(index);
                        isChanged = true;
                        break;
                    case "Insert":
                        var numToInsert = int.Parse(input[1]);
                        var indexToInsert = int.Parse(input[2]);
                        nums.Insert(indexToInsert, numToInsert);
                        isChanged = true;
                        break;
                    case "Contains":
                        var numToCheck = int.Parse(input[1]);
                        if (nums.Contains(numToCheck))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        for (var i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 0)
                            {
                                Console.Write(nums[i] + " ");
                            }
                        }
                        break;
                    case "PrintOdd":
                        for (var i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 1)
                            {
                                Console.Write(nums[i] + " ");
                            }
                        }
                        break;
                    case "GetSum":
                        Console.WriteLine(nums.Sum());
                        break;
                    case "Filter":
                        var condition = (input[1]);
                        var givenNum = int.Parse(input[2]);
                       var  newList = new List<int>();

                        switch (condition)
                        {
                            case "<":
                                for (var i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] < givenNum)
                                    {
                                        newList.Add(nums[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", newList));
                                break;
                            case ">":
                                for (var i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] > givenNum)
                                    {
                                        newList.Add(nums[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", newList));
                                break;
                            case "<=":
                                for (var i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] <= givenNum)
                                    {
                                        newList.Add(nums[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", newList));
                                break;
                            case ">=":
                                for (var i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] >= givenNum)
                                    {
                                        newList.Add(nums[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", newList));
                                break;
                        }
                        break;
                }
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}