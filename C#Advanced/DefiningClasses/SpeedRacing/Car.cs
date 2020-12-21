using System;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public void Drive(double wantedDistance)
        {
            var canMove = this.FuelAmount / this.FuelConsumptionPerKilometer >= wantedDistance;

            if (canMove)
            {
                this.FuelAmount -= wantedDistance * this.FuelConsumptionPerKilometer;
                this.TravelledDistance += wantedDistance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}