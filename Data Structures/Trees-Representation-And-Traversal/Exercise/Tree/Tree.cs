using System.Linq;
using System.Text;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }

        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();

            this.OrderDfsForString(0, sb, this);

            return sb.ToString().TrimEnd();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var leafNodes = this.OrderBfs();

            var deepestNodeDepth = 0;
            Tree<T> deepestNode = null;

            foreach (var node in leafNodes)
            {
                var currentDepth = this.GetDepthFromChildToParent(node);
                if (currentDepth > deepestNodeDepth)
                {
                    deepestNodeDepth = currentDepth;
                    deepestNode = node;
                }
            }

            return deepestNode;
        }

        public List<T> GetLeafKeys()
        {
            var leafKeysFunc =
                new Func<Tree<T>, bool>(this.IsLeaf);
            return this.OrderBfs(leafKeysFunc);
        }

        public List<T> GetMiddleKeys()
        {
            var middleKeysFunc =
                new Func<Tree<T>, bool>(this.IsMiddleNode);
            return this.OrderBfs(middleKeysFunc);
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = this.GetDeepestLeftomostNode();

            var result = new Stack<T>();

            var current = deepestNode;

            while (current != null)
            {
                result.Push(current.Key);
                current = current.Parent;
            }

            return result.ToList();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();
            var currentPath = new List<T> { this.Key };

            var currentSum = Convert.ToInt32(this.Key);

            this.GetPathWithSumSumDfs(this, result, currentPath, ref currentSum, sum);
            return result;
        }

        private void GetPathWithSumSumDfs(Tree<T> tree, List<List<T>> result, List<T> currentPath, ref int currentSum, int sum)
        {
            foreach (var child in tree.Children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);
                this.GetPathWithSumSumDfs(child, result, currentPath, ref currentSum, sum);
            }

            if (currentSum.Equals(sum))
            {
                result.Add(new List<T>(currentPath));
            }

            currentSum -= Convert.ToInt32(tree.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var result = new List<Tree<T>>();
            var allNodes = this.OrderBfs();

            foreach (var node in allNodes)
            {
                var subtreeSum = this.GetSubtreeSumDfs(node);

                if (subtreeSum == sum)
                {
                    result.Add(node);
                }
            }
            return result;
        }

        private int GetSubtreeSumDfs(Tree<T> node)
        {
            var currentSum = Convert.ToInt32(node.Key);
            var childSum = node.Children.Sum(this.GetSubtreeSumDfs);

            return currentSum + childSum;
        }

        private void OrderDfsForString(int depth, StringBuilder sb, Tree<T> subtree)
        {
            sb.AppendLine(new string(' ', depth) + subtree.Key);

            foreach (var child in subtree.children)
            {
                this.OrderDfsForString(depth + 2, sb, child);
            }
        }

        private bool IsLeaf(Tree<T> subtree)
        {
            return subtree.Children.Count == 0;
        }

        private bool IsMiddleNode(Tree<T> subtree)
        {
            return subtree.Parent != null && subtree.Children.Any();
        }

        private List<T> OrderBfs(Func<Tree<T>, bool> predicate)
        {
            var list = new List<T>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Any())
            {
                var current = queue.Dequeue();

                if (predicate != null)
                {
                    if (predicate.Invoke(current))
                    {
                        list.Add(current.Key);
                    }
                }
                else
                {
                    list.Add(current.Key);
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }

        private IEnumerable<Tree<T>> OrderBfs()
        {
            var list = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Any())
            {
                var current = queue.Dequeue();

                list.Add(current);

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }

        private int GetDepthFromChildToParent(Tree<T> node)
        {
            var level = 0;

            var current = node;

            while (current.Parent != null)
            {
                current = current.Parent;
                level++;
            }

            return level;
        }
    }
}
