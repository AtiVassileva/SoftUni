namespace CarShop.Services
{
    using System.Linq;
    using Data;
    using Contracts;

    public class UserService : IUserService
    {
        private readonly CarShopDbContext dbContext;

        public UserService(CarShopDbContext dbContext) 
            => this.dbContext = dbContext;

        public bool IsUserMechanic(string userId)
            => this.dbContext.Users
                .Any(u => u.Id == userId && u.IsMechanic);
    }
}
