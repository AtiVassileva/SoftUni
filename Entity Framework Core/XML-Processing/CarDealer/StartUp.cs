using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper _mapper;
        public static void Main()
        {
            var context = new CarDealerContext();
            Console.WriteLine(GetLocalSuppliers(context));
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            _mapper = config.CreateMapper();
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var root = new XmlRootAttribute("Suppliers");
            var serializer = new XmlSerializer(typeof(List<SupplierInputModel>), root);

            var suppliersDto = (List<SupplierInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var suppliers = _mapper.Map<List<Supplier>>(suppliersDto);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var root = new XmlRootAttribute("Parts");
            var serializer = new XmlSerializer(typeof(List<PartInputModel>), root);

            var validSuppliersIds = context.Suppliers.Select(s => s.Id).ToList();

            var partsDto = (List<PartInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var parts = _mapper.Map<List<Part>>(partsDto.Where(p => validSuppliersIds.Contains(p.SupplierId)));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var root = new XmlRootAttribute("Cars");
            var serializer = new XmlSerializer(typeof(List<CarInputModel>), root);

            var carsDto = (List<CarInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var allParts = context.Parts.Select(p => p.Id).ToList();

            var cars = carsDto.Select(c => new Car
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                PartCars = c.CarPartsInputModel.Select(cp => cp.Id)
                    .Distinct()
                    .Intersect(allParts)
                    .Select(partId => new PartCar
                    {
                        PartId = partId
                    }).ToList()
            }).ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var root = new XmlRootAttribute("Customers");
            var serializer = new XmlSerializer(typeof(List<CustomerInputModel>), root);

            var customersDto = (List<CustomerInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var customers = _mapper.Map<List<Customer>>(customersDto);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var root = new XmlRootAttribute("Sales");
            var serializer = new XmlSerializer(typeof(List<SaleInputModel>), root);

            var salesDto = (List<SaleInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var validCarIds = context.Cars.Select(c => c.Id).ToList();

            var sales = _mapper.Map<List<Sale>>(salesDto.Where(s => validCarIds.Contains(s.CarId)));

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.TravelledDistance > 2000000)
                .Select(c => new CarOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                }).OrderBy(c => c.Make).ThenBy(c => c.Model).Take(10).ToList();

            var root = new XmlRootAttribute("cars");
            var serializer = new XmlSerializer(typeof(List<CarOutputModel>), root);

            var textWriter = new StringWriter();

            var namespacesSerializer = new XmlSerializerNamespaces();
            namespacesSerializer.Add("", "");

            serializer.Serialize(textWriter, cars, namespacesSerializer);

            return textWriter.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BmwOutputModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var root = new XmlRootAttribute("cars");
            var serializer = new XmlSerializer(typeof(List<BmwOutputModel>), root);

            var textWriter = new StringWriter();

            var namespacesSerializer = new XmlSerializerNamespaces();
            namespacesSerializer.Add("", "");

            serializer.Serialize(textWriter, bmwCars, namespacesSerializer);

            return textWriter.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new SupplierOutputModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                }).ToList();

            var serializer = new XmlSerializer(typeof(List<SupplierOutputModel>), new XmlRootAttribute("suppliers"));

            var textWriter = new StringWriter();

            var namespacesSerializer = new XmlSerializerNamespaces();
            namespacesSerializer.Add("", "");

            serializer.Serialize(textWriter, suppliers, namespacesSerializer);

            return textWriter.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new CarPartsOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    PartOutputModels = c.PartCars.Select(p => new PartOutputModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price,
                    }).OrderByDescending(p => p.Price).ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5).ToList();

            var root = new XmlRootAttribute("cars");
            var serializer = new XmlSerializer(typeof(List<CarPartsOutputModel>), root);

            var textWriter = new StringWriter();

            var namespacesSerializer = new XmlSerializerNamespaces();
            namespacesSerializer.Add("", "");

            serializer.Serialize(textWriter, carsWithParts, namespacesSerializer);

            return textWriter.ToString();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerTotalSales = context.Customers.Where(c => c.Sales.Any())
                .Select(c => new CustomerOutputModel
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            var root = new XmlRootAttribute("customers");
            var serializer = new XmlSerializer(typeof(List<CustomerOutputModel>), root);

            var textWriter = new StringWriter();

            var namespacesSerializer = new XmlSerializerNamespaces();
            namespacesSerializer.Add("", "");

            serializer.Serialize(textWriter, customerTotalSales, namespacesSerializer);

            return textWriter.ToString();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesList = context.Sales.Select(s => new SaleOutputModel
            {
                Car = new CarSaleOutputModel
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                Discount = s.Discount,
                CustomerName = s.Customer.Name,
                Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100m
            }).ToList();

            var root = new XmlRootAttribute("sales");
            var serializer = new XmlSerializer(typeof(List<SaleOutputModel>), root);

            var textWriter = new StringWriter();

            var namespacesSerializer = new XmlSerializerNamespaces();
            namespacesSerializer.Add("", "");

            serializer.Serialize(textWriter, salesList, namespacesSerializer);

            return textWriter.ToString();
        }
    }
}