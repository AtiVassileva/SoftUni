using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            var ladyBugsIndexes = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var field = new long[fieldSize];

            foreach (var index in ladyBugsIndexes)
            {
                if (index >= 0 && index < field.Length)
                {
                    field[index] = 1;
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                var commandInfo = command.Split().ToArray();

                var ladyBugIndex = long.Parse(commandInfo[0]);
                var direction = commandInfo[1];
                var flyLength = long.Parse(commandInfo[2]);

                if (ladyBugIndex <= field.Length - 1 && ladyBugIndex >= 0)
                {
                    if (field[ladyBugIndex] == 1)
                    {
                        switch (direction)
                        {
                            case "right":
                                field = MoveRight(field, ladyBugIndex, flyLength);
                                break;
                            case "left":
                                field = MoveLeft(field, ladyBugIndex, flyLength);
                                break;
                        }
                    }
                }
            }

            if (field.Length > 0)
            {
                Console.WriteLine(string.Join(" ", field));
            }
        }

        private static long[] MoveLeft(long[] field, long ladyBugIndex, long flyLength)
        {
            var takeOffIndex = ladyBugIndex;
            var flight = takeOffIndex - flyLength;
            var indexToLand = ladyBugIndex;

            if (flyLength == 0)
            {
                return field;
            }
            if (flyLength < 0)
            {
                field = MoveRight(field, ladyBugIndex, Math.Abs(flyLength));
                return field;
            }
            if (flight >= 0 && flight < field.Length)
            {
                if (field[flight] == 0)
                {
                    indexToLand = flight;

                    field[takeOffIndex] = 0;
                    field[indexToLand] = 1;
                }
                else
                {
                    indexToLand = -1;
                    for (var i = flight; i >= 0; i -= flyLength)
                    {
                        if (field[i] != 1)
                        {
                            indexToLand = i;
                            field[takeOffIndex] = 0;
                            field[indexToLand] = 1;
                            break;
                        }

                    }
                    if (indexToLand < 0)
                    {
                        field[takeOffIndex] = 0;
                    }
                }
            }
            else
            {
                field[takeOffIndex] = 0;
            }
            return field;
        }

        private static long[] MoveRight(long[] field, long ladyBugIndex, long flyLength)
        {

            var takeOffIndex = ladyBugIndex;
            var flight = takeOffIndex + flyLength;
            var indexToLand = ladyBugIndex;

            if (flyLength == 0)
            {
                return field;
            }
            if (flyLength < 0)
            {
                field = MoveLeft(field, ladyBugIndex, Math.Abs(flyLength));
                return field;
            }
            if (flight >= 0 && flight < field.Length)
            {

                if (field[flight] == 0)
                {
                    indexToLand = flight;

                    field[takeOffIndex] = 0;
                    field[indexToLand] = 1;
                }
                else
                {
                    indexToLand = -1;
                    for (var i = flight; i < field.Length; i += flyLength)
                    {
                        if (field[i] != 1)
                        {
                            indexToLand = i;
                            field[takeOffIndex] = 0;
                            field[indexToLand] = 1;
                            break;
                        }

                    }
                    if (indexToLand < 0)
                    {
                        field[takeOffIndex] = 0;
                    }
                }
            }
            else
            {
                field[takeOffIndex] = 0;
            }
            return field;
        }
    }
}