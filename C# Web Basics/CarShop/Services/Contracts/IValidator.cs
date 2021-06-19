namespace CarShop.Services.Contracts
{
    using System.Collections.Generic;
    using Models;
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserModel model);

        ICollection<string> ValidateCar(CarFormModel model);

        ICollection<string> ValidateIssue(IssueFormModel model);
    }
}
