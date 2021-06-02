using System;
using System.Collections.Generic;

namespace GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {
        public List<T> Values { get; set; }

        public Box(List<T> values)
        {
            this.Values = values;
        }

        public int CountGreaterElements(List<T> values, T element)
        {
            var count = 0;

            foreach (var item in values)
            {
                if (item.CompareTo(element) == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}