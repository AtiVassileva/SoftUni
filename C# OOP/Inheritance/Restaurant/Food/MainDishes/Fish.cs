﻿namespace Restaurant.Food.MainDishes
{
    public class Fish : MainDish
    {
        private const double DefaultFishGrams = 22;
        public Fish(string name, decimal price) : 
            base(name, price, DefaultFishGrams)
        {
        }
    }
}
