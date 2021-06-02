using System.Collections.Generic;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model, int engineSpeed, int enginePower,
            int cargoWeight, string cargoType, double tire1Pressure, int tire1Age,
            double tire2Pressure, int tire2Age, double tire3Pressure,
            int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.tires = new List<Tire>()
            {
                new Tire(tire1Age, tire1Pressure),
                new Tire(tire2Age, tire2Pressure),
                new Tire(tire3Age, tire3Pressure),
                new Tire(tire4Age, tire4Pressure),
            };
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }
        public List<Tire> Tires
        {
            get { return this.tires; }
        }

        public override string ToString()
        {
            return this.Model;
        }
    }
}