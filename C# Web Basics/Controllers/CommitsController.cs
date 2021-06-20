using System;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.Models;
using Git.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly GitDbContext dbContext;
        private readonly IValidator validator;

        public CommitsController(GitDbContext dbContext, IValidator validator)
        {
            this.dbContext = dbContext;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.dbContext.Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new CommitListingModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("D"),
                    RepoName = c.Repository.Name
                }).ToList();

            return this.View(commits);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repo = this.dbContext.Repositories
                .FirstOrDefault(r => r.Id == id);

            if (repo == null)
            {
                return this.Error($"Repository with Id: {id} does not exist.");
            }

            return this.View(repo);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(string id, CommitFormModel model)
        {
            var errors = this.validator.ValidateCommit(model);

            var repo = this.dbContext.Repositories
                .FirstOrDefault(r => r.Id == id);

            if (repo == null)
            {
                errors.Add($"Repository with Id: {id} does not exist.");
            }

            if (errors.Any())
            {
                return this.Error(errors);
            }

            var commit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = this.User.Id,
                RepositoryId = id
            };

            this.dbContext.Commits.Add(commit);
            this.dbContext.SaveChanges();

            return this.Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.dbContext.Commits
                .FirstOrDefault(c => c.Id == id);

            if (commit == null)
            {
                return this.Error($"Commit with Id: {id} does not exist.");
            }

            this.dbContext.Commits.Remove(commit);
            this.dbContext.SaveChanges();

            return this.Redirect("/Commits/All");
        }
    }
}