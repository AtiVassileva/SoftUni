using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper _mapper;
        public static void Main()
        {
            var context = new ProductShopContext();
            Console.WriteLine(GetUsersWithProducts(context));
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            _mapper = config.CreateMapper();
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var root = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(List<UserInputModel>), root);

            var usersDto = (List<UserInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var users = _mapper.Map<List<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var root = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(List<ProductInputModel>), root);

            var productsDto = (List<ProductInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var products = _mapper.Map<List<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var root = new XmlRootAttribute("Categories");
            var serializer = new XmlSerializer(typeof(List<CategoryInputModel>), root);

            var categoriesDto = (List<CategoryInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var categories = _mapper.Map<List<Category>>(categoriesDto.Where(c => c.Name != null));

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var root = new XmlRootAttribute("CategoryProducts");
            var serializer = new XmlSerializer(typeof(List<CategoryProductInputModel>), root);

            var categoryProductsDto =
                (List<CategoryProductInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = _mapper.Map<List<CategoryProduct>>(categoryProductsDto);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductOutputModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                }).OrderBy(p => p.Price).Take(10).ToList();

            var root = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(List<ProductOutputModel>), root);

            var textWriter = new StringWriter();

            var serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add("", "");

            serializer.Serialize(textWriter, products, serializerNamespaces);

            return textWriter.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new UserOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProductOutputModels = u.ProductsSold
                        .Where(ps => ps.BuyerId != null)
                        .Select(ps => new SoldProductOutputModel
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                        }).ToArray()
                }).OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName).Take(5).ToList();


            var root = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(List<UserOutputModel>), root);

            var textWriter = new StringWriter();

            var serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add("", "");

            serializer.Serialize(textWriter, soldProducts, serializerNamespaces);

            return textWriter.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoryOutputModel
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                }).OrderByDescending(c => c.Count).ThenBy(c => c.TotalRevenue)
                .ToList();

            var root = new XmlRootAttribute("Categories");
            var serializer = new XmlSerializer(typeof(List<CategoryOutputModel>), root);

            var textWriter = new StringWriter();

            var serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add("", "");

            serializer.Serialize(textWriter, categories, serializerNamespaces);

            return textWriter.ToString();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.ToArray()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))

                .Select(u => new UserExportModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsContainer
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                        .Select(p => new SoldProductOutputModel
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).OrderByDescending(p => p.Price).ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10).ToArray();

            var finalModel = new UserProductsFinalModel
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.BuyerId != null)),
                Users = users
            };

            var xmlSerializer = new XmlSerializer(typeof(UserProductsFinalModel), new XmlRootAttribute("Users"));

            var serializerNamespaces = new XmlSerializerNamespaces();

            serializerNamespaces.Add("", "");

            var textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, finalModel, serializerNamespaces);

            return textWriter.ToString();
        }
    }
}