using Vehicles.Common;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FuelAddition = 1.4;

        public Bus(double fuelQuantity, double liters, double tankCapacity) : 
            base(fuelQuantity, liters, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            var actualConsumption = this.LitersPerKm + FuelAddition;
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

        public string DriveEmpty(double distance)
        {
            var neededFuel = distance * this.LitersPerKm;
            if (neededFuel > this.FuelQuantity)
            {
                var insufficientFuelMessage = string.Format(GlobalConstants.InsufficientFuelMessage, this.GetType().Name);
                return insufficientFuelMessage;
            }

            this.FuelQuantity -= neededFuel;
            var message = string.Format(GlobalConstants.DrivenKilometersMessage, this.GetType().Name);
            return message;
        }

    }
}

