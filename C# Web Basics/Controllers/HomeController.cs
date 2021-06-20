﻿using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }
    }
}
