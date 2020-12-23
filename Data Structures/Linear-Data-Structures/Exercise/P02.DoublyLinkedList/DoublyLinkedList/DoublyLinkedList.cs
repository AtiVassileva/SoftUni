namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public DoublyLinkedList()
        {
            this.head = this.tail = null;
            this.Count = 0;
        }

        public DoublyLinkedList(Node<T> head)
        {
            this.head = this.tail = head;
            this.Count = 1;
        }
        public DoublyLinkedList(Node<T> head, Node<T> tail)
        {
            this.head = head;
            this.tail = tail;
            this.Count = 2;
        }
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newFirstItem = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newFirstItem;
            }
            else
            {
                var currentFirst = this.head;
                this.head = newFirstItem;
                currentFirst.Previous = newFirstItem;
                this.head.Next = currentFirst;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newLastItem = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newLastItem;
            }
            else
            {
                var currentLast = this.tail;
                newLastItem.Previous = currentLast;
                currentLast.Next = newLastItem;
                this.tail = newLastItem;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();
            return this.head.Item;
        }


        public T GetLast()
        {
            this.EnsureNotEmpty();
            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();
            var currentFirst = this.head;
            this.head = this.head.Next;
            this.Count--;

            return currentFirst.Item;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();
            var currentLast = this.tail;
            this.tail = this.tail.Previous;
            this.Count--;

            return currentLast.Item;
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
                throw new InvalidOperationException("Cannot access first element! Collection is empty!");
            }
        }
    }
}