﻿using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.Models;
using Git.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly GitDbContext dbContext;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(IValidator validator, GitDbContext dbContext, IPasswordHasher passwordHasher)
        {
            this.validator = validator;
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register() => this.View();

        [HttpPost]
        public HttpResponse Register(RegisterUserModel model)
        {
            var errors = this.validator.ValidateUser(model);

            if (this.dbContext.Users.Any(u => u.Username == model.Username))
            {
                errors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.dbContext.Users.Any(u => u.Email == model.Email))
            {
                errors.Add($"User with email '{model.Email}' already exists.");
            }

            if (errors.Any())
            {
                return this.Error(errors);
            }

            var user = new User()
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email,
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login() => this.View();

        [HttpPost]
        public HttpResponse Login(LoginUserModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.dbContext.Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Username and password combination do not match.");
            }

            this.SignIn(userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
