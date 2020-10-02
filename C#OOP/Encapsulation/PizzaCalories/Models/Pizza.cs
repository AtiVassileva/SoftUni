using System;
using System.Collections.Generic;
using P04.PizzaCalories.Common;
using PizzaCalories.Common;

namespace P04.PizzaCalories.Models
{
    public class Pizza
    {
        private string _name;
        private Dough _dough;
        private readonly List<Topping> _toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this._toppings = new List<Topping>();
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > GlobalConstants.MaxPizzaNameSymbols)
                {
                    throw new ArgumentException(ErrorMessages.InvalidPizzaNameException);
                }

                this._name = value;
            }
        }

        public Dough Dough
        {
            get => this._dough;
            private set => this._dough = value;
        }

        public IReadOnlyList<Topping> Toppings => this._toppings;

        public void AddTopping(Topping topping)
        {
            if (this._toppings.Count > GlobalConstants.MaxToppingsCount)
            {
                throw new ArgumentException(ErrorMessages.InvalidNumberOfToppingsException);
            }
            this._toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateTotalCalories():F2} Calories.";
        }

        private double CalculateTotalCalories()
        {
            var toppingsCalories = CalculateToppingsCalories();

            var res = this.Dough.CalculateCalories() + toppingsCalories;
            return res;
        }

        private double CalculateToppingsCalories()
        {
            var toppingsCalories = 0.0;
            foreach (var topping in this._toppings)
            {
                toppingsCalories += topping.CalculateCalories();
            }

            return toppingsCalories;
        }
    }
}
