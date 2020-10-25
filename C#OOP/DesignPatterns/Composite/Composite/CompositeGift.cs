using System;
using System.Collections.Generic;
using System.Linq;
using Composite.Component;
using Composite.Contracts;

namespace Composite.Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this.name} contains following gifts with prices:");

            var totalPrice = this.gifts.Sum(g => g.CalculateTotalPrice());

            return totalPrice;
        }

    }
}
