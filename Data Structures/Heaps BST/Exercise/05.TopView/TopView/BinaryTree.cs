namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var offSetToValue = new SortedDictionary<int, KeyValuePair<T, int>>();

            this.FillDictionaryDfs(this, 0, 1, offSetToValue);

            return offSetToValue.Values
                .Select(kvp => kvp.Key)
                .ToList();

        }

        private void FillDictionaryDfs(BinaryTree<T> subtree, int offset, int level, SortedDictionary<int, KeyValuePair<T, int>> offSetToValue)
        {
            if (subtree == null)
            {
                return;
            }

            if (!offSetToValue.ContainsKey(offset))
            {
                offSetToValue.Add(offset, new KeyValuePair<T, int>(subtree.Value, level));
            }

            if (level < offSetToValue[offset].Value)
            {
                offSetToValue[offset] = new KeyValuePair<T, int>(subtree.Value, level);
            }

            FillDictionaryDfs(subtree.LeftChild, offset - 1, level + 1, offSetToValue);
            FillDictionaryDfs(subtree.RightChild, offset + 1, level + 1, offSetToValue);
        }
    }
}
