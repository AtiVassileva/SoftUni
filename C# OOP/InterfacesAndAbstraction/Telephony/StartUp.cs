using System;
using System.Linq;
using Telephony.Core;
using Telephony.IO;

namespace Telephony
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
