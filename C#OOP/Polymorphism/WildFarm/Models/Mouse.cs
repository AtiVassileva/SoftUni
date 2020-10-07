using System.Text;
using WildFarm.Common;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private string SecondFood = "Fruit";

        public Mouse(string name, double weight, string livingRegion) : 
            base(name, weight, livingRegion)
        {
            this.WeightMultiplier = 0.1;
        }

        public sealed override double WeightMultiplier { get; protected set; }

        public override string Eat(Food food)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Squeak");

            bool hadEaten = true;

            if (food.GetType().Name != GlobalConstants.CatsAndMiceFood && 
                food.GetType().Name != SecondFood)
            {
                GlobalConstants.ValidateFood("Mouse", sb, food);
                hadEaten = false;
            }

            GlobalConstants.EatSuccessfully(hadEaten, this, food);

            return sb.ToString().TrimEnd();
        }

    }
}
