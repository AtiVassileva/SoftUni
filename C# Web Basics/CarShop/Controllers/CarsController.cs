using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models;
using CarShop.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUserService userService;
        private readonly IValidator validator;
        private readonly CarShopDbContext dbContext;

        public CarsController(IUserService userService, IValidator validator, CarShopDbContext dbContext)
        {
            this.userService = userService;
            this.validator = validator;
            this.dbContext = dbContext;
        }

        [Authorize]
        public HttpResponse Add()
        {
            var userId = this.User.Id;

            if (this.userService.IsUserMechanic(userId))
            {
                return this.Unauthorized();
            }

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CarFormModel model)
        {
            var userId = this.User.Id;

            if (this.userService.IsUserMechanic(userId))
            {
                return this.Unauthorized();
            }

            var errors = this.validator.ValidateCar(model);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            var car = new Car()
            {
                Model = model.Model,
                Year = model.Year,
                PlateNumber = model.PlateNumber,
                PictureUrl = model.Image,
                OwnerId = userId
            };

            this.dbContext.Cars.Add(car);
            this.dbContext.SaveChanges();

            return this.Redirect("/Cars/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var carsQuery = this.dbContext.Cars.AsQueryable();
            var usedId = this.User.Id;

            if (this.userService.IsUserMechanic(usedId))
            {
                carsQuery = carsQuery.Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery.Where(c => c.OwnerId == usedId);
            }

            var cars = carsQuery.Select(c => 
                new CarListingModel
            {
                Id = c.Id,
                Model = c.Model,
                Year = c.Year,
                Image = c.PictureUrl,
                PlateNumber = c.PlateNumber,
                RemainingIssues = c.Issues.Count(i => !i.IsFixed),
                FixedIssues = c.Issues.Count(i => i.IsFixed)

            }).ToList();

            return this.View(cars);
        }
    }
}
