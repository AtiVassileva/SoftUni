namespace _04.BinarySearchTree
{
    using System;

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

        private void Copy(Node<T> root)
        {
            if (root != null)
            {
                this.Insert(root.Value);
                this.Copy(root.LeftChild);
                this.Copy(root.RightChild);
            }
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

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
                else
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
                var current = this.Root;
                Node<T> previous = null;

                while (current != null)
                {
                    previous = current;
                    if (this.IsLess(element, current.Value))
                    {
                        current = current.LeftChild;
                    }
                    else if (this.IsGreater(element, current.Value))
                    {
                        current = current.RightChild;
                    }
                    else
                    {
                        return;
                    }
                }

                if (this.IsLess(element, previous.Value))
                {
                    previous.LeftChild = nodeToInsert;
                    if (this.LeftChild == null)
                    {
                        this.LeftChild = nodeToInsert;
                    }
                }
                else
                {
                    previous.RightChild = nodeToInsert;
                    if (this.RightChild == null)
                    {
                        this.RightChild = nodeToInsert;
                    }
                }
            }
        }


        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var current = this.Root;

            while (current != null && !this.AreEqual(element, current.Value))
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
            }

            return new BinarySearchTree<T>(current);
        }

        private bool IsLess(T element, T currentValue)
        {
            return element.CompareTo(currentValue) < 0;
        }

        private bool IsGreater(T element, T currentValue)
        {
            return element.CompareTo(currentValue) > 0;
        }

        private bool AreEqual(T element, T currentValue)
        {
            return element.CompareTo(currentValue) == 0;
        }
    }
}
