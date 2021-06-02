using System;
using System.Linq;
using INStock.Common;
using INStock.Models;

namespace INStock.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        private const string TestProductLabel = "Keyboard";
        private const decimal TestProductPrice = 70;
        private const int TestProductQuantity = 1;

        private const string SecondProductLabel = "Headphones";
        private const decimal SecondProductPrice = 40;
        private const int SecondProductQuantity = 1;

        private ProductStock productStock;
        private Product testProduct;
        private Product anotherProduct;

        [SetUp]
        public void SetUp()
        {
            this.productStock = new ProductStock();
            this.testProduct = new Product(TestProductLabel, TestProductPrice, TestProductQuantity);
            this.anotherProduct = new Product("Headphones", 40, 1);
        }

        [Test]
        public void AddShouldSaveTheProduct()
        {
            //Act
            this.productStock.Add(this.testProduct);
            var productInStock = productStock.FindByLabel(TestProductLabel);

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(TestProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(TestProductPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(TestProductQuantity));

        }

        [Test]
        public void AddShouldThrowExceptionWithDuplicateLabel()
        {
            // Arrange & Act
            this.AddMultipleProductsToStock();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.Add(this.testProduct);

            }, string.Format(ExceptionMessages.
                DuplicateLabelExceptionMessage, this.testProduct.Label));
        }

        [Test]
        public void RemoveShouldReturnTrueWhenSuccessful()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var result = this.productStock.Remove(this.testProduct);

            //Assert
            Assert.That(result, Is.True);
            Assert.That(this.productStock.Count, Is.EqualTo(2));
            Assert.That(this.productStock[0], Is.EqualTo(this.anotherProduct));
        }

        [Test]
        public void RemoveShouldReturnFalseWhenNotSuccessful()
        {
            //Arrange
            var product = new Product("Test 1", 43, 1);
            this.AddMultipleProductsToStock();

            //Act
            var result = this.productStock.Remove(product);

            //Assert
            Assert.That(result, Is.False);
            Assert.That(this.productStock.Count, Is.EqualTo(3));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenProductIsNull()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Arrange & Act
                this.productStock.Remove(null);

            }, ExceptionMessages.NullProductExceptionMessage);
        }

        [Test]
        public void ContainsShouldReturnTrueWhenProductExists()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var result = this.productStock.Contains(this.testProduct);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsShouldReturnFalseWhenProductDoesNotExists()
        {
            //Act
            var result = this.productStock.Contains(this.testProduct);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.productStock.Contains(null);
            },
                ExceptionMessages.NullProductExceptionMessage);
        }

        [Test]
        public void CountShouldReturnCorrectProductCount()
        {
            //Arrange 
            var expectedCount = 3;

            //Act
            this.AddMultipleProductsToStock();

            var actualCount = this.productStock.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FindShouldReturnCorrectProductByIndex()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var productInStock = this.productStock.Find(1);

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(SecondProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(SecondProductPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(SecondProductQuantity));

        }

        [Test]
        public void FindShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                //Arrange & Act
                this.productStock.Find(0);

            }, ExceptionMessages.IndexOutOfRangeExceptionMessage);
        }

        [Test]
        public void FindByLabelShouldReturnProductByGivenLabel()
        {
            //Arrange
            this.productStock.Add(this.testProduct);

            //Act
            var foundProduct = this.productStock.FindByLabel(TestProductLabel);

            //Assert
            Assert.AreEqual(this.testProduct, foundProduct);
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenNoSuchProduct()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                this.productStock.FindByLabel(TestProductLabel);

            }, ExceptionMessages.InvalidLabelExceptionMessage);
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelIsNull()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Arrange & Act
                this.productStock.FindByLabel(null);

            }, ExceptionMessages.InvalidLabelExceptionMessage);
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollectionWhenNoMatches()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var result = this.productStock.FindAllInRange(140m, 160m);


            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnCorrectCollectionInCorrectOrder()
        {
            //Arrange
            this.productStock.Add(this.testProduct);
            this.productStock.Add(this.anotherProduct);

            //Act
            var result = this.productStock.
                FindAllInRange(SecondProductPrice, TestProductPrice).ToList();

            //Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Price, Is.EqualTo(TestProductPrice));
            Assert.That(result[1].Price, Is.EqualTo(SecondProductPrice));
        }

        [Test]
        public void FindAllByPriceShouldReturnEmptyCollectionWhenNoMatches()
        {
            //Arrange
            this.productStock.Add(this.testProduct);
            this.productStock.Add(this.anotherProduct);

            //Act
            var result = this.productStock.FindAllByPrice(80m);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByPriceShouldReturnCorrectCollection()
        {
            //Arrange
            this.productStock.Add(this.anotherProduct);

            //Act
            var result = this.productStock.
                FindAllByPrice(SecondProductPrice).ToList();

            //Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Label, Is.EqualTo(SecondProductLabel));
        }

        [Test]
        public void FindMostExpensiveProductShouldReturnCorrectProduct()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var result = this.productStock.FindMostExpensiveProduct();

            //Assert
            Assert.That(result.Price, Is.EqualTo(TestProductPrice));
            Assert.That(result.Label, Is.EqualTo(TestProductLabel));
        }
        [Test]
        public void FindMostExpensiveProductShouldThrowExceptionWhenProductStockEmpty()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange & Act
                this.productStock.FindMostExpensiveProduct();

            }, ExceptionMessages.EmptyProductStockExceptionMessage);
        }

        [Test]
        public void FindAllByQuantityShouldReturnEmptyCollectionWhenNoMatches()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var result = this.productStock.FindAllByQuantity(3);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByQuantityShouldReturnCollectCollection()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var result = this.productStock.FindAllByQuantity(1).ToList();

            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetEnumeratorShouldReturnProductsInCorrectInsertionOrder()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var result = this.productStock.ToList();

            //Assert
            Assert.That(result[0].Label, Is.EqualTo(TestProductLabel));
            Assert.That(result[1].Label, Is.EqualTo(SecondProductLabel));
            Assert.That(result[2].Label, Is.EqualTo("Mouse"));

        }

        [Test]
        public void GetIndexShouldReturnCorrectProductByIndex()
        {
            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            var productInStock = this.productStock[1];

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(SecondProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(SecondProductPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(SecondProductQuantity));

        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                //Arrange & Act
                var res = this.productStock[3];

            }, ExceptionMessages.IndexOutOfRangeExceptionMessage);

        }

        [Test]
        public void SetIndexShouldChangeProduct()
        {
            const string productLabel = "Speakers";
            const decimal productPrice = 25;
            const int productQuantity = 1;

            //Arrange
            this.AddMultipleProductsToStock();

            //Act
            this.productStock[1] = new Product(productLabel, productPrice, productQuantity);

            //Assert
            var productInStock = this.productStock.Find(1);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(productLabel));
            Assert.That(productInStock.Price, Is.EqualTo(productPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(productQuantity));
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                //Arrange & Act
                var res = this.productStock[-1];

            }, ExceptionMessages.IndexOutOfRangeExceptionMessage);
        }
        private void AddMultipleProductsToStock()
        {
            this.productStock.Add(this.testProduct);
            this.productStock.Add(this.anotherProduct);
            this.productStock.Add(new Product("Mouse", 20, 1));
        }
    }
}