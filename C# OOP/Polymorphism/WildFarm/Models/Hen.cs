using System.Collections.Generic;
using System.Text;
using WildFarm.Common;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private readonly List<string> _possibleFoods;

        public Hen(string name, double weight, double wingSize) : 
            base(name, weight, wingSize)
        {
            this.WeightMultiplier = 0.35;
            this._possibleFoods = new List<string>()
            {
                "Vegetable",
                "Fruit",
                "Meat", 
                "Seeds"
            };

        }

        public sealed override double WeightMultiplier { get; protected set; }

        public override string Eat(Food food)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Cluck");

            bool hadEaten = true;
            if (!_possibleFoods.Contains(food.GetType().Name))
            {
                GlobalConstants.ValidateFood("Hen", sb, food);
                hadEaten = false;
            }

            GlobalConstants.EatSuccessfully(hadEaten, this, food);

            return sb.ToString().TrimEnd();
        }
    }
}
