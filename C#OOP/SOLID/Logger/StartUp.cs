using System;
using System.Collections.Generic;
using System.Linq;
using Logger.Core;
using Logger.Factories;
using Logger.Models.Contracts;

namespace Logger
{
    public class StartUp
    {
        public static void Main()
        {
            var appenderCount = int.Parse(Console.ReadLine());

            var appenders = new List<IAppender>();

            ParseAppendersInput(appenderCount, appenders);

            var logger = new Logger.Models.Logger(appenders);

            var engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppendersInput(int appenderCount, List<IAppender> appenders)
        {
            AppenderFactory appenderFactory = new AppenderFactory();

            for (var i = 0; i < appenderCount; i++)
            {
                var appendersArgs = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var appenderType = appendersArgs[0];
                var layoutType = appendersArgs[1];
                var level = "INFO";

                if (appendersArgs.Length == 3)
                {
                    level = appendersArgs[2];
                }

                try
                {
                    var appender = appenderFactory.ProduceAppender
                        (appenderType, layoutType, level);

                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
