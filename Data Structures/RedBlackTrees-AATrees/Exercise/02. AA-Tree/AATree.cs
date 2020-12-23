namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public AATree()
        {
        }

        public int CountNodes() => root?.Count ?? 0;

        public bool IsEmpty() => this.root == null;

        public void Clear() => this.root = null;

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Search(T element)
        {
            return this.Search(this.root, element);
        }

        // Left -> Root -> Right 
        public void InOrder(Action<T> action)
        {
            this.VisitInOrder(this.root, action);
        }

        // Root -> Left -> Right
        public void PreOrder(Action<T> action)
        {
            this.VisitPreOrder(this.root, action);
        }

        // Left -> Right -> Root
        public void PostOrder(Action<T> action)
        {
            this.VisitPostOrder(this.root, action);
        }

        private bool Search(Node<T> node, T element)
        {
            if (node == null)
            {
                return false;
            }

            var comparer = element.CompareTo(node.Value);

            if (comparer > 0)
            {
                return this.Search(node.Right, element);
            }

            if (comparer < 0)
            {
                return this.Search(node.Left, element);
            }

            return true;
        }

        private void VisitInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.VisitInOrder(node.Left, action);
            action(node.Value);
            this.VisitInOrder(node.Right, action);
        }

        private void VisitPreOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Value);
            this.VisitPreOrder(node.Left, action);
            this.VisitPreOrder(node.Right, action);
        }

        private void VisitPostOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.VisitPostOrder(node.Left, action);
            this.VisitPostOrder(node.Right, action);
            action(node.Value);
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                return new Node<T>(element);
            }

            var comparer = element.CompareTo(node.Value);

            if (comparer > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            if (comparer < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }

            node = this.Skew(node);
            node = this.Split(node);
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
            return node;
        }

        private int GetCount(Node<T> node) => node?.Count ?? 0;

        private Node<T> Split(Node<T> node)
        {
            if (node.Level == node.Right?.Right?.Level)
            {
                var temp = node.Right;
                node.Right = temp.Left;
                temp.Left = node;

                node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
                temp.Level = this.GetLevel(temp.Right) + 1;
                return temp;
            }

            return node;
        }

        private int GetLevel(Node<T> node) => node?.Level ?? 0;

        private Node<T> Skew(Node<T> node)
        {
            if (node.Level == node.Left?.Level)
            {
                var temp = node.Left;
                node.Left = temp.Right;
                temp.Right = node;

                node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
                return temp;
            }

            return node;
        }
    }
}