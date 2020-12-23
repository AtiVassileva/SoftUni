namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            this.EnsureNotEmpty();
            var firstElement = this.Peek();
            this.SwapElements(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown();
            return firstElement;
        }


        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp();
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this.elements[0];
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Priority queue is empty!");
            }
        }

        private bool IsGreater(int childIndex, int parentIndex)
        {
            return this.elements[childIndex].CompareTo(this.elements[parentIndex]) > 0;
        }
        private bool IsLess(int parentIndex, int childIndex)
        {
            return this.elements[parentIndex].CompareTo(this.elements[childIndex]) < 0;
        }

        private void HeapifyUp()
        {
            var currentIndex = this.Size - 1;
            var parentIndex = this.GetParentIndex(currentIndex);

            while (currentIndex > 0
                   && this.IsLess(currentIndex, parentIndex))
            {
                var temp = this.elements[currentIndex];
                this.elements[currentIndex] = this.elements[parentIndex];
                this.elements[parentIndex] = temp;

                currentIndex = parentIndex;
                parentIndex = this.GetParentIndex(currentIndex);
            }

        }

        private void HeapifyDown()
        {
            var parentIndex = 0;
            var leftChildIndex = this.GetLeftChildIndex(parentIndex);

            while (leftChildIndex < this.Size
                   && this.IsGreater(parentIndex, leftChildIndex))
            {
                var indexToSwap = leftChildIndex;
                var rightChildIndex = this.GetRightChildIndex(parentIndex);

                if (rightChildIndex < this.Size
                    && this.IsGreater(indexToSwap, rightChildIndex))
                {
                    indexToSwap = rightChildIndex;
                }

                this.SwapElements(indexToSwap, parentIndex);
                parentIndex = indexToSwap;
                leftChildIndex = this.GetLeftChildIndex(parentIndex);
            }
        }
        private void SwapElements(int childIndex, int parentIndex)
        {
            var temp = this.elements[childIndex];
            this.elements[childIndex] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }
    }
}
