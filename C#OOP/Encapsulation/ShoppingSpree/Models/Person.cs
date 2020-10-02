using System;
using System.Collections.Generic;
using P03.ShoppingSpree.Common;

namespace P03.ShoppingSpree.Models
{
    public class Person
    {
        private const decimal MinMoney = 0;

        private string name;
        private decimal money;
        private readonly List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }

        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;

        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < MinMoney)
                {
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExceptionMessage);
                }

                this.money = value;
            }
        }

        public IReadOnlyList<Product> Bag => this.bag;

        public string BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.bag.Add(product);
                this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            return $"{this.Name} - {string.Join(", ", this.Bag)}";
        }
    }
}
