using MyWebServer.Server.Http;
using MyWebServer.Server.Http.Enums;

namespace MyWebServer.Server.Responses
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse() 
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}
