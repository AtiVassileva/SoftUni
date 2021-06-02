using System;
using System.Linq;
using System.Collections.Generic;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allTrainers = new List<Trainer>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Tournament")
                {
                    break;
                }

                var inputArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var trainerName = inputArgs[0];
                var pokemonName = inputArgs[1];
                var pokemonElement = inputArgs[2];
                var pokemonHealth = int.Parse(inputArgs[3]);

                Trainer trainer;

                if (allTrainers.All(x => x.Name != trainerName))
                {
                    trainer = new Trainer(trainerName);
                    allTrainers.Add(trainer);
                }
                else
                {
                    trainer = allTrainers.First(t => t.Name == trainerName);
                }

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainer.AddPokemon(pokemon);
            }

            while (true)
            {
                var element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }

                foreach (var trainer in allTrainers)
                {
                    if (trainer.ContainsPokemonWithElement(element))
                    {
                        trainer.IncreaseBadges();
                    }
                    else
                    {
                        trainer.LosePokemonHealth();
                        trainer.RemoveDeathPokemons();
                    }
                }
            }

            foreach (var trainer in allTrainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}