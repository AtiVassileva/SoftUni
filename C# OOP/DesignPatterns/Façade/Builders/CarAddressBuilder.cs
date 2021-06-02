using Façade.Core;
using Façade.Models;

namespace Façade.Builders
{
    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            this.Car = car;
        }

        public CarAddressBuilder WithCity(string city)
        {
            this.Car.City = city;
            return this;
        }

        public CarAddressBuilder WithAddress(string address)
        {
            this.Car.Address = address;
            return this;
        }
    }
}
