using Raiding.Common;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = CommonFeatures.DruidAndRoguePower;
        }

        public sealed override int Power { get; protected set; }

        public override string CastAbility()
        {
            var message = 
                string.Format(CommonFeatures.DruidAndPaladinCastingMessage, 
                    this.GetType().Name, this.Name, this.Power);

            return message;
        }
    }
}
