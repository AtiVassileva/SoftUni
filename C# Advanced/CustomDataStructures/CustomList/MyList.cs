using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CustomList
{
    public class MyList<T> : IEnumerable<T>
    {
        private readonly int _capacity;
        private T[] _data;

        public MyList()
        : this(4)
        {
        }

        public MyList(int capacity)
        {
            this._capacity = capacity;
            this._data = new T[capacity];
        }
        public int Count { get; private set; }

        public void Add(T number)
        {
            if (this.Count == this._data.Length)
            {
                Resize();
            }
            this._data[this.Count] = number;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            var result = this._data[index];
            this.ValidateIndex(index);

            for (var i = index + 1; i < this.Count; i++)
            {
                this._data[i - 1] = this._data[i];
            }

            this.Count--;
            return result;
        }

        public bool Contains(T element)
        {
            var contains = false;

            for (var i = 0; i < this.Count; i++)
            {
                if (this._data[i].Equals(element))
                {
                    contains = true;
                }
            }

            return contains;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            var value = this._data[firstIndex];
            this._data[firstIndex] = this._data[secondIndex];
            this._data[secondIndex] = value;
        }

        public int RemoveAll(Func<T, bool> filter)
        {
            var totalRemoved = 0;
            for (var i = 0; i < this.Count; i++)
            {
                if (filter(this._data[i]))
                {
                    this.RemoveAt(i);
                    totalRemoved++;
                }
            }

            return totalRemoved;
        }
        public void Insert(int index, T element)
        {
            this.ValidateIndex(index);

            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this._data.Length)
            {
                this.Resize();
            }

            ShiftToRight(index);
            this._data[index] = element;
            this.Count++;
        }
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._data[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._data[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            var message = this.Count == 0
                ? "The list is empty"
                : $"The list has {this.Count} elements and it is zero-based";

            if (index < 0 || index >= this.Count)
            {
                throw new Exception($"Index out of range. {message}.");
            }
        }

        private void Resize()
        {
            var nextCapacity = this._data.Length * 2;
            var newData = new T[nextCapacity];

            for (var i = 0; i < this._data.Length; i++)
            {
                newData[i] = this._data[i];
            }

            this._data = newData;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this._data[i] = this._data[i - 1];
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this._data = new T[_capacity];
        }

        public IEnumerator<T> GetEnumerator()
            => (IEnumerator<T>)this._data.Take(this.Count).ToList().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}