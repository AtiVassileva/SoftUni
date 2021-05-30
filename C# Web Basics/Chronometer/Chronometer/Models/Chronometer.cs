using Chronometer.Contracts;
using Chronometer.Common;
﻿using System.Diagnostics;
using System.Collections.Generic;


namespace Chronometer.Models
{
    public class Chronometer : IChronometer
    {
        private readonly Stopwatch stopwatch;
        private List<string> lapsStatistics;

        public Chronometer() 
        {
            this.stopwatch = new Stopwatch();
            this.lapsStatistics = new List<string>();
        }

        public string GetTime()
        {
            var minutes = (this.stopwatch.ElapsedMilliseconds / 1000) / 60;
            var seconds = (this.stopwatch.ElapsedMilliseconds / 1000) % 60;
            var milliseconds = this.stopwatch.ElapsedMilliseconds;

            return string.Format(GlobalConstants.CurrentTimeStatisticsFormat, minutes, seconds, milliseconds);
        }

        public List<string> Laps() => this.lapsStatistics;

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }

        public string Lap()
        {
            var currentLap = this.GetTime();
            this.lapsStatistics.Add(currentLap);
            return currentLap;
        }

        public void Reset()
        {
            this.stopwatch.Reset();
            this.lapsStatistics = new List<string>();
        }
    }
}
