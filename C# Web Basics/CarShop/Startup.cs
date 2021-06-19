using System.Threading.Tasks;
using CarShop.Data;
using CarShop.Services;
using CarShop.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

namespace CarShop
{
    public class Startup
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
                    .Add<IUserService, UserService>()
                    .Add<CarShopDbContext>())
                .WithConfiguration<CarShopDbContext>(context => context
                .Database.Migrate())
                .Start();
    }
}
