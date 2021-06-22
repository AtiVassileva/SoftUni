using System.Linq;
using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models;
using BattleCards.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly BattleCardsDbContext dbContext;
        private readonly IValidator validator;

        public CardsController(BattleCardsDbContext dbContext, IValidator validator)
        {
            this.dbContext = dbContext;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var cards = this.dbContext.Cards
                .Select(c => new CardListingModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                    Attack = c.Attack,
                    Health = c.Health,
                    Description = c.Description,
                    Keyword = c.Keyword
                }).ToList();

            return this.View(cards);
        }

        [Authorize]
        public HttpResponse Add() => this.View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(CardFormModel model)
        {
            var errors = this.validator.ValidateCard(model);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            var user = this.dbContext.Users
                .First(u => u.Id == this.User.Id);

            var card = new Card
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
                Description = model.Description,
                Attack = model.Attack,
                Health = model.Health
            };

            this.dbContext.Cards.Add(card);
            this.dbContext.SaveChanges();

            this.dbContext.UsersCards.Add(new UserCard
            {
                UserId = user.Id,
                CardId = card.Id
            });

            this.dbContext.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var collection = this.dbContext.UsersCards
                .Where(uc => uc.UserId == this.User.Id)
                .Select(c => c.Card)
                .Select(c => new CardListingModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Keyword = c.Keyword,
                    Description = c.Description,
                    Attack = c.Attack,
                    Health = c.Health,
                    ImageUrl = c.ImageUrl
                }).ToList();

            return this.View(collection);
       }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            if (this.dbContext.UsersCards.Any(us => us.CardId == cardId && us.UserId == this.User.Id))
            {
                return this.Redirect("/Cards/All");
            }

            this.dbContext.UsersCards.Add(new UserCard
            {
                UserId = this.User.Id,
                CardId = cardId
            });

            this.dbContext.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            var userCard = this.dbContext.UsersCards
                .First(uc => uc.UserId == this.User.Id && uc.CardId == cardId);

            this.dbContext.UsersCards.Remove(userCard);

            this.dbContext.SaveChanges();

            return this.Redirect("/Cards/Collection");
        }
    }
}
