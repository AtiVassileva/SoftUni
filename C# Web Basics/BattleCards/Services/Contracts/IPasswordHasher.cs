namespace BattleCards.Services.Contracts
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
