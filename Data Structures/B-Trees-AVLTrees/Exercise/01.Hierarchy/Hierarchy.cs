using System.Linq;

namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private const string ElementNotPresentInTree =
            "Item is not present in the tree!";

        private const string RemoveRootElement =
            "Root element cannot be removed!";

        private readonly Node<T> root;
        private readonly Dictionary<T, Node<T>> elements 
            = new Dictionary<T, Node<T>>();

        public Hierarchy(T root)
        {
            this.root = this.CreateNode(root);
        }

        public int Count => this.elements.Count;

        public void Add(T element, T child)
        {
            this.CheckIfExists(element);

            if (this.elements.ContainsKey(child))
            {
                throw new ArgumentException(ElementNotPresentInTree);
            }

            var node = this.CreateNode(child);
            node.Parent = this.elements[element];
            this.elements[element].AddChild(node);

        }

        public void Remove(T element)
        {
            this.CheckIfExists(element);

            if (this.root.Value.Equals(element))
            {
                throw new InvalidOperationException(RemoveRootElement);
            }

            this.DestroyElement(element);
        }

        public IEnumerable<T> GetChildren(T element)
        {
            this.CheckIfExists(element);
            return this.elements[element].Children.Select(n => n.Value);
        }

        public T GetParent(T element)
        {
            this.CheckIfExists(element);
            var node = this.elements[element];
            return node.Parent != null ? node.Parent.Value : default;
        }

        public bool Contains(T element) => this.elements.ContainsKey(element);

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var result = new List<T>();
            foreach (var element in this.elements.Values)
            {
                if (other.Contains(element.Value))
                {
                    result.Add(element.Value);
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DestroyElement(T element)
        {
            var node = this.elements[element];
            node.Parent?.RemoveChild(node);

            if (node.Children.Count > 0 && node.Parent != null)
            {
                foreach (var child in node.Children)
                {
                    child.Parent = node.Parent;
                    node.Parent.AddChild(child);
                }
            }

            this.elements.Remove(element);
        }
        private Node<T> CreateNode(T element)
        {
            var currentNode = new Node<T>(element);
            this.elements[element] = currentNode;
            return currentNode;
        }

        private void CheckIfExists(T item)
        {
            if (!this.Contains(item))
            {
                throw new ArgumentException(ElementNotPresentInTree);
            }
        }
    }
}