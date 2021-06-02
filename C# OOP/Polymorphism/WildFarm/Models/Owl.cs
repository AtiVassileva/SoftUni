using System;
using System.Text;
using WildFarm.Common;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : 
            base(name, weight, wingSize)
        {
            this.WeightMultiplier = 0.25;
        }

        public sealed override double WeightMultiplier { get; protected set; }

        public override string Eat(Food food)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Hoot Hoot");
            bool hadEaten = true;

            if (food.GetType().Name != GlobalConstants.TigersDogsOwlsCatsFood)
            {
                GlobalConstants.ValidateFood("Owl", sb, food);
                hadEaten = false;
            }

            GlobalConstants.EatSuccessfully(hadEaten, this, food);

            return sb.ToString().TrimEnd();
        }
    }
}
