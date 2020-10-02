using System;
using System.Collections.Generic;
using P04.PizzaCalories.Common;
using PizzaCalories.Common;

namespace P04.PizzaCalories.Models
{
    public class Topping
    {
        private string _toppingType;
        private double _toppingWeight;

        private readonly Dictionary<string, double> _toppingCalories = new Dictionary<string, double>();

        public Topping(string type, double weight)
        {
            this.FillDictionary();
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this._toppingType;
            private set
            {
                if (!this._toppingCalories.ContainsKey(value.ToLower()))
                {
                    GlobalConstants.InvalidTopping = value;
                    throw new ArgumentException(ErrorMessages.InvalidToppingException);
                }

                this._toppingType = value;
            }
        }

        public double Weight
        {
            get => this._toppingWeight;
            private set
            {
                if (value > GlobalConstants.ToppingMaxWeight || value < GlobalConstants.ToppingMinWeight)
                {
                    GlobalConstants.InvalidToppingWeight = this._toppingType;
                    throw new ArgumentException(ErrorMessages.InvalidToppingWeightException);
                }

                this._toppingWeight = value;
            }
        }

        public double CalculateCalories()
        {
            var calories = GlobalConstants.BaseCalories *
                           _toppingCalories[this._toppingType.ToLower()] *
                           this._toppingWeight;

            return calories;
        }

        private void FillDictionary()
        {
            this._toppingCalories.Add("meat", 1.2);
            this._toppingCalories.Add("veggies", 0.8);
            this._toppingCalories.Add("cheese", 1.1);
            this._toppingCalories.Add("sauce", 0.9);
        }
    }
}
