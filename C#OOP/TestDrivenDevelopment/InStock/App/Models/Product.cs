using System;
using INStock.Common;
using INStock.Contracts;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get => this.label;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrWhitespaceLabelExceptionMessage);
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException(ExceptionMessages.LessThanThreeSymbolsExceptionMessage);
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativePriceExceptionMessage);
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeQuantityExceptionMessage);
                }

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
            => this.Price.CompareTo(other.Price);
    }
}