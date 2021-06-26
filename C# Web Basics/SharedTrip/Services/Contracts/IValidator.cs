namespace SharedTrip.Services.Contracts
{
    using System.Collections.Generic;
    using ViewModels;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserModel model);

        ICollection<string> ValidateTrip(TripFormModel model);
    }
}
