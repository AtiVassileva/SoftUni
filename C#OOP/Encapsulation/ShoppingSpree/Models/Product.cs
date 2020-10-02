using System;
using P03.ShoppingSpree.Common;

namespace P03.ShoppingSpree.Models
{
    public class Product
    {
        private const decimal MinMoney = 0;

        private string _name;
        private decimal _cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }

                this._name = value;
            }
        }

        public decimal Cost
        {
            get => this._cost;
            private set
            {
                if (value < MinMoney)
                {
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExceptionMessage);
                }
                this._cost = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
