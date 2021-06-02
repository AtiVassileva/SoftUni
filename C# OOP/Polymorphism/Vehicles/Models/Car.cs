namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AdditionalLiters = 0.9;

        public Car(double fuelQuantity, double liters, double tankCapacity) 
            : base(fuelQuantity, liters + AdditionalLiters, tankCapacity)
        {
        }

    }
}
