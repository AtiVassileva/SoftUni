using System;
using INStock.Common;
using INStock.Models;

namespace INStock.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void QuantityCannotBeNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Arrange & Act
                var product = new Product("Test Product Label", 20, -3);

            }, ExceptionMessages.NegativeQuantityExceptionMessage);

        }

        [TestCase(null)]
        [TestCase("       ")]
        [TestCase("")]
        public void LabelCannotBeNullOrWhitespace(string label)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                var product = new Product(label, 30, 2);

            }, ExceptionMessages.NullOrWhitespaceLabelExceptionMessage);
        }

        [TestCase("Ab")]
        [TestCase("C")]
        public void LabelCannotHaveLessThanThreeSymbols(string label)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                var product = new Product(label, 43, 3);

            }, ExceptionMessages.LessThanThreeSymbolsExceptionMessage);
        }

        [Test]
        public void PriceCannotBeNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                var product = new Product("Test label", -30, 1);

            }, ExceptionMessages.NegativePriceExceptionMessage);
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsIncorrect()
        {
            //Arrange
            var firstProduct = new Product("Test Product Label 1", 30, 1);
            var secondProduct = new Product("Test Product Label 2", 20, 1);

            //Act
            var incorrectOrderResult = firstProduct.CompareTo(secondProduct);

            //Assert
            Assert.That(incorrectOrderResult > 0, Is.True);

        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsCorrect()
        {
            //Arrange
            var firstProduct = new Product("Test Product Label 1", 10, 1);
            var secondProduct = new Product("Test Product Label 2", 5, 1);

            //Act
            var correctOrderResult = secondProduct.CompareTo(firstProduct);

            //Assert
            Assert.That(correctOrderResult < 0, Is.True);
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsEqual()
        {
            //Arrange
            var firstProduct = new Product("Test Product Label 1", 10, 1);
            var secondProduct = new Product("Test Product Label 2", 10, 1);

            //Act
            var equalOrderResult = firstProduct.CompareTo(secondProduct);

            //Assert
            Assert.That(equalOrderResult == 0, Is.True);
        }
    }
}