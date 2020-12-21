using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            const int defSize = 4096;
            using FileStream reader = new FileStream("./copyMe.png", FileMode.Open);

            using FileStream writer = new FileStream("../../../copied.png", FileMode.Create);

            var buffer = new byte[defSize];

            while (reader.CanRead)
            {
                var bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}