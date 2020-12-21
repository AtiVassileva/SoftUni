using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            // Test LinkedList with integers

            var linkedList = new MyLinkedList<int>();

            for (var i = 1; i <= 10; i++)
            {
                linkedList.AddLast(i);
            }

            for (var i = 1; i <= 10; i++)
            {
                linkedList.AddFirst(i);
            }
            linkedList.ForEach(n => Console.Write(n + " "));
            // 10 9 8 7 6 5 4 3 2 1 1 2 3 4 5 6 7 8 9 10

            Console.WriteLine();

            for (var i = 1; i <= 10; i++)
            {
                linkedList.RemoveFirst();
            }
            linkedList.ForEach(n => Console.Write(n + " "));
            // 1 2 3 4 5 6 7 8 9 10

            Console.WriteLine();

            for (var i = 1; i <= 5; i++)
            {
                linkedList.RemoveLast();
            }
            linkedList.ForEach(n => Console.Write(n + " "));
            // 1 2 3 4 5 
            Console.WriteLine();
            Console.WriteLine("Converted to array:");

            var array = linkedList.ToArray();
            Console.WriteLine(string.Join(" ", array));
            // 1 2 3 4 5

            //Access elements on indexes

            Console.WriteLine($"Element on first position: {linkedList[0]}"); // 1
            Console.WriteLine($"Element on second position: {linkedList[1]}"); // 2 
            Console.WriteLine($"Element on third position: {linkedList[2]}"); // 3
            Console.WriteLine($"Element on fourth position: {linkedList[3]}"); // 4
            Console.WriteLine($"Element on fifth position: {linkedList[4]}"); // 5

            // Iterate through elements with foreach loop

            foreach (var element in linkedList)
            {
                Console.WriteLine($"Current element: {element}");
            }

            // Trying to access element on invalid index
            Console.WriteLine(linkedList[8]);
            // Exception: Index outside of the bounds of the list. (Parameter 'index')
        }
    }
}