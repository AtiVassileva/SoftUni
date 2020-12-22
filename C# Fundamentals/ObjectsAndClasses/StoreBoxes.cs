using System;
using System.Linq;
using System.Collections.Generic;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var boxes = new List<Box>();

            while (line != "end")
            {
                var input = line.Split();
                var serialNumber = input[0];
                var itemName = input[1];
                var itemQuantity = int.Parse(input[2]);
                var itemPrice = decimal.Parse(input[3]);

                var item = new Item();
                item.Name = itemName;
                item.Price = itemPrice;

                var box = new Box();
                box.SerialNumber = serialNumber;
                box.ItemQuantity = itemQuantity;
                box.Item = item;

                boxes.Add(box);

                line = Console.ReadLine();
            }

            foreach (var currBox in boxes.OrderByDescending(x => x.PriceForABox))
            {
                Console.WriteLine(currBox.SerialNumber);
                Console.WriteLine($"-- {currBox.Item.Name} - ${currBox.Item.Price:f2}: {currBox.ItemQuantity}");
                Console.WriteLine($"-- ${currBox.PriceForABox:f2}");
            }
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public decimal PriceForABox => ItemQuantity * Item.Price;
    }

    class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}