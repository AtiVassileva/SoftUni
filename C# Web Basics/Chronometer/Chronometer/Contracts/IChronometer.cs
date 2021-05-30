using System.Collections.Generic;

namespace Chronometer.Contracts
{
    public interface IChronometer
    {
        string GetTime();

        List<string> Laps();

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}