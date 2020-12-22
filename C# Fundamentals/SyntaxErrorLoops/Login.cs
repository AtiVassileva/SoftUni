using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = Console.ReadLine();
            var correctPassword = string.Empty;

            for (var i = username.Length - 1; i >= 0; i--)
            {
                correctPassword += username[i];
            }

            for (var i = 1; i <= 4; i++)
            {
                var password = Console.ReadLine();

                if (correctPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }

                if (i <= 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {username} blocked!");
                }
            }
        }
    }
}