using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyOperator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index >= 0 && this.index < this.elements.Count - 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            var hasNext = this.index + 1 < this.elements.Count;

            return hasNext;
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine($"{this.elements[this.index]}");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.elements.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}