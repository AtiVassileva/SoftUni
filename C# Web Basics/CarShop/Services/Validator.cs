using System;
using System.Collections.Generic;
using CarShop.Models;
using CarShop.Services.Contracts;
using static CarShop.Data.DataConstants;
using System.Text.RegularExpressions;

namespace CarShop.Services
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

            if (model.UserType != Client && model.UserType != Mechanic)
            {
                errors.Add($"Invalid user type. Please choose between '{Client}' and {Mechanic} type.");
            }

            return errors;
        }

        public ICollection<string> ValidateCar(CarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < ModelMinLength || model.Model.Length > DefaultMaxLength)
            {
                errors.Add($"Model '{model.Model}' is not valid. Should be at least 5 symbols");
            }

            if (model.Year < CarYearMinValue || model.Year > CarYearMaxValue)
            {
                errors.Add($"Invalid year. Should be between {CarYearMinValue} and {CarYearMaxValue}.");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add("Invalid url address.");
            }

            if (!Regex.IsMatch(model.PlateNumber, CarPlateNumberRegex))
            {
                errors.Add($"Invalid plate number. Should be in format: CA1111CA");
            }
            return errors;
        }

        public ICollection<string> ValidateIssue(IssueFormModel model)
        {
            var errors = new List<string>();

            if (model.Description.Length < IssueDescriptionMinLength)
            {
                errors.Add($"Issue's description should contain at least {IssueDescriptionMinLength} symbols.");
            }

            return errors;
        }
    }
}
