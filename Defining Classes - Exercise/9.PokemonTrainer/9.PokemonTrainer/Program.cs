using System;
using System.Linq;

namespace _9.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = "";

            while((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                int trainerIndex = trainers.FindIndex(x => x.Name == trainerName);

                if(trainerIndex == -1)
                {
                    trainers.Add(new Trainer(trainerName));
                    trainerIndex = trainers.Count - 1;
                }
                trainers[trainerIndex].Pokemons.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string pokemonElement = input;

                foreach(Trainer trainer in trainers)
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

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
