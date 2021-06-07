using MyWebServer.Server.Http;
using MyWebServer.Server.Http.Enums;

namespace MyWebServer.Server.Responses
{
    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse() 
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}
