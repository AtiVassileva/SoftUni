namespace Chainblock.Common
{
    public static class ExceptionMessages
    {
        public static string InvalidIdExceptionMessage =
            "Id cannot be zero or negative!";

        public static string NullOrWhiteSpaceNameExceptionMessage =
            "Name of {0} cannot be null or whitespace!";

        public static string LessThanThreeSymbolsNameExceptionMessage =
            "Name of {0} cannot be less than 3 symbols!";

        public static string ZeroOrNegativeAmountExceptionMessage =
            "Amount cannot be negative!";

        public static string ExistingTransactionExceptionMessage =
            "Transaction with this id already exists!";

        public static string NonExistingTransactionExceptionMessage =
            "Transaction with given ID not found!";

        public static string RemoveNonExistingTransactionExceptionMessage =
            "You cannot remove non-existing transaction!";

        public static string NoMatchesWithThisStatusExceptionMessage =
            "Transactions with given transaction status not found!";

        public static string NoPersonWithGivenStatusExceptionMessage =
            "No {0} with given transaction status found!";

        public static string EmptyCollectionExceptionMessage =
            "No available transactions! Chainblock empty!";

        public static string NoTransactionsExceptionMessage =
            "No transactions found!";

    }
}