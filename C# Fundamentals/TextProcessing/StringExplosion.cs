using System;

namespace StringExplosion
{
    class Program
    {
        static void Main()
        {
            var field = Console.ReadLine();
            var bomb = 0;

            for (var i = 0; i < field.Length; i++)
            {
                if (bomb > 0 && field[i] != '>')
                {
                    field = field.Remove(i, 1); 
                    bomb--; 
                    i--; 
                }
                else if (field[i] == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString()); 
                }
            }
            Console.WriteLine(field);
        }
    }
}