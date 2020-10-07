namespace Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name) => this.Name = name;

        public string Name { get; protected set; }

        public abstract int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
