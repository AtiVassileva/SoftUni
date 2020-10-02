using System.Collections.Generic;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        public void AddMission(IMission mission);
    }
}
