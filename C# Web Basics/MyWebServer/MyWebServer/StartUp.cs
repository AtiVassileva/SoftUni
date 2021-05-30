namespace MyWebServer
{
    using Server;
    using System.Threading.Tasks;
    public class StartUp
    {
        public static async Task Main()
        {
            var ipAddress = "127.0.0.1";
            var port = 2511;

            var httpServer = new HttpServer(ipAddress, port);
            await httpServer.Start();
        }
    }
}