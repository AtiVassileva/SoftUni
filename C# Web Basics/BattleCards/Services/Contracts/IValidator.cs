using System.Collections.Generic;
using BattleCards.Models;

namespace BattleCards.Services.Contracts
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserModel model);

        ICollection<string> ValidateCard(CardFormModel model);
    }
}
