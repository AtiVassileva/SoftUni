using System;
using System.Collections.Generic;

namespace Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
