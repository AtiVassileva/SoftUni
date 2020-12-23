namespace Problem02.Stack.Tests
{
    using Stack;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class StackTests
    {
        private readonly Random random = new Random();
        private IAbstractStack<int> stack;

        [SetUp]
        public void InitializeStack()
        {
            this.stack = new Stack<int>();
        }

        [Test]
        public void PushShouldAddElementAtTheTop()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomValue = this.random.Next(100);
                array[count - i] = randomValue;
                stack.Push(randomValue);
                Assert.AreEqual(i, stack.Count);
            }

            var index = 0;
            foreach (var stackElement in stack)
                Assert.AreEqual(array[index++], stackElement);
        }

        [Test]
        public void PopShouldRemoveTheTopElement()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = count - 1; i >= 0; i--)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                stack.Push(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], stack.Pop());
                Assert.AreEqual(array.Length - (i + 1), stack.Count);
            }
        }

        [Test]
        public void PopShouldThrowExceptionIfTheStackContainsNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void PeekShouldReturnTheTopElementWithoutRemovingIt()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = count - 1; i >= 0; i--)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                stack.Push(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], stack.Peek());
                Assert.AreEqual(array.Length - i, stack.Count);
                stack.Pop();
            }
        }

        [Test]
        public void PeekShouldThrowExceptionIfTheStackContainsNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void ContainsShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);

            for (var i = 0; i < count; i++)
                stack.Push(i);

            for (var i = 0; i < count; i++)
                Assert.IsTrue(stack.Contains(i));

            Assert.IsFalse(stack.Contains(count));
        }

    }
}