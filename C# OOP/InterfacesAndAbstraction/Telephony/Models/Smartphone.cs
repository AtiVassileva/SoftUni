using System.Linq;
using Telephony.Common;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowesable
    {
        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new InvalidNumberException();
            }
            return $"Calling... {number}";
        }

        public string Browse(string website)
        {
            if (website.Any(char.IsDigit))
            {
               throw new InvalidWebsiteException();
            }
            return $"Browsing: {website}!";
        }
    }
}


