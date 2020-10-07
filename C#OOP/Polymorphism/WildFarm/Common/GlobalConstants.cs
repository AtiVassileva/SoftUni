using System.Text;
using WildFarm.Models;

namespace WildFarm.Common
{
    public static class GlobalConstants
    {
        public static string InvalidFoodMessage =
            "{0} does not eat {1}!";

        public static string TigersDogsOwlsCatsFood = "Meat";

        public static string CatsAndMiceFood = "Vegetable";

        public static void ValidateFood(string animalType, StringBuilder sb, Food food)
        {
            var message = string.Format(GlobalConstants.InvalidFoodMessage,
                   animalType, food.GetType().Name);

                sb.AppendLine(message);
        }

        public static void EatSuccessfully(bool hadEaten, Animal animal, Food food)
        {
            if (hadEaten)
            {
                animal.Weight += animal.WeightMultiplier * food.Quantity;
                animal.FoodEaten += food.Quantity;
            }
        }
    }
}
