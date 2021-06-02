using System;
using System.Text;
using System.Collections.Generic;

namespace CarSalesmen
{
    public class Car
    {

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, double weight)
        : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
        : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, double weight, string color)
        : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double? Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var weightStr = this.Weight.HasValue ? this.Weight.ToString() : "n/a";
            var colorStr = string.IsNullOrEmpty(this.Color) ? "n/a" : this.Color;

            sb.AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine}")
                .AppendLine($"  Weight: {weightStr}")
                .AppendLine($"  Color: {colorStr}");

            return sb.ToString().TrimEnd();
        }
    }
}