using System;
using System.Collections.Generic;
using System.Linq;
using CollectionHierarchy.Core;
using CollectionHierarchy.IO;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
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
