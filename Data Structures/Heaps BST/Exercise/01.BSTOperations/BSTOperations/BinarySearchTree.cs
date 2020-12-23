using System.Linq;

namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Copy(root);
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public int Count => this.Root.Count;

        public bool Contains(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else if (this.AreEqual(element, current.Value))
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            var nodeToInsert = new Node<T>(element, null, null);

            if (this.Root == null)
            {
                this.Root = nodeToInsert;
            }
            else
            {
                this.InsertElementsDfs(this.Root, null, nodeToInsert);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else if (this.AreEqual(element, current.Value))
                {
                    break;
                }
            }

            return new BinarySearchTree<T>(current);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrderDfs(this.Root, action);
        }


        public List<T> Range(T lower, T upper)
        {
            return this.RangeBfs(lower, upper);
        }

        public void DeleteMin()
        {
            this.EnsureNotEmpty();
            var current = this.Root;
            Node<T> previous = null;

            if (this.Root.LeftChild == null)
            {
                this.Root = this.Root.RightChild;
            }
            else
            {
                while (current.LeftChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.LeftChild;
                }

                previous.LeftChild = current.RightChild;
            }
        }

        public void DeleteMax()
        {
            this.EnsureNotEmpty();
            var current = this.Root;
            Node<T> previous = null;

            if (this.Root.RightChild == null)
            {
                this.Root = this.Root.LeftChild;
            }
            else
            {
                while (current.RightChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.RightChild;
                }

                previous.RightChild = current.LeftChild;
            }
        }

        public int GetRank(T element)
        {
            return this.GetRankDfs(this.Root, element);
        }

        private int GetRankDfs(Node<T> current, T element)
        {
            if (current == null)
            {
                return 0;
            }

            if (this.IsLess(element, current.Value))
            {
                return this.GetRankDfs(current.LeftChild, element);
            }
            else if (this.AreEqual(element, current.Value))
            {
                return this.GetNodeCount(current);
                
            }

            return this.GetNodeCount(current.LeftChild) + 1
                + this.GetRankDfs(current.RightChild, element);
        }

        private int GetNodeCount(Node<T> node)
        {
            return node?.Count ?? 0;
        }
        private void InsertElementsDfs(Node<T> current, Node<T> previous, Node<T> nodeToInsert)
        {
            if (current == null && this.IsLess(nodeToInsert.Value, previous.Value))
            {
                previous.LeftChild = nodeToInsert;
                if (this.LeftChild == null)
                {
                    this.LeftChild = nodeToInsert;
                }
                return;
            }
            
            if (current == null && this.IsGreater(nodeToInsert.Value, previous.Value))
            {
                previous.RightChild = nodeToInsert;
                if (this.RightChild == null)
                {
                    this.RightChild = nodeToInsert;
                }
                return;
            }

            if (this.IsLess(nodeToInsert.Value, current.Value))
            {
                this.InsertElementsDfs(current.LeftChild, current, nodeToInsert);
                current.Count++;
            }
            else if (this.IsGreater(nodeToInsert.Value, current.Value))
            {
                this.InsertElementsDfs(current.RightChild, current, nodeToInsert);
                current.Count++;
            }
        }

        private bool IsLess(T firstEl, T secondEl)
        {
            return firstEl.CompareTo(secondEl) < 0;
        }
        
        private bool IsGreater(T firstEl, T secondEl)
        {
            return firstEl.CompareTo(secondEl) > 0;
        }
        
        private bool AreEqual(T firstEl, T secondEl)
        {
            return firstEl.CompareTo(secondEl) == 0;
        }

        private void EachInOrderDfs(Node<T> current, Action<T> action)
        {
            if (current != null)
            {
                this.EachInOrderDfs(current.LeftChild, action);
                action.Invoke(current.Value);
                this.EachInOrderDfs(current.RightChild, action);
            }
        }

        private List<T> RangeBfs(T lower, T upper)
        {
            var result = new List<T>();
            var queue = new Queue<Node<T>>();

            queue.Enqueue(this.Root);

            while (queue.Any())
            {
                var current = queue.Dequeue();

                if (this.IsLess(lower, current.Value) && this.IsGreater(upper, current.Value))
                {
                    result.Add(current.Value);
                }
                else if (this.AreEqual(lower, current.Value) || this.AreEqual(upper, current.Value))
                {
                    result.Add(current.Value);
                }

                if (current.LeftChild != null)
                {
                    queue.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }

            return result;
        }

        private void Copy(Node<T> current)
        {
            if (current != null)
            {
                this.Insert(current.Value);
                this.Copy(current.LeftChild);
                this.Copy(current.RightChild);
            }
        }
        private void EnsureNotEmpty()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("BST is empty!");
            }
        }
    }
}
    
