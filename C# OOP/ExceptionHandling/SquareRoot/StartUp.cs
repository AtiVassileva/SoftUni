using SquareRoot.Core;
using SquareRoot.Models;

namespace SquareRoot
{
    public class StartUp
    {
        public static void Main()
        {
            var calculator = new SquareRootCalculator();

            var engine = new Engine(calculator);
            engine.Run();
            
        }
    }
}
