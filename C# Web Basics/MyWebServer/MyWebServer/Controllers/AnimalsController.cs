using MyWebServer.Server.Controllers;
using MyWebServer.Server.Http;

namespace MyWebServer.Controllers
{
    public class AnimalsController : Controller
    {
        public AnimalsController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey)
                ? query[nameKey]
                : "the cats";

            var html = $"<h1>Hello from {catName}!</h1>";

            return this.Html(html);
        }

        public HttpResponse Dogs() 
            => this.Html("<h1>Hello from the dogs!</h1>");
    }
}