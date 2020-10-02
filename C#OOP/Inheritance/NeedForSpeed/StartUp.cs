using System;
using NeedForSpeed.Cars;
using NeedForSpeed.Motorcycles;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            var ferarri = new SportCar(400, 32);

            Console.WriteLine(ferarri.FuelConsumption);

            ferarri.Drive(3);
            Console.WriteLine($"Ferrari after driving: {ferarri.Fuel}");

            var yamaha = new RaceMotorcycle(300, 23.4);
            yamaha.Drive(2);

            Console.WriteLine(yamaha.FuelConsumption);
            Console.WriteLine($"Yamaha after driving: {yamaha.Fuel}");

            var car = new Car(120, 65);

            Console.WriteLine(car.FuelConsumption);

            car.Drive(10);
            Console.WriteLine($"Car after driving: {car.Fuel}");

            var crossMotor = new CrossMotorcycle(80, 12.3);

            Console.WriteLine(crossMotor.FuelConsumption);

            crossMotor.Drive(4);

            Console.WriteLine($"Cross motor after driving: {crossMotor.Fuel}");
        }
    }
}
