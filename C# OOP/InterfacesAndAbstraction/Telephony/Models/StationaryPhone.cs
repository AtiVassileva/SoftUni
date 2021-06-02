using System.Linq;
using Telephony.Common;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        
        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new InvalidNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}
