using System;
using System.Linq;

namespace EncryptArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var names = new string[count];
            var nums = new int[count];

            for (var i = 0; i < count; i++)
            {
                names[i] = Console.ReadLine();
                var currentName = names[i];
                var sum = 0;

                for (var j = 0; j < currentName.Length; j++)
                {
                    if (currentName[j] == 'a' || currentName[j] == 'e' || currentName[j] == 'i' || currentName[j] == 'o' || currentName[j] == 'u'
                        || currentName[j] == 'A' || currentName[j] == 'E' || currentName[j] == 'I' || currentName[j] == 'O' || currentName[j] == 'U')
                    {
                        sum += (int)currentName[j] * currentName.Length;
                    }
                    else
                    {
                        sum += (int)currentName[j] / currentName.Length;
                    }
                }
                nums[i] = sum;
            }

            Array.Sort(nums);
            foreach (var number in nums)
            {
                Console.WriteLine(number);
            }
        }
    }
}