using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.Hierarchy
{
    public class Node<T>
    {
        private const string NullChildException =
            "Child cannot be null!";

        private readonly ICollection<Node<T>> children;
        public Node(T value)
        {
            this.Value = value;
            this.children = new List<Node<T>>();
        }

        public T Value { get; private set; }

        public Node<T> Parent { get; set; }

        public IReadOnlyCollection<Node<T>> Children => 
            (IReadOnlyCollection<Node<T>>) this.children;

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public void AddChild(Node<T> child)
        {
            this.EnsureNotNull(child);
            this.children.Add(child);
        }

        public void RemoveChild(Node<T> child)
        {
            this.EnsureNotNull(child);
            this.children.Remove(child);
        }

        private void EnsureNotNull(Node<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(NullChildException);
            }
        }
    }
}