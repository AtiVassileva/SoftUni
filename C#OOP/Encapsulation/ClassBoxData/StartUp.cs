using System;

namespace P01.ClassBoxData
{
    public class StartUp
    {
        public static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(width, length, height);
                Console.WriteLine($"Surface Area - {box.FindSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.FindLateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.FindVolume():F2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
