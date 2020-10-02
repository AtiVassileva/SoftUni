using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CollectionHierarchy.IO;
using CollectionHierarchy.Models;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        private AddCollection addCollection;
        private AddRemoveCollection addRemoveCollection;
        private MyList myList;

        private List<int> firstColIndexes;
        private List<int> secondColIndexes;
        private List<int> thirdColIndexes;
        private List<string> firstColRemoves;
        private List<string> secondColRemoves;

        private IReader reader;
        private IWriter writer;

        private Engine()
        {
            this.firstColIndexes = new List<int>();
            this.secondColIndexes = new List<int>();
            this.thirdColIndexes = new List<int>();
            this.firstColRemoves = new List<string>();
            this.secondColRemoves = new List<string>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();

        }

        public void Run()
        {
            var elementsToAdd = this.reader.ReadLine().
                Split(' ').ToArray();

            AddElements(elementsToAdd);

            var removeOperationsCount = int.Parse(Console.ReadLine());

            RemoveElements(removeOperationsCount);

            PrintOutput();
        }

        private void PrintOutput()
        {
            this.writer.WriteLine(string.Join(" ", firstColIndexes));
            this.writer.WriteLine(string.Join(" ", secondColIndexes));
            this.writer.WriteLine(string.Join(" ", thirdColIndexes));

            this.writer.WriteLine(string.Join(" ", firstColRemoves));
            this.writer.WriteLine(string.Join(" ", secondColRemoves));
        }

        private void RemoveElements(int removeOperationsCount)
        {
            for (int i = 0; i < removeOperationsCount; i++)
            {
                firstColRemoves.Add(addRemoveCollection.Remove());
                secondColRemoves.Add(myList.Remove());
            }
        }

        private void AddElements(string[] elementsToAdd)
        {
            foreach (var el in elementsToAdd)
            {
                firstColIndexes.Add(addCollection.Add(el));
                secondColIndexes.Add(addRemoveCollection.Add(el));
                thirdColIndexes.Add(myList.Add(el));
            }
        }
    }
}
