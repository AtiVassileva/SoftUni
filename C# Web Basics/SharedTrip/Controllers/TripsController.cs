namespace SharedTrip.Controllers
{
    using System.Globalization;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;
    using System;

    using Data;
    using Models;
    using ViewModels;
    using Services.Contracts;
    using static Data.DataConstants;

    public class TripsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IValidator validator;

        public TripsController(ApplicationDbContext dbContext, IValidator validator)
        {
            this.dbContext = dbContext;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.dbContext.Trips
                .Select(t => new TripListingModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString(DateFormat),
                    Seats = t.Seats
                }).ToList();

            return this.View(trips);
        }

        [Authorize]
        public HttpResponse Add() => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripFormModel model)
        {
            var errors = this.validator.ValidateTrip(model);

            if (errors.Any())
            {
                return this.Redirect("/Trips/Add");
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Description = model.Description,
                ImagePath = model.ImagePath,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, DateFormat, CultureInfo.InvariantCulture),
                Seats = model.Seats
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();

            return this.Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.dbContext.Trips
                .First(t => t.Id == tripId);

            return this.View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.dbContext.Trips
                .First(t => t.Id == tripId);

            var userId = this.User.Id;

            if (this.dbContext.UserTrips.Any(ut => ut.UserId == userId && ut.TripId == trip.Id) || trip.Seats - 1 < 0)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId} ");
            }

            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = trip.Id
            };

            this.dbContext.UserTrips.Add(userTrip);
            this.dbContext.SaveChanges();

            trip.Seats--;
            this.dbContext.SaveChanges();

            return this.Redirect("/Trips/All");
        }
    }
}
