using System;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var context = new FootballBettingContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}