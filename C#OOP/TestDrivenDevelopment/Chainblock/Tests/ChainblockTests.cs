using System;
using System.Linq;
using NUnit.Framework;
using Chainblock.Enums;
using Chainblock.Common;
using System.Collections.Generic;

namespace Chainblock.Tests
{
    using Core;
    using Models;
    using Contracts;

    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction transaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
            this.transaction = new Transaction
            (GlobalConstants.DefaultId, GlobalConstants.DefaultStatus, GlobalConstants.DefaultSender,
                GlobalConstants.DefaultReciever, GlobalConstants.DefaultAmount);
        }

        [Test]
        public void TestIfConstructorWorksProperly()
        {
            //Arrange
            var expectedCount = 0;

            //Act
            var actualCount = this.chainblock.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldIncreaseCountWhenSuccess()
        {
            //Arrange
            var expectedCount = 1;

            //Act
            this.chainblock.Add(transaction);

            var actualCount = this.chainblock.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenThereIsSuchTransaction()
        {
            //Arrange & Act
            this.AddDefaultTransaction();

            //Assert
            Assert.Throws<InvalidOperationException>(this.AddDefaultTransaction,
                ExceptionMessages.ExistingTransactionExceptionMessage);
        }

        [Test]
        public void AddingSameTransactionWithDifferentIdShouldPass()
        {
            //Arrange
            var expectedCount = 2;
            var transactionCopy = new Transaction(2, GlobalConstants.DefaultStatus, GlobalConstants.DefaultSender,
                GlobalConstants.DefaultReciever, GlobalConstants.DefaultAmount);

            //Act
            this.AddDefaultTransaction();
            this.chainblock.Add(transactionCopy);

            var actualCount = this.chainblock.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ContainsShouldReturnTrueWithExistingTransaction()
        {
            //Arrange
            this.AddDefaultTransaction();

            //Act
            var result = this.chainblock.Contains(this.transaction);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsShouldReturnFalseWithNonExistingTransaction()
        {
            //Arrange
            var ts = new Transaction(3, TransactionStatus.Aborted,
                "Seb", "Deb", 30);

            //Act
            var result = this.chainblock.Contains(ts);

            //Arrange
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsByIdShouldReturnTrueWithExistingId()
        {
            //Arrange
            this.AddDefaultTransaction();

            //Act
            var result = this.chainblock.Contains(GlobalConstants.DefaultId);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsByIdShouldReturnFalseWithNonExistingId()
        {
            //Arrange & Act
            var result = this.chainblock.Contains(9);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ChangeTransactionShouldChangeStatusWhenSuccessful()
        {
            //Arrange
            this.AddDefaultTransaction();
            var newStatus = TransactionStatus.Failed;

            //Act
            this.chainblock.ChangeTransactionStatus(GlobalConstants.DefaultId, newStatus);

            var actualStatus = this.transaction.Status;

            //Assert
            Assert.AreEqual(newStatus, actualStatus);
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowExceptionWithNonExistingId()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Arrange & Act
                this.chainblock.ChangeTransactionStatus(7, GlobalConstants.DefaultStatus);
            }, ExceptionMessages.NonExistingTransactionExceptionMessage);
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveTransactionWithValidId()
        {
            //Arrange
            var expectedCount = 0;
            this.AddDefaultTransaction();

            //Act
            this.chainblock.RemoveTransactionById(GlobalConstants.DefaultId);
            var actualCount = this.chainblock.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowExceptionWithNonExistingId()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange & Act
                this.chainblock.RemoveTransactionById(13);
            },
                ExceptionMessages.RemoveNonExistingTransactionExceptionMessage);
        }


        [Test]
        public void GetByIdShouldReturnCorrectTransactionWhenSuccess()
        {
            //Arrange
            this.AddDefaultTransaction();

            //Act
            var matchedTransaction = this.chainblock.GetById(GlobalConstants.DefaultId);

            //Assert
            Assert.AreEqual(this.transaction, matchedTransaction);

        }

        [Test]
        public void GetByIdShouldThrowExceptionWithNonExistingId()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arrange & Act
                this.chainblock.GetById(99);

            }, ExceptionMessages.NonExistingTransactionExceptionMessage);
        }

        [Test]
        public void GetByTransactionStatusShouldReturnCorrectCollection()
        {
            //Arrange
            this.AddManyTransactions();
            var expectedCount = 2;

            //Act
            var actualResult = this.chainblock.GetByTransactionStatus
                (TransactionStatus.Successful).ToList();

            var actualCount = actualResult.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.That(actualResult[0].Amount, Is.GreaterThan(actualResult[1].Amount));
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenNoMatches()
        {
            //Arrange
            this.AddManyTransactions();

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized);
            },
                ExceptionMessages.NoMatchesWithThisStatusExceptionMessage);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnCorrectCollection()
        {
            //Arrange
            var status = TransactionStatus.Successful;
            var expectedCount = 2;
            this.AddManyTransactions();

            //Act
            var collection = this.chainblock
                .GetAllSendersWithTransactionStatus(status).ToList();

            //Assert
            Assert.AreEqual(expectedCount, collection.Count);

            Assert.That(collection[0], Is.EqualTo("Mike1"));
            Assert.That(collection[1], Is.EqualTo("Mike"));

        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenNoMatches()
        {
            //Arrange
            var status = TransactionStatus.Aborted;
            var message = string.Format(ExceptionMessages.NoPersonWithGivenStatusExceptionMessage, "sender");

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Act
                    this.chainblock.GetAllSendersWithTransactionStatus(status);
                }, message);
        }

        [Test]
        public void GetAllRecieversWithTransactionStatusShouldReturnCorrectCollection()
        {
            //Arrange
            var status = TransactionStatus.Successful;
            var expectedCount = 2;
            this.AddManyTransactions();

            //Act
            var collection = this.chainblock
                .GetAllReceiversWithTransactionStatus(status).ToList();

            //Assert
            Assert.AreEqual(expectedCount, collection.Count);

            Assert.That(collection[0], Is.EqualTo("Steve1"));
            Assert.That(collection[1], Is.EqualTo("Steve"));
        }

        [Test]
        public void GetAllRecieversShouldThrowExceptionWhenNoMatches()
        {
            //Arrange
            var status = TransactionStatus.Aborted;
            var message = string.Format(ExceptionMessages.NoPersonWithGivenStatusExceptionMessage, "reciever");

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Act
                    this.chainblock.GetAllReceiversWithTransactionStatus(status);
                }, message);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnCorrectCollection()
        {
            //Arrange
            var expectedCount = 4;

            //Act
            var expectedCollection = this.FillCollection().OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

            var actualCollection = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();
            var actualCount = actualCollection.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);

        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldThrowExceptionWhenNoMatches()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Arrange & Act
                    this.chainblock.GetAllOrderedByAmountDescendingThenById();
                },
                ExceptionMessages.EmptyCollectionExceptionMessage);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnCorrectCollection()
        {
            //Arrange
            var givenSender = "Mike";

            //Act
            var expectedCollection = this.FillCollection().OrderByDescending(t => t.Amount)
                .Where(t => t.From == givenSender).ToList();

            var actualCollection = this.chainblock.GetBySenderOrderedByAmountDescending(givenSender).ToList();

            //Assert
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
            Assert.AreEqual(expectedCollection.Count, actualCollection.Count);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionWhenNoMatches()
        {
            //Arrange
            var givenSender = "Mike";

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Act
                    this.chainblock.GetBySenderOrderedByAmountDescending(givenSender);
                },
                ExceptionMessages.NoTransactionsExceptionMessage);
        }

        [Test]
        public void GetByRecieverOrderedByAmountThenByIdShouldReturnCorrectCollection()
        {
            //Arrange
            var givenReciever = "Steve";

            //Act
            var expectedCollection = this.FillCollection().OrderBy(t => t.Amount).ThenBy(t => t.Id)
                .Where(t => t.To == givenReciever).ToList();

            var actualCollection = this.chainblock.GetByReceiverOrderedByAmountThenById(givenReciever).ToList();

            //Assert
            Assert.AreEqual(expectedCollection, actualCollection);
            Assert.AreEqual(expectedCollection.Count, actualCollection.Count);
        }

        [Test]
        public void GetByRecieverOrderedByAmountThenByIdShouldThrowExceptionWhenNoMatches()
        {
            //Arrange
            var givenReciever = "Steve";

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Act
                    this.chainblock.GetByReceiverOrderedByAmountThenById(givenReciever);
                },
                ExceptionMessages.NoTransactionsExceptionMessage);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnCorrectTransaction()
        {
            //Arrange
            var status = TransactionStatus.Successful;

            var amount = 22;

            //Act
            var expectedCollection =
                this.FillCollection().Where(t => t.Status == status &&
                                                 t.Amount <= amount).OrderByDescending(t => t.Amount).ToList();

            var actualCollection = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount).ToList();

            //Assert
            Assert.AreEqual(expectedCollection.Count, actualCollection.Count);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldThrowExceptionWhenNoMatches()
        {
            //Arrange
            var status = TransactionStatus.Successful;
            var amount = 21;

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Act
                    this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount);
                },
                ExceptionMessages.NoTransactionsExceptionMessage);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnCorrectCollection()
        {
            //Arrange
            var sender = "Mike";
            var amount = 20;

            //Act
            var expectedCollection = this.FillCollection().Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount).ToList();

            var actualCollection = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount).ToList();

            //Assert
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
            Assert.AreEqual(expectedCollection.Count, actualCollection.Count);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowExceptionWhenNoMatches()
        {
            //Arrange
            var sender = "Mike";
            var amount = 20;

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Act
                    this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);
                },
                ExceptionMessages.NoTransactionsExceptionMessage);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnCorrectCollection()
        {
            //Arrange
            var reciever = "Steve";
            var lo = 20;
            var hi = 23;

            //Act
            var expectedCollection = this.FillCollection().Where(t =>
                    t.To == reciever && t.Amount >= lo && t.Amount <= hi)
                .OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            var actualCollection = this.chainblock.GetByReceiverAndAmountRange(reciever, lo, hi).ToList();

            //Assert
            Assert.AreEqual(expectedCollection.Count, actualCollection.Count);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionWhenNoMatches()
        {
            //Arrange
            var reciever = "Steve";
            var lo = 20;
            var hi = 23;

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    //Act
                    this.chainblock.GetByReceiverAndAmountRange(reciever, lo, hi);
                },
                ExceptionMessages.NoTransactionsExceptionMessage);
        }
        [Test]
        public void GetAllAmountInRangeShouldReturnCorrectCollection()
        {
            //Arrange
            var lo = 20;
            var hi = 24;

            //Act
            var expectedCollection = this.FillCollection().Where(t => t.Amount >= lo && t.Amount <= hi).ToList();

            var actualCollection = this.chainblock.GetAllInAmountRange(lo, hi).ToList();

            //Assert
            Assert.AreEqual(expectedCollection.Count, actualCollection.Count);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetAllAmountInRangeShouldReturnEmptyCollectionWhenNoMatches()
        {
            //Arrange
            var lo = 200;
            var hi = 300;

            //Act
            var collection = this.chainblock.GetAllInAmountRange(hi, lo);

            //Assert
            Assert.That(collection, Is.Empty);
        }

        private void AddDefaultTransaction()
        {
            this.chainblock.Add(this.transaction);
        }

        private void AddManyTransactions()
        {
            this.AddDefaultTransaction();

            for (var i = 0; i < 3; i++)
            {
                var id = i + 10;
                var status = (TransactionStatus)i;
                var sender = "Mike" + i;
                var reciever = "Steve" + i;
                var amount = 10 + i;

                var ts = new Transaction(id, status, sender, reciever, amount);
                this.chainblock.Add(ts);
            }
        }

        private IEnumerable<ITransaction> FillCollection()
        {
            var collection = new List<ITransaction>();

            for (var i = 0; i < 4; i++)
            {
                var id = i + 20;
                var sender = "Mike";
                var reciever = "Steve";
                var status = (TransactionStatus)i;
                var amount = i + 20;

                var ts = new Transaction(id, status, sender, reciever, amount);
                collection.Add(ts);
                chainblock.Add(ts);
            }

            return collection;
        }
    }
}