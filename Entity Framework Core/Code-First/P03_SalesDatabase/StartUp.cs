using System;
using P03_SalesDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var context = new SalesContext();
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}