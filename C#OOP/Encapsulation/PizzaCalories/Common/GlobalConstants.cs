namespace P04.PizzaCalories.Common
{
    public static class GlobalConstants
    {
        public static double BaseCalories = 2;

        public static string InvalidTopping = "";
        public static string InvalidToppingWeight = "";

        public const double ToppingMinWeight = 1;
        public const double ToppingMaxWeight = 50;

        public const double MinDoughWeight = 1;
        public const double MaxDoughWeight = 200;

        public const int MinPizzaNameSymbols = 1;
        public const int MaxPizzaNameSymbols = 15;

        public const int MinToppingsCount = 0;
        public const int MaxToppingsCount = 10;


    }
}
