namespace _01.Red_Black_Tree.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class RedBlackThreeTests
    {
        private RedBlackTree<string> redBlackTree;

        private readonly string[] input = {
            "S",
            "E",
            "A",
            "R",
            "C",
            "H",
            "E",
            "X",
            "A",
            "M",
            "P",
            "L",
            "E"
        };

        [SetUp]
        public void Setup()
        {
            this.redBlackTree = new RedBlackTree<string>();

            for (int i = 0; i < input.Length; i++)
            {
                this.redBlackTree.Insert(input[i]);
            }
        }

        [Test]
        public void TestEachInOrder()
        {
            var expected = new List<string>
            {
                "A",
                "C",
                "E",
                "H",
                "L",
                "M",
                "P",
                "R",
                "S",
                "X"
            };

            Assert.AreEqual(expected.Count, this.redBlackTree.Count);

            int count = 0;
            this.redBlackTree.EachInOrder(n => StringAssert.AreEqualIgnoringCase(n, expected[count++]));

            var list = new List<string>();
            this.redBlackTree.EachInOrder(n => list.Add(n));

            CollectionAssert.AreEqual(list, expected);
        }

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(10, this.redBlackTree.Count);
            Assert.AreEqual(0, new RedBlackTree<string>().Count);
        }

        [Test]
        public void TestContains()
        {
            Assert.True(this.redBlackTree.Contains("H"));
            Assert.False(this.redBlackTree.Contains("Pesho"));
        }

        [Test]
        public void TestInsert()
        {
            Assert.False(this.redBlackTree.Contains("Pesho"));
            this.redBlackTree.Insert("Pesho");
            Assert.True(this.redBlackTree.Contains("Pesho"));
        }

        [Test]
        public void TestSecondInsert()
        {
            Assert.False(this.redBlackTree.Contains("Pesho"));
            this.redBlackTree.Insert("Pesho");
            Assert.True(this.redBlackTree.Contains("Pesho"));
        }

        [Test]
        public void TestRange()
        {
            var expected = new List<string>
            {
                "E", "H", "L", "M", "P", "R",
            };

            var range = this.redBlackTree.Range("E", "R");
            CollectionAssert.AreEqual(range, expected);
        }
        [Test]
        public void TestDeleteMin()
        {
            this.redBlackTree.DeleteMin();
            Assert.AreEqual(9, this.redBlackTree.Count);
            Assert.False(this.redBlackTree.Contains("A"));
        }

        [Test]
        public void TestDeleteMax()
        {
            this.redBlackTree.DeleteMax();
            Assert.AreEqual(9, this.redBlackTree.Count);
            Assert.False(this.redBlackTree.Contains("X"));
        }

        [Test]
        public void TestDelete()
        {
            this.redBlackTree.Delete("M");
            Assert.AreEqual(9, this.redBlackTree.Count);
            Assert.False(this.redBlackTree.Contains("M"));
        }

        [Test]
        public void TestSelect()
        {
            string selected = this.redBlackTree.Select(3);
            Assert.NotNull(selected);
            Assert.AreEqual("H", selected);
        }

        [Test]
        public void TestRank()
        {
            int rank = this.redBlackTree.Rank("H");
            Assert.AreEqual(3, rank);
        }

        [Test]
        public void TestCeiling()
        {
            string ceil = this.redBlackTree.Ceiling("A");
            Assert.AreEqual("C", ceil);
        }

        [Test]
        public void TestFloor()
        {
            string floor = this.redBlackTree.Floor("B");
            Assert.AreEqual("A", floor);
        }
    }
}
