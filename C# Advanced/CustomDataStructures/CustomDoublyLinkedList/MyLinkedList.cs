using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                var arr = this.ToArray();
                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Index outside of the bounds of the list.", nameof(index));
                }

                return arr[index];
            }
        }


        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newHead = new ListNode<T>(element);
                var oldHead = this.head;

                this.head = newHead;
                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                var oldTail = this.tail;

                this.tail = newTail;
                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }

            var removedlElement = this.head.Value;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                var newHead = this.head.NextNode;
                newHead.PreviousNode = null;
                this.head = newHead;
            }

            this.Count--;
            return removedlElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
            var removedElement = this.tail.Value;

            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                var newTail = this.tail.PreviousNode;
                newTail.NextNode = null;
                this.tail = newTail;
            }

            this.Count--;
            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentElement = this.head;

            while (currentElement != null)
            {
                action(currentElement.Value);
                currentElement = currentElement.NextNode;
            }
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            var counter = 0;
            var currentElement = this.head;

            while (currentElement != null)
            {
                array[counter] = currentElement.Value;
                currentElement = currentElement.NextNode;
                counter++;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // Logic for looping
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}