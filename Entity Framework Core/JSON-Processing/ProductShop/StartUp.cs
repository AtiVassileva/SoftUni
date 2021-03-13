using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Castle.Core.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper _mapper;
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

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var usersDto = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = _mapper.Map<IEnumerable<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var productsDto = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = _mapper.Map<IEnumerable<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var categoriesDto = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null);

            var categories = _mapper.Map<IEnumerable<Category>>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var categoriesProductsDto = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoriesProducts = _mapper.Map<IEnumerable<CategoryProduct>>(categoriesProductsDto);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName

                })
                .OrderBy(p => p.price).ToList();

            var jsonProducts = JsonConvert.SerializeObject(products, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                Formatting = Formatting.Indented,
            });

            return jsonProducts;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(ps => ps.BuyerId != null)
                        .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price,
                            buyerFirstName = ps.Buyer.FirstName,
                            buyerLastName = ps.Buyer.LastName,
                        })
                }).OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName).ToList();

            var json = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Count == 0 ? "0.00": c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                }).OrderByDescending(c => c.productsCount)
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users.ToList()
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(p => p.BuyerId != null),
                        products = u.ProductsSold.Where(p => p.BuyerId != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            }).ToArray()
                    }
                }).OrderByDescending(u => u.soldProducts.count)
                .ToArray();

            var result = new
            {
                usersCount = users.Length, 
                users
            };

            var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }
    }
}