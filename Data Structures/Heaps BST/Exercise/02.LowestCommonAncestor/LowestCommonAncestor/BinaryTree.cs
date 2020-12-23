﻿using System.Collections.Generic;

namespace _02.LowestCommonAncestor
{
    using System;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.RightChild = rightChild;
            this.LeftChild = leftChild;

            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
            
            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstList = new List<BinaryTree<T>>();
            var secondList = new List<BinaryTree<T>>();

            this.FindNodeBfs(this, first, firstList);
            this.FindNodeBfs(this, second, secondList);

            var firstNode = firstList[0];
            var secondNode = secondList[0];

            var parentToLookFor = firstNode.Parent.Value;

            while (!parentToLookFor.Equals(firstNode.Value) ||
                   !parentToLookFor.Equals(secondNode.Value))
            {
                if (!parentToLookFor.Equals(firstNode.Value))
                {
                    firstNode = firstNode.Parent;
                }
                
                if (!parentToLookFor.Equals(secondNode.Value))
                {
                    secondNode = secondNode.Parent;
                }
            }

            return firstNode.Value;
        }

        private void FindNodeBfs(BinaryTree<T> current, T element, List<BinaryTree<T>> list)
        {
            if (current == null)
            {
                return;
            }

            if (current.Value.Equals(element))
            {
                list.Add(current);
                return;
            }

            this.FindNodeBfs(current.LeftChild, element, list);
            this.FindNodeBfs(current.RightChild, element, list);
        }
    }
}
