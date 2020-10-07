using Raiding.Common;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = CommonFeatures.PaladinAndWarriorPower;
        }

        public sealed override int Power { get; protected set; }

        public override string CastAbility()
        {
            var message = string.Format(CommonFeatures.RogueAndWarriorCastingMessage,
                this.GetType().Name, this.Name, this.Power);

            return message;
        }
    }
}
