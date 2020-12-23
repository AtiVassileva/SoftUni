namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item)
        {
            var node = this.Search(this.Root, item);
            return node != null;
        }

        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            var cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = this.Insert(node.Right, item);
            }

            node = Balance(node);
            UpdateHeight(node);
            return node;
        }

        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            var cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Search(node.Left, item);
            }

            if (cmp > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        public Node<T> RotateRight(Node<T> node)
        {
            var left = node.Left;
            node.Left = node.Left.Right;
            left.Right = node;

            UpdateHeight(node);

            return left;
        }

        public Node<T> RotateLeft(Node<T> node)
        {
            var right = node.Right;
            node.Right = node.Right.Left;
            right.Left = node;

            UpdateHeight(node);

            return right;
        }

        private Node<T> Balance(Node<T> node)
        {
            var balance = Height(node.Left) - Height(node.Right);

            if (balance > 1)  
            {
                var childBalance = Height(node.Left.Left) - Height(node.Left.Right);
                if (childBalance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            } 
            else if (balance < -1)
            {
                var childBalance = Height(node.Right.Left) - Height(node.Right.Right);

                if (childBalance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }


        private static void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private static int Height(Node<T> node)
        {
            return node?.Height ?? 0;
        }
    }
}
