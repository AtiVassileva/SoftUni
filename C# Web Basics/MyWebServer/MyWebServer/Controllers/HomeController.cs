using MyWebServer.Server.Controllers;
using MyWebServer.Server.Http;

namespace MyWebServer.Controllers
{
    public class HomeController : Controller
    {
        private const string HelloMessage = "Hello from the server!";
        public HomeController(HttpRequest request) : base(request)
        {
        }

        public HttpResponse Index() => this.Text(HelloMessage);

        public HttpResponse LocalRedirect() => this.Redirect("/Cats");

        public HttpResponse ToSoftUni() 
            => this.Redirect("https://softuni.bg");
    }
}
