namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            this._head = null;
            this.Count = 0;
        }
        public Queue(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentElement = this._head;

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

        public T Dequeue()
        {
            this.ValidateIfNotEmpty();
            var current = this._head;
            this._head = this._head.Next;
            this.Count--;
            return current.Value;
        }

        public void Enqueue(T item)
        {
            var current = this._head;
            var itemToInsert = new Node<T>(item);

            if (current == null)
            {
                this._head = itemToInsert;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = itemToInsert;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.ValidateIfNotEmpty();
            return this._head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIfNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
        }
    }
}