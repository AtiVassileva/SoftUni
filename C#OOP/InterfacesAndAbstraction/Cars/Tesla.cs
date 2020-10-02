using System.Text;

namespace Cars
{
    public class Tesla : Car, ICar, IElectricCar
    {
        private const string Name = "Tesla";

        public Tesla(string model, string color, int batteries) : base(color, model)
        {
            this.Batteries = batteries;
        }

        public int Batteries { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {Name} {this.Model} with {this.Batteries} Batteries");
            sb.AppendLine("Engine start");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }

        
    }
}
