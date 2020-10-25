using NUnit.Framework;

namespace Tests
{
    using System;
    using CarManager;
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Skoda", "Octavia", 6, 22);

        }

        [TestCase(null, "A4", 6, 12)]
        [TestCase("Mercedes", null, 7, 13)]
        [TestCase("Seat", "Cordoba", 0, 20)]
        [TestCase(null, "A4", 6, -1)]
        [TestCase("Peugeot", "307", -2, 10)]
        [TestCase("BMW", "X6", 2, 0)]
        public void PropertiesShouldThrowExceptionWhenInvalidValidation
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => { this.car = new Car(make, model, fuelConsumption, fuelCapacity); });
        }

        [Test]
        public void TestIfConstructorWorksProperly()
        {
            this.car = new Car("Ford", "Focus", 5, 12.4);

            Assert.AreEqual("Ford", this.car.Make);
            Assert.AreEqual("Focus", this.car.Model);
            Assert.AreEqual(5, this.car.FuelConsumption);
            Assert.AreEqual(12.4, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);


        }

        [TestCase(-20.4)]
        [TestCase(-1.8)]
        [TestCase(0)]
        public void RefuelShouldThrowExceptionWhenFuelNegativeOrZero(double negativeFuel)
        {
            Assert.Throws<ArgumentException>(() => { this.car.Refuel(negativeFuel); });
        }

        [TestCase(8)]
        [TestCase(2.3)]
        public void CheckIfRefuelWorksProperly(double fuelLiters)
        {
            var expectedLiters = this.car.FuelAmount + fuelLiters;

            this.car.Refuel(fuelLiters);

            var actualLiters = this.car.FuelAmount;

            Assert.AreEqual(expectedLiters, actualLiters);
        }

        [TestCase(40)]
        [TestCase(30.8)]
        public void CheckIfRefuelWorksWithMoreLitersThanCapacity(double liters)
        {
            var expectedLiters = this.car.FuelCapacity;

            this.car.Refuel(liters);

            var actualLiters = this.car.FuelAmount;

            Assert.AreEqual(expectedLiters, actualLiters);
        }

        [TestCase(2.4)]
        [TestCase(3)]
        public void CheckIfDriveWorksProperly(double distance)
        {
            this.car.Refuel(10);
            var neededFuel = (distance / 100) * this.car.FuelConsumption;

            var expectedFuel = this.car.FuelAmount - neededFuel;

            this.car.Drive(distance);

            var actualFuel = this.car.FuelAmount;

            Assert.AreEqual(expectedFuel, actualFuel);

        }

        [TestCase(100)]
        [TestCase(139.5)]
        public void DriveShouldThrowExceptionWhenDistanceNeedsMoreFuel(double distance)
        {
            this.car.Refuel(2);

            Assert.Throws<InvalidOperationException>(() => { this.car.Drive(distance); });

        }
    }
}