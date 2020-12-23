namespace _02.LegionSystem.Models
{
    public class Kamikaze : Enemy
    {
        public Kamikaze(int attackSpeed, int health) 
            : base(attackSpeed, health)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
