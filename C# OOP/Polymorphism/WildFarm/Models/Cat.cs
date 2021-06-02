using System.Text;
using WildFarm.Common;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : 
            base(name, weight, livingRegion, breed)
        {
            this.WeightMultiplier = 0.3;
        }

        public sealed override double WeightMultiplier { get; protected set; }

        public override string Eat(Food food)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Meow");
            var hadEaten = true;

            if (food.GetType().Name != GlobalConstants.CatsAndMiceFood && 
                food.GetType().Name != GlobalConstants.TigersDogsOwlsCatsFood)
            {
                GlobalConstants.ValidateFood("Cat", sb, food);
                hadEaten = false;
            }

            GlobalConstants.EatSuccessfully(hadEaten, this, food);
            
            return sb.ToString().TrimEnd();
        }
    }
}
