namespace SinglyLinkedList.Tests
{
    using System;
    using NUnit.Framework;
    using Problem04.SinglyLinkedList;

    [TestFixture]
    public class SinglyLinkedListTests
    {
        private readonly Random random = new Random();
        private IAbstractLinkedList<int> list;

        [SetUp]
        public void InitializeLinkedList()
        {
            this.list = new SinglyLinkedList<int>();
        }

        [Test]
        public void AddFirstShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomValue = this.random.Next(100);
                array[count - i] = randomValue;
                list.AddFirst(randomValue);
                Assert.AreEqual(i, list.Count);
            }

            var index = 0;
            foreach (var listElement in list)
                Assert.AreEqual(array[index++], listElement);
        }

        [Test]
        public void AddLastShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                list.AddLast(randomValue);
                Assert.AreEqual(i + 1, list.Count);
            }

            var index = 0;
            foreach (var listElement in list)
                Assert.AreEqual(array[index++], listElement);
        }

        [Test]
        public void RemoveFirstShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                list.AddLast(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var removedElement = list.RemoveFirst();
                Assert.AreEqual(array[i], removedElement);
                Assert.AreEqual(array.Length - (i + 1), list.Count);
            }
        }

        [Test]
        public void RemoveFirstShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Test]
        public void RemoveLastShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                list.AddFirst(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var removedElement = list.RemoveLast();
                Assert.AreEqual(array[i], removedElement);
                Assert.AreEqual(array.Length - (i + 1), list.Count);
            }
        }

        [Test]
        public void RemoveLastShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Test]
        public void GetFirstShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                list.AddLast(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var firstElement = list.GetFirst();
                Assert.AreEqual(array[i], firstElement);

                list.RemoveFirst();
            }
        }

        [Test]
        public void GetFirstShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => list.GetFirst());
        }

        [Test]
        public void GetLastShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                list.AddFirst(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var lastElement = list.GetLast();
                Assert.AreEqual(array[i], lastElement);

                list.RemoveLast();
            }
        }

        [Test]
        public void GetLastShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => list.GetLast());
        }
    }
}