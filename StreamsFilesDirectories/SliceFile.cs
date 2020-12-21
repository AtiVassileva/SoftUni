using System;
using System.IO;

namespace SliceFile
{
    class Program
    {
        static void Main()
        {
            using var stream = new FileStream("current.txt", FileMode.OpenOrCreate);

            var parts = 4;
            var length = stream.Length / parts;

            var buffer = new byte[length];

            for (var i = 0; i < parts; i++)
            {
                var bytesRead = stream.Read(buffer, 0, buffer.Length);

                using var currPartStream = new FileStream($"Part{i + 1}.txt", FileMode.OpenOrCreate);

                currPartStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}