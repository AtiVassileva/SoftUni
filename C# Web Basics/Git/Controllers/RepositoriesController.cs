using System;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.Models;
using Git.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;
using static Git.Data.DataConstants;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly GitDbContext dbContext;
        private readonly IValidator validator;

        public RepositoriesController(GitDbContext dbContext, IValidator validator)
        {
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            var repos = this.dbContext.Repositories
                .Where(r => r.IsPublic)
                .Select(r => new RepoListingModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("D"),
                    CommitsCount = r.Commits.Count
                }).ToList();

            return this.View(repos);
        }

        [Authorize]
        public HttpResponse Create() => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(RepoFormModel model)
        {
            var errors = this.validator.ValidateRepo(model);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            var repo = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == PublicRepoType,
                CreatedOn = DateTime.UtcNow,
                OwnerId = this.User.Id
            };

            this.dbContext.Repositories.Add(repo);
            this.dbContext.SaveChanges();

            return this.Redirect("/Repositories/All");
        }
    }
}
