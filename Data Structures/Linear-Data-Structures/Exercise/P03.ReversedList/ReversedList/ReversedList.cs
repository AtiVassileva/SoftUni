namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity)
        {
        }

        public ReversedList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];

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
            this.GrowIfNecessary();
            this.items[this.Count++] = item;
        }

        public bool Contains(T item) => this.IndexOf(item) != -1;

        public int IndexOf(T item)
        {
            for (var i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.GrowIfNecessary();
            this.ValidateIndex(index);

            var indexToInsert = this.Count - index;

            for (var i = this.Count; i >= indexToInsert; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[indexToInsert] = item;
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
            var indexOfEl = this.Count - 1 - index;

            for (var i = indexOfEl; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void GrowIfNecessary()
        {
            if (this.Count == this.items.Length)
            {
                this.Grow();
            }
        }

        private void Grow()
        {
            var newArray = new T[this.items.Length * 2];

            Array.Copy(this.items, newArray, this.items.Length);

            this.items = newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }
        }
    }
}