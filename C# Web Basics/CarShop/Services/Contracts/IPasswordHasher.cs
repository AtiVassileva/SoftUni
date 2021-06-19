namespace CarShop.Services.Contracts
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
