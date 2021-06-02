using System.Runtime.Intrinsics.X86;

namespace INStock.Common
{
    public static class ExceptionMessages
    {
        public static string NegativeQuantityExceptionMessage =
            "Quantity cannot be negative!";

        public static string NullOrWhitespaceLabelExceptionMessage =
            "Label cannot be null or whitespace!";

        public static string LessThanThreeSymbolsExceptionMessage =
            "Label cannot contain less than 3 symbols!";

        public static string NegativePriceExceptionMessage =
            "Price cannot be negative!";

        public static string DuplicateLabelExceptionMessage =
            "A product with label {0} already exists!";

        public static string NullProductExceptionMessage =
            "Product cannot be null!";

        public static string IndexOutOfRangeExceptionMessage =
            "Index out of the borders of collection!";

        public static string InvalidLabelExceptionMessage =
            "There is no product with this label!";

        public static string EmptyProductStockExceptionMessage =
            "Product stock is empty!";

    }
}