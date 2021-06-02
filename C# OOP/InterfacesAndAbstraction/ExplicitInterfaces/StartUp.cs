using System;
using System.Linq;
using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Core;
using ExplicitInterfaces.IO;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
