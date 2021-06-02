using System;
using System.Collections.Generic;
using System.Linq;
using P03.ShoppingSpree.Core;
using P03.ShoppingSpree.Models;

namespace P03.ShoppingSpree
{
    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();
            try
            {
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
