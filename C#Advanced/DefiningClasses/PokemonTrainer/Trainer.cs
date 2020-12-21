using System.Linq;
using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        private List<Pokemon> caughtPokemons;
        private int numberOfBadges;

        public Trainer(string name)
        {
            this.Name = name;
            this.numberOfBadges = 0;
            this.caughtPokemons = new List<Pokemon>();

        }
        public string Name { get; }

        public int NumberOfBadges => this.numberOfBadges;

        public IReadOnlyCollection<Pokemon> CaughtPokemons => this.caughtPokemons;

        public void AddPokemon(Pokemon pokemon)
        {
            if (!this.caughtPokemons.Contains(pokemon))
            {
                caughtPokemons.Add(pokemon);
            }
        }

        public void LosePokemonHealth()
        {
            foreach (var pokemon in this.caughtPokemons)
            {
                pokemon.Health -= 10;
            }
        }

        public void RemoveDeathPokemons()
        {
            var deathPokemons = this.caughtPokemons.Where(p => p.Health <= 0).ToList();

            if (deathPokemons != null)
            {
                foreach (var pokemon in deathPokemons)
                {
                    this.caughtPokemons.Remove(pokemon);
                }
            }
        }

        public bool ContainsPokemonWithElement(string element)
        {
            return this.caughtPokemons.Any(p => p.Element == element);
        }

        public void IncreaseBadges()
        {
            this.numberOfBadges++;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.CaughtPokemons.Count}".TrimEnd();
        }
    }
}