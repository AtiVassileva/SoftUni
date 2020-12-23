using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class TreeFactory
    {
        private readonly Dictionary<int, Tree<int>> nodesByKeys;

        public TreeFactory()
        {
            this.nodesByKeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var values = line.Split(' ').Select(int.Parse).ToArray();
                var parent = values[0];
                var child = values[1];

                this.AddEdge(parent, child);
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesByKeys.ContainsKey(key))
            {
                this.nodesByKeys.Add(key, new Tree<int>(key));
            }

            return this.nodesByKeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode); 
        }

        private Tree<int> GetRoot()
        {
            return this.nodesByKeys.
                Where(node => node.Value.Parent == null)
                .Select(node => node.Value)
                .FirstOrDefault();
        }
    }
}
