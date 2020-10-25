using System.Collections.Generic;
using Prototype.ConcretePrototype;

namespace Prototype.Models
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> _sandwiches =
            new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get => this._sandwiches[name];
            set => this._sandwiches.Add(name, value);
        }
    }
}
