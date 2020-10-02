using ExplicitInterfaces.Models;

namespace ExplicitInterfaces.Contracts
{
    public interface IPerson 
    {
        public string Name { get; }
        public int Age { get; }

        public string GetName();

    }
}
