using System.Text;
using WildFarm.Common;

namespace WildFarm.Models
{
    public sealed class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : 
            base(name, weight, livingRegion, breed)
        {
            this.WeightMultiplier = 1;
        }

        public override double WeightMultiplier { get; protected set; }

        public override string Eat(Food food)
        {
            var sb = new StringBuilder();
            sb.AppendLine("ROAR!!!");
            bool hadEaten = true;

            if (food.GetType().Name != GlobalConstants.TigersDogsOwlsCatsFood)
            {
                GlobalConstants.ValidateFood("Tiger", sb, food);
                hadEaten = false;
            }

            GlobalConstants.EatSuccessfully(hadEaten, this, food);

            return sb.ToString().TrimEnd();
        }
    }
}
