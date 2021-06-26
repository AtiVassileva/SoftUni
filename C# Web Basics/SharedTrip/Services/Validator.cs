namespace SharedTrip.Services
{
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Globalization;
    using System;

    using static Data.DataConstants;
    using Contracts;
    using ViewModels;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength ||
                model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Invalid username. Should be between {UsernameMinLength} and {DefaultMaxLength} symbols.");
            }

            if (!Regex.IsMatch(model.Email, ValidEmailRegex))
            {
                errors.Add($"Email '{model.Email}' is not a valid email address.");
            }

            if (model.Password.Length < PasswordMinLength ||
                model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Invalid password. Should be between {PasswordMinLength} and {DefaultMaxLength} symbols.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and confirmed password do not match.");
            }

            return errors;
        }

        public ICollection<string> ValidateTrip(TripFormModel model)
        {
            var errors = new List<string>();

            if (!DateTime.TryParseExact(model.DepartureTime, DateFormat, null,
                DateTimeStyles.None, out _))
            {
                errors.Add("Invalid date format! Should be 'dd.MM.yyyy HH:mm'");
            }

            if (model.Seats < MinimumSeats || model.Seats > MaximumSeats)
            {
                errors.Add($"Seats should be between {MinimumSeats} and {MaximumSeats}!");
            }

            if (model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description cannot contain more than {DescriptionMaxLength} symbols.");
            }

            if (!string.IsNullOrWhiteSpace(model.ImagePath) &&
                !Uri.IsWellFormedUriString(model.ImagePath, UriKind.Absolute))
            {
                errors.Add("Invalid URL Address!");
            }

            return errors;
        }
    }
}
