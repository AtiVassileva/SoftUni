using System;
using System.Collections.Generic;
using System.Linq;
using P03.ShoppingSpree.Models;

namespace P03.ShoppingSpree.Core
{
    public class Engine
    {
        private List<Product> allProducts;
        private List<Person> allPeople;

        public Engine()
        {
            this.allProducts = new List<Product>();
            this.allPeople = new List<Person>();
        }

        public void Run()
        {
            
            var currentPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var currentProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            AddPeopleToRecords(currentPeople);

            AddProductsToRecords(currentProducts);

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var args = line.Split(" ", StringSplitOptions.None).ToArray();

                var customerName = args[0];
                var productName = args[1];

                try
                {
                    var currentPerson = allPeople.First(p => p.Name == customerName);
                    var currentProduct = allProducts.First(p => p.Name == productName);

                    Console.WriteLine(currentPerson.BuyProduct(currentProduct));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            PrintPeople();
        }

        private void PrintPeople()
        {
            foreach (var person in this.allPeople)
            {
                Console.WriteLine(person);
            }
        }

        private void AddProductsToRecords(string[] currentProducts)
        {
            for (int i = 0; i < currentProducts.Length; i++)
            {
                var currentArgs = currentProducts[i].
                    Split("=", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                    var productName = currentArgs[0];
                    var productCost = decimal.Parse(currentArgs[1]);

                    var product = new Product(productName, productCost);
                    allProducts.Add(product);
                
            }
        }

        private void AddPeopleToRecords(string[] currentPeople)
        {
            for (int i = 0; i < currentPeople.Length; i++)
            {
                var currentArgs = currentPeople[i].
                    Split("=", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                var name = currentArgs[0];
                var money = decimal.Parse(currentArgs[1]);

                var person = new Person(name, money);
                allPeople.Add(person);
            }
        }
    }
}
