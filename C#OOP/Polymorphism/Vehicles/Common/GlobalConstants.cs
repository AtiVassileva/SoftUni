namespace Vehicles.Common
{
    public static class GlobalConstants
    {
        public static string InsufficientFuelMessage =
            "{0} needs refueling";

        public static string DrivenKilometersMessage =
            "{0} travelled {1} km";

        public static string InsufficientSpaceExceptionMessage =
            "Cannot fit {0} fuel in the tank";

        public static string NegativeFuelException =
            "Fuel must be a positive number";
    }
}
