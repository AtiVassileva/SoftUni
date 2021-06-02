using System;
using System.Linq;
using Vehicles.IO;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public Engine(IReader reader, IWriter writer)
        {
            this._reader = reader;
            this._writer = writer;
        }
        public void Run()
        {
            var carInfo = this._reader.ReadLine().Split(" ").ToArray();
            var truckInfo = this._reader.ReadLine().Split(" ").ToArray();
            var busInfo = this._reader.ReadLine().Split(" ").ToArray();

            var car = (Car)CreateVehicle(carInfo);

            var truck = (Truck)CreateVehicle(truckInfo);

            var bus = (Bus)CreateVehicle(busInfo);

            var count = int.Parse(this._reader.ReadLine());

            for (var i = 0; i < count; i++)
            {
                try
                {
                    var cmdArgs = this._reader.ReadLine().Split(' ').ToArray();
                    var command = cmdArgs[0];

                    if (command == "Drive")
                    {
                        DriveVehicle(cmdArgs, car, truck, bus);
                    }
                    else if (command == "Refuel")
                    {
                        RefuelVehicle(cmdArgs, car, truck, bus);
                    }
                    else if (command == "DriveEmpty" && cmdArgs[1] == "Bus")
                    {
                        DriveEmptyBus(cmdArgs, bus);
                    }
                }
                catch (ArgumentException ae)
                {
                    this._writer.WriteLine(ae.Message);
                }

            }

            PrintVehicles(car, truck, bus);
        }

        private void PrintVehicles(Car car, Truck truck, Bus bus)
        {
            this._writer.WriteLine(car.ToString());
            this._writer.WriteLine(truck.ToString());
            this._writer.WriteLine(bus.ToString());
        }

        private void DriveEmptyBus(string[] cmdArgs, Bus bus)
        {
            var busDistance = double.Parse(cmdArgs[2]);
            this._writer.WriteLine(bus.DriveEmpty(busDistance));
        }

        private void DriveVehicle(string[] cmdArgs, Car car, Truck truck, Bus bus)
        {
            var distance = double.Parse(cmdArgs[2]);

            switch (cmdArgs[1])
            {
                case "Car":
                    this._writer.WriteLine(car.Drive(distance));
                    break;
                case "Truck":
                    this._writer.WriteLine(truck.Drive(distance));
                    break;
                case "Bus":
                    this._writer.WriteLine(bus.Drive(distance));
                    break;
            }
        }


        private static void RefuelVehicle(string[] cmdArgs, Car car, Truck truck, Bus bus)
        {
            var liters = double.Parse(cmdArgs[2]);

            switch (cmdArgs[1])
            {
                case "Car":
                    car.Refuel(liters);
                    break;
                case "Truck":
                    truck.Refuel(liters);
                    break;
                case "Bus":
                    bus.Refuel(liters);
                    break;
            }
        }


        private static Vehicle CreateVehicle(string[] vehicleArgs)
        {
            var vehicleType = vehicleArgs[0];
            var fuelQuantity = double.Parse(vehicleArgs[1]);
            var fuelConsumption = double.Parse(vehicleArgs[2]);
            var tankCapacity = double.Parse(vehicleArgs[3]);

            var currentVehicle = vehicleType switch
            {
                "Car" => (Vehicle) new Car(fuelQuantity, fuelConsumption, tankCapacity),
                "Bus" => new Bus(fuelQuantity, fuelConsumption, tankCapacity),
                "Truck" => new Truck(fuelQuantity, fuelConsumption, tankCapacity),
                _ => throw new Exception()
            };

            return currentVehicle;
        }
    }
}
