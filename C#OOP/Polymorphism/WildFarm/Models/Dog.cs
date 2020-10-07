using System.Security.Cryptography.X509Certificates;
using System.Text;
using WildFarm.Common;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : 
            base(name, weight, livingRegion)
        {
            this.WeightMultiplier = 0.4;
        }

        public sealed override double WeightMultiplier { get; protected set; }

        public override string Eat(Food food)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Woof!");
            bool hadEaten = true;

            if (food.GetType().Name != GlobalConstants.TigersDogsOwlsCatsFood)
            {
                GlobalConstants.ValidateFood("Dog", sb, food);
                hadEaten = false;
            }

            GlobalConstants.EatSuccessfully(hadEaten, this, food);

            return sb.ToString().TrimEnd();
            
        }
    }
}
