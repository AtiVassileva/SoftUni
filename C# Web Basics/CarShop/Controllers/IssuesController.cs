using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models;
using CarShop.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly CarShopDbContext dbContext;
        private readonly IValidator validator;

        public IssuesController(CarShopDbContext dbContext, IValidator validator)
        {
            this.dbContext = dbContext;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            var car = this.dbContext.Cars.FirstOrDefault(c => c.Id == carId);

            if (car == null)
            {
                return this.Error("Car does not exist.");
            }

            var carModel = new CarIssueModel()
            {
                Id = car.Id,
                Model = car.Model,
                Year = car.Year,
                Issues = this.dbContext.Issues.Where(i => i.CarId == carId).Select(i => new IssueListingViewModel
                {
                    Id = i.Id,
                    Description = i.Description,
                    Status = i.IsFixed ? "Yes" : "Not yet"
                }).ToList()
            };

            return this.View(carModel);
        }

        [Authorize]
        public HttpResponse Add(string carId) => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(string carId, IssueFormModel model)
        {
            var car = this.dbContext.Cars.FirstOrDefault(c => c.Id == carId);

            if (car == null)
            {
                return this.Error("Car does not exist.");
            }

            var errors = this.validator.ValidateIssue(model);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            var issue = new Issue
            {
                Description = model.Description,
                IsFixed = false,
                CarId = carId
            };

            this.dbContext.Issues.Add(issue);
            this.dbContext.SaveChanges();

            return this.Redirect($"CarIssues?CarId={carId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            var user = this.dbContext.Users.First(u => u.Id == this.User.Id);

            if (!user.IsMechanic)
            {
                return this.Unauthorized();
            }

            var issue = this.dbContext.Issues.FirstOrDefault(i => i.Id == issueId);

            if (issue == null)
            {
                return this.BadRequest();
            }

            issue.IsFixed = true;
            this.dbContext.SaveChanges();
            
            return this.Redirect($"CarIssues?CarId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var issue = this.dbContext.Issues.FirstOrDefault(i => i.Id == issueId);

            if (issue == null)
            {
                return this.BadRequest();
            }

            this.dbContext.Issues.Remove(issue);
            this.dbContext.SaveChanges();

            return this.Redirect($"CarIssues?CarId={carId}");
        }
    }
}
