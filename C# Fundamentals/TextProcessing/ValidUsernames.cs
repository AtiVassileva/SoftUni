using System;
using System.Linq;
using System.Text;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.None).ToArray();
            var sb = new StringBuilder();

            foreach (var username in input)
            {
                if (ValidateUsername(username))
                {
                    Console.WriteLine(username);
                }
            }

        }

        static bool ValidateUsername(string username)
        {
            if (username.Length > 16 || username.Length < 3)
            {
                return false;
            }

            var isValid = true;

            for (var i = 0; i < username.Length; i++)
            {
                var current = username[i];

                if (!char.IsLetterOrDigit(current) || current == '-' || current == '_')
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}