namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public Stack(Node<T> top = null)
        {
            this.top = top;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentElement = this.top;

            while (currentElement != null)
            {
                if (currentElement.Value.Equals(item))
                {
                    return true;
                }
                currentElement = currentElement.Next;
            }

            return false;
        }

        public T Peek()
        {
            this.ValidateIfEmpty();
            return this.top.Value;
        }

        public T Pop()
        {
            this.ValidateIfEmpty();
            var element = this.top;
            this.top = this.top.Next;
            this.Count--;

            return element.Value;
        }

        public void Push(T item)
        {
            var node = new Node<T>(item);
            node.Next = this.top;
            this.top = node;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.top;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        private void ValidateIfEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
        }
    }
}