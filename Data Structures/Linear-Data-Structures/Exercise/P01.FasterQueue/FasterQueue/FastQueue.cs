namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public FastQueue()
        {
            this.head = this.tail = null;
            this.Count = 0;
        }

        public FastQueue(Node<T> head)
        {
            this.head = this.tail = head;
            this.Count = 1;
        }
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this.head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();
            var firstItem = this.head;
            this.head = this.head.Next;
            this.Count--;

            return firstItem.Item;
        }

        public void Enqueue(T item)
        {
            var newItem = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newItem;
            }
            else
            {
                var currentLast = this.tail;
                this.tail = newItem;
                currentLast.Next = newItem;
                newItem.Previous = currentLast;
            }

            this.Count++;
        }

        public T Peek()
        {
           this.EnsureNotEmpty();
           return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current.Next != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}