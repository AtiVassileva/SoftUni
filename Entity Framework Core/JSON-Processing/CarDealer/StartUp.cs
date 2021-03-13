using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper _mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            _mapper = config.CreateMapper();
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = _mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var validSuppliersIds = context.Suppliers.Select(s => s.Id).ToList();

            var partsDto = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(p => validSuppliersIds.Contains(p.SupplierId));

            var parts = _mapper.Map<IEnumerable<Part>>(partsDto);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }
                cars.Add(currentCar);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);

            var customers = _mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var salesDto = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);

            var sales = _mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new {
                    c.Name, 
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo),
                    c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers);
            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                }).ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = p.Part.Price.ToString("F2"),
                    })
                }).ToList();

            var json = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSales = context.Customers.Where(c => c.Sales.Any())
                .Select(c => new 
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(totalSales, Formatting.Indented);

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var topSales = context.Sales.Select(s => new
            {
                car = new
                {
                    s.Car.Make,
                    s.Car.Model,
                    s.Car.TravelledDistance
                },
                customerName = s.Customer.Name,
                Discount = s.Discount.ToString("f2"),
                price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                priceWithDiscount = ((s.Car.PartCars.Sum(pc => pc.Part.Price)) * (1 - s.Discount * 0.01m))
                    .ToString("F2")
            }).Take(10).ToList();

            var json = JsonConvert.SerializeObject(topSales, Formatting.Indented);

            return json;
        }
    }
}