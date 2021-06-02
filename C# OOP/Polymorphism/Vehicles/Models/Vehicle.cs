using System;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Vehicle
    {
        private const double MinimumFuelQuantity = 1;
        

        protected Vehicle(double fuelQuantity, double liters, double tankCapacity)
        {
            this.LitersPerKm = liters;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = this.GiveFuelQuantity(fuelQuantity);
        }

        public double FuelQuantity { get; protected set; }
        public double LitersPerKm { get; protected set; }
        public double TankCapacity { get; protected set;}

        public virtual string Drive(double distance)
        {
            var actualConsumption = this.LitersPerKm;
            var canDrive = actualConsumption * distance <= this.FuelQuantity;

            if (!canDrive)
            {
                var message = string.Format(GlobalConstants.InsufficientFuelMessage, this.GetType().Name);
                return message;
            }

            this.FuelQuantity -= actualConsumption * distance;
            var successfulDriveMessage = string.Format(GlobalConstants.DrivenKilometersMessage, this.GetType().Name, distance);
            return successfulDriveMessage;
        }

        public virtual void Refuel(double liters)
        {
            if (liters < MinimumFuelQuantity)
            {
                throw new ArgumentException(GlobalConstants.NegativeFuelException);
            }

            if (this.FuelQuantity + liters >= this.TankCapacity)
            {
                var message = string.Format(GlobalConstants.InsufficientSpaceExceptionMessage, liters);
                throw new ArgumentException(message);
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }

        private double GiveFuelQuantity(double fuelQuantity)
        {
            if (fuelQuantity > this.TankCapacity)
            {
                return 0;
            }
            return fuelQuantity;
        }
    }
}
