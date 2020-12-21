using System;
using System.Text;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> _data;

        public Box()
        {
            this._data = new List<T>();
        }

        public int Count => this._data.Count;

        public void Add(T element)
        {
            _data.Add(element);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = this._data[firstIndex];
            this._data[firstIndex] = this._data[secondIndex];
            this._data[secondIndex] = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var element in this._data)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}