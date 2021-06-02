using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Common;
using INStock.Contracts;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private readonly HashSet<string> productLabels;
        private readonly List<IProduct> productsByIndex;
        private readonly Dictionary<string, IProduct> productsByLabel;
        private readonly SortedDictionary<decimal, List<IProduct>> productsByPrice;
        private readonly Dictionary<int, List<IProduct>> productsByQuantity;

        public ProductStock()
        {
            this.productsByIndex = new List<IProduct>();
            this.productLabels = new HashSet<string>();
            this.productsByLabel = new Dictionary<string, IProduct>();
            this.productsByPrice = new SortedDictionary<decimal, List<IProduct>>(
                Comparer<decimal>.Create((first, second)
                    => second.CompareTo(first)));
            this.productsByQuantity = new Dictionary<int, List<IProduct>>();
        }

        public int Count => this.productsByIndex.Count;

        public IProduct this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.Find(index);
            }
            set
            {

                this.ValidateIndex(index);

                this.ValidateNullProduct(value);

                this.RemoveProductFromCollections(this.Find(index));

                this.InitializeCollections(value);


                this.productsByIndex[index] = value;

            }
        }

        public bool Contains(IProduct product)
        {
            ValidateNullProduct(product);
            return this.productLabels.Contains(product.Label);
        }

        public void Add(IProduct product)
        {
            ValidateNullProduct(product);

            if (this.productLabels.Contains(product.Label))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.DuplicateLabelExceptionMessage, product.Label));
            }

            this.InitializeCollections(product);

            this.productLabels.Add(product.Label);
            this.productsByIndex.Add(product);
            this.productsByLabel[product.Label] = product;

            this.productsByQuantity[product.Quantity].Add(product);

            this.productsByPrice[product.Price].Add(product);
        }

        public bool Remove(IProduct product)
        {
            ValidateNullProduct(product);
            var currentLabel = product.Label;

            if (!this.productLabels.Contains(currentLabel))
            {
                return false;
            }

            this.productsByIndex.RemoveAll(pr => pr.Label == currentLabel);
            this.RemoveProductFromCollections(product);

            return true;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException
                    (ExceptionMessages.IndexOutOfRangeExceptionMessage);
            }

            return this.productsByIndex[index];
        }

        public IProduct FindByLabel(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
            {
                throw new ArgumentNullException
                    (ExceptionMessages.NullOrWhitespaceLabelExceptionMessage);
            }

            if (productLabels.All(l => l != label))
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidLabelExceptionMessage);
            }

            return this.productsByLabel[label];
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (!this.productsByPrice.Any())
            {
                throw new InvalidOperationException
                    (ExceptionMessages.EmptyProductStockExceptionMessage);
            }

            var mostExpensiveProducts = this.productsByPrice.First().Value;
            var firstAddedExpensiveProduct = mostExpensiveProducts.First();

            return firstAddedExpensiveProduct;
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            var result = new List<IProduct>();

            foreach (var kvp
                in this.productsByPrice.Where(k =>
                    k.Key >= lo && k.Key <= hi))
            {
                result.AddRange(kvp.Value);
            }

            return result;
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return !productsByPrice.ContainsKey(price)
                ? Enumerable.Empty<IProduct>() : this.productsByPrice[price];
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return !this.productsByQuantity.ContainsKey(quantity) ?
                Enumerable.Empty<IProduct>() : this.productsByQuantity[quantity];
        }

        public IEnumerator<IProduct> GetEnumerator()
            => this.productsByIndex.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private bool IndexIsOutOfRange(int index)
        {
            return index < 0 || index >= this.Count;
        }

        private void ValidateNullProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException
                    (ExceptionMessages.NullProductExceptionMessage);
            }
        }

        private void InitializeCollections(IProduct product)
        {
            if (!this.productsByQuantity.ContainsKey(product.Quantity))
            {
                this.productsByQuantity[product.Quantity] =
                    new List<IProduct>();
            }

            if (!this.productsByPrice.ContainsKey(product.Price))
            {
                this.productsByPrice[product.Price] =
                    new List<IProduct>();
            }

        }

        private void RemoveProductFromCollections(IProduct product)
        {
            var currentLabel = product.Label;

            this.productLabels.Remove(currentLabel);
            this.productsByLabel.Remove(currentLabel);

            var allWithProductQuantity = this.productsByQuantity[product.Quantity];

            allWithProductQuantity.RemoveAll(pr => pr.Label == currentLabel);

            var allWithProductPrice = this.productsByPrice[product.Price];

            allWithProductPrice.RemoveAll(pr => pr.Label == currentLabel);

        }

        private void ValidateIndex(int index)
        {
            if (this.IndexIsOutOfRange(index))
            {
                throw new IndexOutOfRangeException
                    (ExceptionMessages.IndexOutOfRangeExceptionMessage);
            }
        }
    }
}