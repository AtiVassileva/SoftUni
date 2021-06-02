using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get => this._width;
            private set
            {
                ValidateSide(value, "Width");

                this._width = value;
            }
        }

        public double Height
        {
            get => this._height;
            private set
            {
                ValidateSide(value, "Height");
                this._height = value;
            }
            
        }

        public override double CalculatePerimeter()
        {
            return (2 * this.Width) + (2 * this.Height);
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }

        private static void ValidateSide(double value, string sideName)
        {
            if (value < GlobalConstants.MinSideSize)
            {
                throw new ArgumentException(string.Format(GlobalConstants.InvalidSideExceptionMessage, sideName));
            }
        }
    }
}
