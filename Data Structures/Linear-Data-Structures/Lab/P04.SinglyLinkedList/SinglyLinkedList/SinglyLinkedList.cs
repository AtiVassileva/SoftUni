namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public SinglyLinkedList()
        {
            this.head = null;
            this.Count = 0;
        }
        public SinglyLinkedList(Node<T> head)
        {
            this.head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var itemToInsert = new Node<T>(item, this.head);
            this.head = itemToInsert;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var itemToInsert = new Node<T>(item);
            var current = this.head;

            if (current == null)
            {
                this.head = itemToInsert;
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

        public T GetFirst()
        {
            this.ValidateIfNotEmpty();
            return this.head.Value;
        }

        public T GetLast()
        {
            this.ValidateIfNotEmpty();

            var current = this.head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            this.ValidateIfNotEmpty();
            var firstElement = this.head;
            this.head = this.head.Next;
            this.Count--;
            return firstElement.Value;
        }

        public T RemoveLast()
        {
            this.ValidateIfNotEmpty();
            Node<T> lastElement = null;

            if (this.Count == 1)
            {
                lastElement = this.head;
                this.head = null;
            }
            else
            {
                var current = this.head;

                while (current.Next.Next != null)
                {
                    current = current.Next;
                }

                lastElement = current.Next;
                current.Next = null;
            }

            this.Count--;
            return lastElement.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

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
                throw new InvalidOperationException("SinglyLinkedList is empty.");
            }
        }
    }
}