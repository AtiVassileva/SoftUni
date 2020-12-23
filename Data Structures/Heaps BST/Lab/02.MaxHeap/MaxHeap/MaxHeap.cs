using System.Collections.Generic;

namespace _02.MaxHeap
{
    using System;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> elements;

        public MaxHeap()
        {
            this.elements =new List<T>();
        }
        public int Size => this.elements.Count;

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
                throw new InvalidOperationException("Max heap is empty!");
            }
        }

        private bool IsValidIndex(int index)
        {
            return index > 0;
        }

        private bool IsGreater(int childIndex, int parentIndex)
        {
            return this.elements[childIndex].CompareTo(this.elements[parentIndex]) > 0;
        }

        private void HeapifyUp()
        {
            var currentIndex = this.Size - 1;
            var parentIndex = this.GetParentIndex(currentIndex);

            SwapElements(currentIndex, parentIndex);
        }

        private void SwapElements(int currentIndex, int parentIndex)
        {
            while (this.IsValidIndex(currentIndex)
                   && this.IsGreater(currentIndex, parentIndex))
            {
                var temp = this.elements[currentIndex];
                this.elements[currentIndex] = this.elements[parentIndex];
                this.elements[parentIndex] = temp;

                currentIndex = parentIndex;
                parentIndex = this.GetParentIndex(currentIndex);
            }
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }
    }
}
