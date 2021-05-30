using Chronometer.Common;

namespace Chronometer.Core
{
    using Contracts;

    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Engine
    {
        private readonly IChronometer chronometer;

        public Engine(IChronometer chronometer)
        {
            this.chronometer = chronometer;
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "start":
                        this.chronometer.Start();
                        break;
                    case "stop":
                        this.chronometer.Stop();
                        break;
                    case "time":
                        Console.WriteLine(this.chronometer.GetTime());
                        break;
                    case "lap":
                        Console.WriteLine(this.chronometer.Lap());
                        break;
                    case "laps":
                        var laps = this.chronometer.Laps();
                        Console.WriteLine(PrintLaps(laps));
                        break;
                    case "reset":
                        this.chronometer.Reset();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        throw new InvalidOperationException(GlobalConstants.NotSupportedCommandExceptionMessage);
                }
            }
        }

        private static string PrintLaps(IList<string> laps)
        {
            var sb = new StringBuilder();

            sb.AppendLine(laps.Count == 0 ? GlobalConstants.NoLapsMessage : GlobalConstants.AvailableLapsMessage);

            foreach (var lap in laps)
            {
                sb.AppendLine($"{laps.IndexOf(lap)}. {lap}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}