using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> _appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this._appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders =>
            (IReadOnlyCollection<IAppender>) this._appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this._appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Logger info");

            foreach (IAppender appender in this._appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
