using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input = "";

            while((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if(!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }
                trainers[trainerName].Pokemons.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string pokemonElement = input;

                foreach(var (name, trainer) in trainers)
                {
                    if(trainer.Pokemons.Any(x => x.Element == pokemonElement))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons = trainer.Pokemons
                            .Select(pokemon => new Pokemon(pokemon.Name, pokemon.Element, pokemon.Health - 10))
                            .Where(p => p.Health > 0)
                            .ToList();
                    }
                }
            }

            foreach (var (name, trainer) in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
