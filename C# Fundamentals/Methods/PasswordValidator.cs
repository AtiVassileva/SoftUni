using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (!CheckIfLengthIsValid(input))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!CheckIfIsLetterOrDigit(input))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!CheckIfHasAtLeastTwoDigits(input))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (CheckIfIsLetterOrDigit(input) && CheckIfLengthIsValid(input) && CheckIfHasAtLeastTwoDigits(input))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckIfLengthIsValid(string pass)
        {
            return pass.Length >= 6 && pass.Length <= 10;
        }

        static bool CheckIfIsLetterOrDigit(string pass)
        {
            foreach (var symbol in pass)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckIfHasAtLeastTwoDigits(string pass)
        {
            var digits = 0;
            foreach (var symbol in pass)
            {
                if (char.IsDigit(symbol))
                {
                    digits++;
                }
            }
            return digits >= 2;
        }
    }
}