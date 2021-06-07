using System;

namespace MyWebServer.Server.Common
{
    public static class Guard
    {
        private const string DefaultName = "Value";
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                name ??= DefaultName;
                var message = string.Format(GlobalConstants.NullValueExceptionMessage, name);
                throw new ArgumentException(message);
            }
        }
    }
}