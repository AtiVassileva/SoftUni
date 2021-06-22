using System;
using System.Threading.Tasks;
using BattleCards.Data;
using BattleCards.Services;
using BattleCards.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

namespace BattleCards
{
    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IValidator, Validator>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    //.Add<IUserService, UserService>()
                    .Add<BattleCardsDbContext>())
                .WithConfiguration<BattleCardsDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
