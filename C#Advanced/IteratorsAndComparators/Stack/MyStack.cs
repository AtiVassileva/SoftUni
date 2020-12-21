using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index = -1;

        public MyStack()
        {
            this.elements = new List<T>();
        }

        public void Push(params T[] elements)
        {
            foreach (var el in elements)
            {
                this.elements.Insert(++index, el);
            }
        }

        public void Pop()
        {
            if (index < 0)
            {
                throw new InvalidOperationException("No elements");
            }

            index--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = index; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}