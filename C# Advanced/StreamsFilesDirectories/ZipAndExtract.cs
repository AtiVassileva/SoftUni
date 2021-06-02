using System;
using System.IO;
using System.IO.Compression;

namespace P06.ZipAndExtract
{
    class Program
    {
        static void Main()
        {
            var filePath = "copyMe.png";

            var zipArchive = ZipFile.Open("../../../Result.zip", ZipArchiveMode.Create);
            // creating a zip archive

            zipArchive.CreateEntryFromFile(filePath, "copiedPicture.png");
            // archiving copy.png in the zip file

            Console.WriteLine("Done! Check for a 'Result.zip' file in your directory.");
        }
    }
}