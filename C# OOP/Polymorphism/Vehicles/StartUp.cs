
using Vehicles.Core;
using Vehicles.IO;

namespace Vehicles
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
