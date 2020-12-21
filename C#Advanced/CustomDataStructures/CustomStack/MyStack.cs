using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly int _capacity;
        private T[] _data;

        public MyStack() : this(4)
        {
        }

        public MyStack(int capacity)
        {
            this._capacity = capacity;
            this._data = new T[capacity];
        }
        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this._data.Length)
            {
                this.Resize();
            }

            this._data[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.ValidateEmptyStack();
            var result = this._data[this.Count - 1];
            this.Count--;
            return result;
        }

        public T Peek()
        {
            this.ValidateEmptyStack();
            return this._data[this.Count - 1];
        }

        public void Clear()
        {
            this._data = new T[_capacity];
            this.Count = 0;
        }

        public void ForEach(Action<T> action)
        {
            for (var i = this.Count - 1; i >= 0; i--)
            {
                action(this._data[i]);
            }
        }

        private void Resize()
        {
            var newCapacity = _data.Length * 2;
            var newData = new T[newCapacity];

            for (var i = 0; i < this._data.Length; i++)
            {
                newData[i] = this._data[i];
            }
            this._data = newData;
        }

        private void ValidateEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("Stack is empty.");
            }
        }

        public IEnumerator<T> GetEnumerator()
            => (IEnumerator<T>)this._data.Take(this.Count).Reverse().ToList().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}