namespace MyWebServer.Server.Common
{
    public static class GlobalConstants
    {
        public static string NullValueExceptionMessage =
            "{0} cannot be null.";

        public static string TooLargeRequestExceptionMessage =
            "Request is too large.";

        public static string NotSupportedMethodExceptionMessage =
            "Method {0} is not supported.";

        public static string InvalidRequestExceptionMessage =
            "Request is not valid.";
    }
}