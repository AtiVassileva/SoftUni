﻿namespace _02.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public TreeNode<T> Insert(T key)
        {
            return this.root = Insert(this.root, key);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T key)
        {
            if (this.root == null)
            {
                return new TreeNode<T>(key);
            }

            TreeNode<T> nodeToReturn;

            if (node.IsLeaf())
            {
                return this.MergeNodes(node, new TreeNode<T>(key));
            }
            if (key.CompareTo(node.LeftKey) < 0)
            {
                nodeToReturn = this.Insert(node.LeftChild, key);

                if (nodeToReturn.Equals(node.LeftChild))
                {
                    return node;
                }

                return this.MergeNodes(node, nodeToReturn);
            }
            else if (node.IsTwoNode() || key.CompareTo(node.RightKey) < 0)
            {
                nodeToReturn = this.Insert(node.MiddleChild, key);

                if (nodeToReturn.Equals(node.MiddleChild))
                {
                    return node;
                }

                return this.MergeNodes(node, nodeToReturn);
            }
            else
            {
                nodeToReturn = this.Insert(node.RightChild, key);
                if (nodeToReturn.Equals(node.RightChild))
                {
                    return node;
                }

                return this.MergeNodes(node, nodeToReturn);
            }
        }

        private TreeNode<T> MergeNodes(TreeNode<T> current, TreeNode<T> node)
        {
            if (current.RightKey == null)
            {
                if (current.LeftKey.CompareTo(node.LeftKey) < 0)
                {
                    current.RightKey = node.LeftKey;
                    current.MiddleChild = node.LeftChild;
                    current.RightChild = node.MiddleChild;
                }
                else
                {
                    current.RightKey = current.LeftKey;
                    current.RightChild = current.MiddleChild;
                    current.LeftKey = node.LeftKey;
                    current.MiddleChild = node.MiddleChild;
                }

                return current;
            }
            else if (current.LeftKey.CompareTo(node.LeftKey) >= 0)
            {
                var mergeNode = new TreeNode<T>(current.LeftKey)
                {
                    LeftChild = node,
                    MiddleChild = current,
                        
                };

                node.LeftChild = current.LeftChild;
                current.LeftChild = current.MiddleChild;
                current.MiddleChild = current.RightChild;
                current.RightChild = null;
                current.LeftKey = current.RightKey;
                current.RightKey = default;

                return mergeNode;

            }
            else if (current.RightKey.CompareTo(node.LeftKey) >= 0)
            {
                node.MiddleChild = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = node.MiddleChild,
                    MiddleChild = current.RightChild,
                };

                node.LeftChild = current;
                current.RightKey = default;
                current.RightChild = null;

                return node;
            }
            else
            {
                var mergeNode = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = current,
                    MiddleChild = node,
                };
                node.LeftChild = current.RightChild;
                current.RightChild = null;
                current.RightKey = default;

                return mergeNode;
            }
        }
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
