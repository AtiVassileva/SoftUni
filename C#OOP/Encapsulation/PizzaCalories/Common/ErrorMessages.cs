using P04.PizzaCalories.Common;

namespace PizzaCalories.Common
{
    public static class ErrorMessages
    {
        public static string InvalidDoughExceptionMessage =
            "Invalid type of dough.";

        public static string InvalidWeightException =
            $"Dough weight should be in the range [{GlobalConstants.MinDoughWeight}..{GlobalConstants.MaxDoughWeight}].";

        public static string InvalidToppingException =
            $"Cannot place {GlobalConstants.InvalidTopping} on top of your pizza.";

        public static string InvalidToppingWeightException =
            $"{GlobalConstants.InvalidToppingWeight} weight should be in the range [{GlobalConstants.ToppingMinWeight}..{GlobalConstants.ToppingMaxWeight}].";

        public static string InvalidPizzaNameException =
            $"Pizza name should be between {GlobalConstants.MinPizzaNameSymbols} and {GlobalConstants.MaxPizzaNameSymbols} symbols.";

        public static string InvalidNumberOfToppingsException =
            $"Number of toppings should be in range [{GlobalConstants.MinToppingsCount}..{GlobalConstants.MaxToppingsCount}].";
    }
}
