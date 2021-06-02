using System;

namespace CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // RANDOM TESTS FOR CUSTOM LIST'S FUNCTIONALITY 

            var list = new MyList<int>();

            list.Add(100);
            list.Add(200);
            list.Add(300);

            var number = list[1];

            Console.WriteLine(list[0]);
            Console.WriteLine(number);
            Console.WriteLine(list[2]);

            var count = list.Count; //3
            Console.WriteLine(count);

            list.Clear();
            Console.WriteLine(list.Count);

            for (var i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            var newList = new MyList<int>();
            newList.Add(10);
            newList.Add(20);
            newList.Add(30);
            newList.Add(40);
            newList.Add(50);

            var removed = newList.RemoveAt(2); //30

            foreach (var num in newList)
            {
                Console.WriteLine(num); // 10 20 40 50
            }

            Console.WriteLine(newList.Count); // 4
            Console.WriteLine($"Removed: {removed}"); // 30

            var wantedElement = newList.Contains(1000); //False
            var secondWantedElement = newList.Contains(10); //True

            Console.WriteLine($"{wantedElement} / {secondWantedElement}");

            var anotherList = new MyList<int>();

            anotherList.Add(1000);
            anotherList.Add(2000);

            anotherList.Swap(0, 1);

            Console.WriteLine("Swapped elements:");
            Console.WriteLine(anotherList[0]); // 2000
            Console.WriteLine(anotherList[1]); // 1000

            Console.WriteLine("Inserted: ");
            anotherList.Insert(1, 3000);

            foreach (var num in anotherList)
            {
                Console.WriteLine(num); // 2000 3000 1000
            }
        }
    }
}