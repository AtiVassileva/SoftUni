using System;
using System.Linq;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var path = input.Split('\\', StringSplitOptions.RemoveEmptyEntries);
            var neededInfo = path.Last().Split('.', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var name = neededInfo.Take(neededInfo.Length - 1).ToArray();
            var fileName = string.Join('.', name);
            var extencion = neededInfo.Last();

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extencion}");
        }
    }
}