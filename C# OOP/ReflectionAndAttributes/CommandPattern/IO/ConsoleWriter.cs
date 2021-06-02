using System;

namespace CommandPattern.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text) => 
            Console.WriteLine(text);
    }
}
