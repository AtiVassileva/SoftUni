using MyWebServer.Server;
using System.Threading.Tasks;
using MyWebServer.Controllers;
using MyWebServer.Server.Controllers;

namespace MyWebServer
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                    .MapGet<HomeController>("/", c => c.Index())
                    .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                    .MapGet<HomeController>("/Softuni", c => c.ToSoftUni())
                    .MapGet<AnimalsController>("/Cats", c => c.Cats())
                    .MapGet<AnimalsController>("/Dogs", c => c.Dogs()))
                .Start();
    }
}