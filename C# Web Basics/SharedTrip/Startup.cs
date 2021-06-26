namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    using MyWebServer.Results.Views;
    using MyWebServer.Controllers;
    using MyWebServer;

    using Services.Contracts;
    using Services;
    using Data;

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
                    .Add<ApplicationDbContext>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
