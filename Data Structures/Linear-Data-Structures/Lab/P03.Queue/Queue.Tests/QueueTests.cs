namespace Problem03.Queue.Tests
{
    using Queue;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class QueueTests
    {
        private readonly Random random = new Random();
        private IAbstractQueue<int> queue;

        [SetUp]
        public void InitializeQueue()
        {
            this.queue = new Queue<int>();
        }

        [Test]
        public void EnqueueShouldAddElementAtTheTop()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                queue.Enqueue(randomValue);
                Assert.AreEqual(i + 1, queue.Count);
            }

            var index = 0;
            foreach (var queueElement in queue)
            {
                Assert.AreEqual(array[index++], queueElement);
            }
        }

        [Test]
        public void DequeueShouldRemoveTheLastElement()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                queue.Enqueue(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], queue.Dequeue());
                Assert.AreEqual(array.Length - (i + 1), queue.Count);
            }
        }

        [Test]
        public void DequeueShouldThrowExceptionIfTheStackContainsNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void PeekShouldReturnTheLastElementWithoutRemovingIt()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                queue.Enqueue(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], queue.Peek());
                Assert.AreEqual(array.Length - i, queue.Count);
                queue.Dequeue();
            }
        }

        [Test]
        public void PeekShouldThrowExceptionIfTheStackContainsNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void ContainsShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);

            for (var i = 0; i < count; i++)
                queue.Enqueue(i);

            for (var i = 0; i < count; i++)
            {
                Assert.IsTrue(queue.Contains(i));
            }

            Assert.IsFalse(queue.Contains(count));
        }
    }
}