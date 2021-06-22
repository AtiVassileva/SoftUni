using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BattleCards.Models;
using BattleCards.Services.Contracts;
using static BattleCards.Data.DataConstants;

namespace BattleCards.Services
{
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

        public ICollection<string> ValidateCard(CardFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < CardNameMinLength || model.Name.Length > CardNameMaxLength)
            {
                errors.Add($"Name '{model.Name}' is not valid. Should be at least {CardNameMinLength} symbols");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add("Invalid url address.");
            }

            if (model.Description.Length > DescriptionMaxLength )
            {
                errors.Add($"Description cannot be more than {DescriptionMaxLength} symbols.");
            }

            if (model.Attack < AttackAndHealthMinValue)
            {
                errors.Add("Attack cannot be a negative number!");
            }
            
            if (model.Health < AttackAndHealthMinValue)
            {
                errors.Add("Health cannot be a negative number!");
            }

            return errors;

        }
    }
}
