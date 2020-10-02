using System;

namespace P01.ClassBoxData
{
    public class Box
    {
        private double width;
        private double length;
        private double height;

        public Box(double width, double length, double height)
        {
            this.Width = width;
            this.Length = length;
            this.Height = height;
        }

        public double Width
        {
            get => this.width;
            private set
            {
                this.ValidateSide(value, nameof(this.Width));
                this.width = value;
            }

        }

        public double Length
        {
            get => this.length;
            private set
            {
                this.ValidateSide(value, nameof(this.Length));
                this.length = value;
            }

        }

        public double Height
        {
            get => this.height;
            private set
            {
                this.ValidateSide(value, nameof(this.Height));
                this.height = value;
            }

        }

        public double FindSurfaceArea()
        {
            var surfaceArea = 2 * (this.Length * this.Width) +
                              2 * (this.Length * this.Height) +
                              2 * (this.Width * this.Height);

            return surfaceArea;
        }

        public double FindLateralSurfaceArea()
        {
            var lateralSurfaceArea = 2 * (this.Length * this.Height) +
                                     2 * (this.Width * this.Height);

            return lateralSurfaceArea;
        }

        public double FindVolume()
        {
            var volume = this.Width * this.Length * this.Height;
            return volume;
        }

        private void ValidateSide(double value, string type)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{type} cannot be zero or negative.");
            }
        }
    }
}
