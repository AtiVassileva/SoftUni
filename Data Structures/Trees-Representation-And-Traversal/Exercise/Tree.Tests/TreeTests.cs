namespace Tree.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using Tree;

    public class TreeTests
    {
        private TreeFactory treeFactory;
        private Tree<int> tree;


        [SetUp]
        public void InitializeFactoryAndTree()
        {
            var input = new string[]
            {
                "7 19",
                "7 21",
                "7 14",
                "19 1",
                "19 12",
                "19 31",
                "14 23",
                "14 6"
            };

            this.treeFactory = new TreeFactory();
            this.tree = this.treeFactory.CreateTreeFromStrings(input);
        }

        [Test]
        public void TreeCreationShouldWorkSuccessfully()
        {
            Assert.AreEqual(7, this.tree.Key);
            Assert.NotNull(this.tree.Children);
            Assert.AreEqual(3, this.tree.Children.Count);
        }

        [Test]
        public void TreeAsStringShouldWorkCorrectly()
        {
            string expectedOutput = "7\r\n" +
                "  19\r\n" +
                "    1\r\n" +
                "    12\r\n" +
                "    31\r\n" +
                "  21\r\n" +
                "  14\r\n" +
                "    23\r\n" +
                "    6";

            Assert.AreEqual(expectedOutput, this.tree.GetAsString());
        }

        [Test]
        public void TreeGetLeafKeysShouldWorkCorrectly()
        {
            int[] expected = new int[] { 1, 6, 12, 21, 23, 31 };
            List<int> leafKeys = this.tree.GetLeafKeys()
                .OrderBy(leaf => leaf)
                .ToList();


            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], leafKeys[i]);
            }
        }

        [Test]
        public void TreeMiddleNodesShouldWorkCorrectly()
        {
            int[] expected = new int[] { 14, 19 };
            List<int> middleKeys = this.tree.GetMiddleKeys()
                .OrderBy(leaf => leaf)
                .ToList();


            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], middleKeys[i]);
            }
        }

        [Test]
        public void TreeDeepestLeftmostNodeShouldWorkCorrectly()
        {
            Tree<int> deepestNode = this.tree.GetDeepestLeftomostNode();

            Assert.AreEqual(1, deepestNode.Key);
        }


        [Test]
        public void TreeLeftmostLongestPathShouldWorkCorrectly()
        {
            int[] expectedPath = new int[] { 7, 19, 1 };
            List<int> longestLeftmostPath = this.tree.GetLongestPath();

            for (int i = 0; i < expectedPath.Length; i++)
            {
                Assert.AreEqual(expectedPath[i], longestLeftmostPath[i]);
            }
        }

        [Test]
        public void TreePathsWithGivenSumShouldWorkCorrectly()
        {
            int[,] expected = new int[,]
            {
                { 7, 19, 1 },
                { 7, 14, 6 }
            };

            List<List<int>> paths = this.tree.PathsWithGivenSum(27);

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], paths[i][j]);
                }
            }
        }

        [Test]
        public void TreeAllSubtreesWithGivenSumShouldWorkCorrectly()
        {
            List<Tree<int>> subtrees = this.tree.SubTreesWithGivenSum(43);
            Assert.AreEqual(1, subtrees.Count);
            string treeAsString = subtrees[0].GetAsString();
            Assert.IsTrue(treeAsString.Contains("14"));
            Assert.IsTrue(treeAsString.Contains("23"));
            Assert.IsTrue(treeAsString.Contains("6"));
        }
    }
}