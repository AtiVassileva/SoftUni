using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace P05.DirectoryTraversal
{
    class Program
    {
        static void Main()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var files = Directory.GetFiles(currentDirectory);

            var filesInfo = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                var currentFileInfo = new FileInfo(file);

                if (filesInfo.ContainsKey(currentFileInfo.Extension))
                {
                    filesInfo[currentFileInfo.Extension].Add(currentFileInfo.Name, currentFileInfo.Length);
                }
                else
                {
                    var dict = new Dictionary<string, double>
                    {
                        { currentFileInfo.Name, currentFileInfo.Length }
                    };
                    filesInfo.Add(currentFileInfo.Extension, dict);
                }
            }

            using var writer = new StreamWriter(@"C:\Users\My PC\source\repos\StreamsFilesDirectories\P05.DirectoryTraversal\report.txt");

            foreach (var kvp in filesInfo.OrderByDescending(k => k.Value.Count).ThenBy(name => name.Key))
            {
                writer.WriteLine(kvp.Key);
                foreach (var kvp1 in kvp.Value.OrderBy(x => x.Value))
                {
                    writer.WriteLine($"--{kvp1.Key} - {kvp1.Value / 1024:F3}kb");
                }
            }

            Console.WriteLine("Done! Check the \'report.txt' file in your directory. (Copy the full path.)");
        }
    }
}