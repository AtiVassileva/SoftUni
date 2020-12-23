using System.Linq;

namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;

        public List(int capacity = DefaultCapacity)
        {
            if (capacity <= 0)
            {
                throw new IndexOutOfRangeException($"{capacity} cannot be negative!");
            }
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (item == null)
            {
               throw new ArgumentNullException(nameof(item)); 
            }

            this.EnsureNotEmpty();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item) => 
            this.items.Contains(item);

        public int IndexOf(T item)
        {
            if (!this.items.Contains(item))
            {
                return -1;
            }

            var index = 0;

            for (var i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.EnsureNotEmpty();

            for (var i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            var index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (var i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default(T);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == this.items.Length)
            {
               ResizeArray(); 
            }
        }
        private void ResizeArray()
        {
            var newArray = new T[this.items.Length * 2];

            for (var i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }

            this.items = newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
    }
}