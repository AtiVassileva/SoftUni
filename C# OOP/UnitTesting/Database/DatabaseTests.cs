using System;
using NUnit.Framework;

namespace Tests
{
    using Database;
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database(initialData);
        }

        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        public void TestIfConstructorWorksProperly(int[] data)
        {
            this.database = new Database(data);

            var expectedCount = data.Length;
            var actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenBiggerCollection()
        {
            var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database(data);
            });
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            this.database.Add(3);
            var expectedCount = 3;
            var actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenDatabaseFull()
        {
            // 1, 2, 3 ... 16

            for (var num = 3; num <= 16; num++)
            {
                this.database.Add(num);
            }

            //Collection is full

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }

        [Test]
        public void RemoveDecreaseCount()
        {
            // Arrange
            var expectedCountAfterRemoving = 1;

            //Act
            this.database.Remove();

            var actualCount = this.database.Count;

            // Assert
            Assert.AreEqual(expectedCountAfterRemoving, actualCount);
        }

        [Test]

        public void RemoveShouldThrowExceptionWhenCollectionIsEmpty()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                // No items
                this.database.Remove();
            });
        }

        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            this.database = new Database(expectedData);

            //ReturnedCopy 
            var actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

    }
}