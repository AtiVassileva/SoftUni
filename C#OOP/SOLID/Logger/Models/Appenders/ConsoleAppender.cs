using System;
using System.Globalization;
using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public long MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var format = this.Layout.Format;

            var dateTime = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            var formattedMessage = string.Format(
                format, dateTime.ToString(GlobalConstants.DateFormat, 
                    CultureInfo.InvariantCulture),
                message, level.ToString());

            Console.WriteLine(formattedMessage);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, " +
                   $"Layout type: {this.Layout.GetType().Name}, " +
                   $"Report level: {this.Level.ToString().ToUpper()}, " +
                   $"Messages appended: {this.MessagesAppended}";
        }
    }
}
