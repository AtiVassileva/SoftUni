using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace MyWebServer.Server.Controllers
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
            => this.Request = request;

        public HttpRequest Request { get; private init; }

        protected HttpResponse Text(string text)
            => new TextResponse(text);

        protected HttpResponse Html(string html)
            => new HtmlResponse(html);

        protected HttpResponse Redirect(string location)
            => new RedirectResponse(location);
    }
}
