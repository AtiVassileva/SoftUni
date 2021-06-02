using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<ISoldier> _privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) :
            base(id, firstName, lastName, salary)
        {
            this._privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates =>
            (IReadOnlyCollection<ISoldier>) this._privates;

        public void AddPrivate(ISoldier @private)
        {
            this._privates.Add(@private);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var soldier in this._privates)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
