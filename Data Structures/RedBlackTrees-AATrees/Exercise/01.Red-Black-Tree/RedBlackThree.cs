namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;

        private Node root;

        public RedBlackTree()
        {
        }

        public int Count => root?.Count ?? 0;

        public void Insert(T element)
        {
            if (element == null)
            {
                return;
            }

            this.root = this.Insert(element, this.root);
            this.root.Color = Black;
        }

        public T Select(int rank)
        {
            var node = this.Select(rank, this.root);
            this.ValidateNullNode(node);
            return node.Value;
        }

        public int Rank(T element)
        {
            return this.Rank(element, this.root);
        }

        public bool Contains(T element)
        {
            var node = this.Find(element);
            return node != null;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.Find(element);
            var tree = new RedBlackTree<T> { root = node };
            return tree;
        }

        public void DeleteMin()
        {
            this.ValidateNullNode(this.root);
            this.root = this.DeleteMin(this.root);
        }

        public void DeleteMax()
        {
            this.ValidateNullNode(this.root);
            this.root = this.DeleteMax(this.root);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var startRank = this.Rank(startRange);
            var endRank = this.Rank(endRange);
            var snapshot = this.RankSnapshot();

            var result = new List<T>();

            for (var i = startRank; i <= endRank; i++)
            {
                result.Add(snapshot[i]);
            }

            return result;

        }

        public void Delete(T element)
        {
            this.root = this.Delete(element, this.root);
        }

        public T Ceiling(T element)
        {
            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }

            public bool Color { get; set; }
        }

        private T[] RankSnapshot()
        {
            var snapshot = new T[this.Count];
            var queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var nodeRank = this.Rank(node.Value);
                snapshot[nodeRank] = node.Value;

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return snapshot;
        }
        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return; 
            }

            this.EachInOrder(action, node.Left);
            action(node.Value);
            this.EachInOrder(action, node.Right);
        }
        private Node Select(int rank, Node node)
        {
            if (node == null)
            {
                return null;
            }

            var leftCount = this.GetCount(node.Left);

            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return this.Select(rank, node.Left);
            }

            return this.Select(rank - (leftCount + 1), node.Right);
        }
        private int Rank(T element, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            var comparer = element.CompareTo(node.Value);

            if (comparer < 0)
            {
                return this.Rank(element, node.Left);
            }

            if (comparer > 0)
            {
                return 1 + this.GetCount(node.Left) + this.Rank(element, node.Right);
            }

            return this.GetCount(node.Left);
        }
        private Node Delete(T element, Node node)
        {
            if (node == null)
            {
                return null;
            }

            var comparer = element.CompareTo(node.Value);

            if (comparer > 0)
            {
                node.Right = this.Delete(element, node.Right);
            }
            else if (comparer < 0)
            {
                node.Left = this.Delete(element, node.Left);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }

                var temp = node;
                node = this.FindMin(node.Right);
                node.Right = this.DeleteMin(temp.Right);
                node.Left = temp.Left;
            }

            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
            return node;
        }
        private Node FindMin(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return this.FindMin(node.Left);
        }
        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;
        }
        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = this.DeleteMax(node.Left);
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;
        }
        private void ValidateNullNode(Node node)
        {
            if (node == null)
            {
                throw new InvalidOperationException("Null element!");
            }
        }
        private Node Find(T element)
        {
            var current = this.root;

            while (current != null)
            {
                var comparer = current.Value.CompareTo(element);

                if (comparer == 0)
                {
                    break;
                }

                if (comparer > 0)
                {
                    current = current.Left;
                }
                else if (comparer < 0)
                {
                    current = current.Right;
                }
            }

            return current;
        }
        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                return new Node(element) { Count = 1 };
            }

            var comparer = element.CompareTo(node.Value);
            if (comparer > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }
            else if (comparer < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }

            if (this.IsRed(node.Right) && !this.IsRed(node.Left))
            {
                node = this.RotateLeft(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                node = this.RotateRight(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                this.FlipColors(node);
            }

            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);
            return node;
        }
        private void FlipColors(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Black;
        }
        private Node RotateRight(Node node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            temp.Color = node.Color;
            node.Color = Red;
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return temp;
        }
        private Node RotateLeft(Node node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            temp.Color = node.Color;
            node.Color = Red;
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return temp;
        }
        private int GetCount(Node node) => node?.Count ?? 0;
        private bool IsRed(Node node)
        {
            return node != null && node.Color == Red;
        }
    }
}