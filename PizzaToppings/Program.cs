using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PizzaToppings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Taking text and turning it into a thing
            var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText(@"./pizzas.json"));

            //can now see toppings in a list
            var toppingLists = pizzas.Select(p => string.Join(", ", p.Toppings.OrderBy(t => t))); //order this thing by itself

            //var distinctToppingCombinations = toppingLists.Distinct(); //Linq method

            var countOfCombination = new Dictionary<string, int>(); //dictionary keys have to be unique
            foreach (var combination in toppingLists)
            {
                if (countOfCombination.ContainsKey(combination))
                    {
                    countOfCombination.Add(combination, 1);
                    }
                    else
                {
                    countOfCombination[combination] += 1;
                }
        }
            var mostOrdered = countOfCombination.OrderByDescending(item => item.Value).Take(20);

            foreach (var (combination, count) in mostOrdered)
            {
                Console.WriteLine($"The topping combination of {combination} was ordered {count} this many times.");
            }
        }
    }
}
