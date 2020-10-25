using System;
using Chainblock.Common;
using Chainblock.Models;
using NUnit.Framework;
using static Chainblock.Common.GlobalConstants;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private Transaction transaction;

        [SetUp]
        public void SetUp()
        {
            this.transaction = this.SetDefaultTransaction();
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            //Arrange
            var expectedId = DefaultId;
            var expectedStatus = DefaultStatus;
            var expectedSender = DefaultSender;
            var expectedReciever = DefaultReciever;
            var expectedAmount = DefaultAmount;

            //Act
            this.transaction = this.SetDefaultTransaction();

            var actualId = this.transaction.Id;
            var actualStatus = this.transaction.Status;
            var actualSender = this.transaction.From;
            var actualReciever = this.transaction.To;
            var actualAmount = this.transaction.Amount;

            //Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedStatus, actualStatus);
            Assert.AreEqual(expectedSender, actualSender);
            Assert.AreEqual(expectedReciever, actualReciever);
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        [TestCase(-20)]
        [TestCase(0)]
        public void IdShouldThrowExceptionWhenZeroOrNegative(int id)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                this.transaction = new Transaction(id, DefaultStatus, DefaultSender, DefaultReciever, DefaultAmount);
            }, ExceptionMessages.InvalidIdExceptionMessage);
        }

        [Test]
        public void IdShouldSetCorrectValueWhenValid()
        {
            //Arrange
            var expectedId = DefaultId;

            //Act
            this.transaction = this.SetDefaultTransaction();

            var actualId = this.transaction.Id;

            //Assert
            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void SenderAndRecieverNamesShouldThrowExceptionWhenLessThanThreeSymbols()
        {
            //Assert for Invalid DefaultSender Name
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                this.transaction = new Transaction
                    (DefaultId, DefaultStatus, "Bo", DefaultReciever, DefaultAmount);

            }, string.Format(ExceptionMessages.
                LessThanThreeSymbolsNameExceptionMessage, "DefaultSender"));

            //Assert for Invalid DefaultReciever Name
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                this.transaction = new Transaction
                    (DefaultId, DefaultStatus, DefaultSender, "Mo", DefaultAmount);

            }, string.Format(ExceptionMessages.
                LessThanThreeSymbolsNameExceptionMessage, "DefaultReciever"));
        }

        [TestCase("")]
        [TestCase("      ")]
        [TestCase(null)]
        public void SenderAndRecieverNamesShouldThrowExceptionWhenNullOrWhiteSpace(string givenName)
        {
            //Assert for Invalid DefaultSender Name
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    //Arrange & Act
                    this.transaction = new Transaction
                        (DefaultId, DefaultStatus, givenName, DefaultReciever, DefaultAmount);
                },
                string.Format(ExceptionMessages.
                    NullOrWhiteSpaceNameExceptionMessage, "DefaultSender"));

            //Assert for Invalid DefaultReciever Name
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    //Arrange & Act
                    this.transaction = new Transaction
                        (DefaultId, DefaultStatus, DefaultSender, givenName, DefaultAmount);
                },
                string.Format(ExceptionMessages.
                    NullOrWhiteSpaceNameExceptionMessage, "DefaultReciever"));
        }

        [Test]
        public void SenderAndRecieverNamesShouldSetCorrectValueWhenValid()
        {
            //Arrange
            var expectedSender = DefaultSender;
            var expectedReciever = DefaultReciever;

            //Act
            this.transaction = this.SetDefaultTransaction();

            var actualSender = this.transaction.From;
            var actualReciever = this.transaction.To;

            //Assert
            Assert.AreEqual(expectedSender, actualSender);
            Assert.AreEqual(expectedReciever, actualReciever);
        }

        [Test]
        [TestCase(-200)]
        [TestCase(0)]
        public void AmountShouldThrowExceptionWhenZeroOrNegative(double givenAmount)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                this.transaction = new Transaction(DefaultId, DefaultStatus, DefaultSender, DefaultReciever, givenAmount);
            },
                ExceptionMessages.ZeroOrNegativeAmountExceptionMessage);
        }

        [Test]
        public void AmountShouldSetCorrectValueWhenValid()
        {
            //Arrange
            var expectedAmount = DefaultAmount;

            //Act
            this.transaction = this.SetDefaultTransaction();
            var actualAmount = this.transaction.Amount;

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }
        private Transaction SetDefaultTransaction()
        {
            return new Transaction
                (DefaultId, DefaultStatus, DefaultSender, DefaultReciever, DefaultAmount);
        }
    }
}