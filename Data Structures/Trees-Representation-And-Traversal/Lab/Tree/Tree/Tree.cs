using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            this.Value = value;

            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            if (this.IsRootDeleted)
            {
                return result;
            }
            //Enqueue the root
            queue.Enqueue(this);

            while (queue.Any())
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.Value);

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            if (this.IsRootDeleted)
            {
                return result;
            }

            this.Dfs(this, result);
            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parent = this.FindDfs(this, parentKey);
            this.CheckEmptyNode(parent);
            parent.children.Add(child);
        }


        public void RemoveNode(T nodeKey)
        {
            var node = this.FindBfs(nodeKey);
            this.CheckEmptyNode(node);

            foreach (var child in node.Children)
            {
                child.Parent = null;
            }

            node.children.Clear();

            var parentNode = node.Parent;
            
            //Removing root
            if (parentNode == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                parentNode.children.Remove(node);
            }

            node.Value = default;
            node.Parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindBfs(firstKey);
            var secondNode = this.FindBfs(secondKey);

            this.CheckEmptyNode(firstNode);
            this.CheckEmptyNode(secondNode);

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                SwapRoot(secondNode);
                return;
            }

            if (secondParent == null)
            {
                SwapRoot(firstNode);
                return;
            }

            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            var indexOfFirst = firstParent.children.IndexOf(firstNode);
            var indexOfSecond = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirst] = secondNode;
            secondParent.children[indexOfSecond] = firstNode;

        }

        private Tree<T> FindBfs(T value)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Any())
            {
                var subtree = queue.Dequeue();

                if (subtree.Value.Equals(value))
                {
                    return subtree;
                }

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> FindDfs(Tree<T> subtree, T value)
        {
            foreach (var child in subtree.Children)
            {
                var current = this.FindDfs(child, value);

                if (current != null && current.Value.Equals(value))
                {
                    return current;
                }
            }

            return subtree.Value.Equals(value) 
                ? subtree : null;
        }

        private ICollection<T> OrderDfsWithStack()
        {
            var result = new Stack<T>();
            var toTraverse = new Stack<Tree<T>>();

            while (toTraverse.Any())
            {
                var subtree = toTraverse.Pop();

                foreach (var child in subtree.Children)
                {
                    toTraverse.Push(child);
                }

                result.Push(subtree.Value);
            }

            return new List<T>(result);
        }

        private void Dfs(IAbstractTree<T> tree, ICollection<T> result)
        {

            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        private void CheckEmptyNode(Tree<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
        }

        private void SwapRoot(Tree<T> secondNode)
        {
            this.Value = secondNode.Value;
            this.children.Clear();

            foreach (var child in secondNode.Children)
            {
                this.children.Add(child);
            }
        }
    }
}
