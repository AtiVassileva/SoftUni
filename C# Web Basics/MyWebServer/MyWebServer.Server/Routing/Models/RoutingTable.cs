using System;
using System.Collections.Generic;
using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using MyWebServer.Server.Http.Enums;
using MyWebServer.Server.Responses;
using MyWebServer.Server.Routing.Contracts;

namespace MyWebServer.Server.Routing.Models
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable()
            => this.routes = new()
            {
                [HttpMethod.Get] = new(),
                [HttpMethod.Post] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Delete] = new(),
            };


        public IRoutingTable Map
            (HttpMethod method, string path, HttpResponse response)
        {
            Guard.AgainstNull(response, nameof(response));

            return this.Map(method, path, request => response);
        }

        public IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path.ToLower()] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response) => this.MapGet(path, request => response);

        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => this.Map(HttpMethod.Get, path, responseFunction);

        public IRoutingTable MapPost(string path, HttpResponse response)
            => this.MapPost(path, request => response);

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => this.Map(HttpMethod.Post, path, responseFunction);

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod) ||
                !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestPath];

            return responseFunction(request);
        }
    }
}