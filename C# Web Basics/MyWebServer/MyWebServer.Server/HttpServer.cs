using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using MyWebServer.Server.Routing.Contracts;
using MyWebServer.Server.Routing.Models;

namespace MyWebServer.Server
{
    public class HttpServer
    {
        private const string DefaultIpAddress = "127.0.0.1";
        private const int DefaultPort = 9090;

        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener tcpListener;

        private readonly RoutingTable routingTable;
        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfig)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.tcpListener = new TcpListener(this.ipAddress, this.port);

            routingTableConfig(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
        : this(DefaultIpAddress, port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
        : this(DefaultIpAddress, DefaultPort, routingTable)
        {
        }

        public async Task Start()
        {
            this.tcpListener.Start();

            Console.WriteLine($"Server started on port {this.port}");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await this.tcpListener
                    .AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                var requestText = await this.ReadRequest(networkStream);

                var request = HttpRequest.Parse(requestText);

                var response = this.routingTable.ExecuteRequest(request);

                await WriteResponse(networkStream, response);

                connection.Close();
            }
        }
        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();
            var totalBytes = 0;

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * bufferLength)
                {
                    throw new InvalidOperationException(GlobalConstants.TooLargeRequestExceptionMessage);
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bufferLength));
            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream, HttpResponse response)
        {
            var responseBytes = Encoding.UTF8
                .GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
        }
    }
}