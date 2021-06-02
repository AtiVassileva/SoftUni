using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set
            {
                if (value < GlobalConstants.MinSideSize)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidSideExceptionMessage, "Radius"));
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override string Draw() => base.Draw() + "Circle";
    }
}
