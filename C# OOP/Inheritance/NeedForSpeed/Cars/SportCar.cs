namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        private const double SportCarDefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel) : 
            base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => SportCarDefaultFuelConsumption;
    }
}
