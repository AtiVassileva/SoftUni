using System;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AdditionalLiters = 1.6;
        private const double FuelModifier = 0.95;
        private const double MinimumLiters = 1;

        public Truck(double fuelQuantity, double liters, double tankCapacity) :
             base(fuelQuantity, liters + AdditionalLiters, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters < MinimumLiters)
            {
                throw new ArgumentException(GlobalConstants.NegativeFuelException);
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                var message = string.Format(GlobalConstants.InsufficientSpaceExceptionMessage, liters);
                throw new ArgumentException(message);
            }
            this.FuelQuantity += liters * FuelModifier;
        }
    }
}
