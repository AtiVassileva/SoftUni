using System.Text;

namespace Cars
{
    public class Seat : Car, ICar
    {
        public const string Name = "Seat";

        public Seat(string model, string color) : base(color, model)
        {
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {Name} {this.Model}");
            sb.AppendLine("Engine start");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
