using System.Text;

namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            var sb = new StringBuilder();
            this.DfsPreOrder(this, sb, indent);

            return sb.ToString();
        }


        public List<IAbstractBinaryTree<T>> InOrder()
        {
            var inOrderedElements = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                inOrderedElements.AddRange(this.LeftChild.InOrder());

            }

            inOrderedElements.Add(this);

            if (this.RightChild != null)
            {
                inOrderedElements.AddRange(this.RightChild.InOrder());
            }
            return inOrderedElements;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            var postOrderedElements = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                postOrderedElements.AddRange(this.LeftChild.PostOrder());
            }

            if (this.RightChild != null)
            {
                postOrderedElements.AddRange(this.RightChild.PostOrder());
            }

            postOrderedElements.Add(this);

            return postOrderedElements;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            var preOrderedElements = new List<IAbstractBinaryTree<T>> {this};


            if (this.LeftChild != null)
            {
                preOrderedElements.AddRange(this.LeftChild.PreOrder());
            }

            if (this.RightChild != null)
            {
                preOrderedElements.AddRange(this.RightChild.PreOrder());
            }

            return preOrderedElements;
        }

        public void ForEachInOrder(Action<T> action)
        {
            LeftChild?.ForEachInOrder(action);

            action.Invoke(this.Value);

            RightChild?.ForEachInOrder(action);
        }

        private void DfsPreOrder(IAbstractBinaryTree<T> current, StringBuilder sb, int indent)
        {
            sb.AppendLine($"{new string(' ', indent)}{current.Value}");

            if (current.LeftChild != null)
            {
                this.DfsPreOrder(current.LeftChild, sb, indent + 2);
            }

            if (current.RightChild != null)
            {
                this.DfsPreOrder(current.RightChild, sb, indent + 2);
            }
        }
    }
}
