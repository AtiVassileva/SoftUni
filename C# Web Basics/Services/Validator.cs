using System.Collections.Generic;
using System.Text.RegularExpressions;
using Git.Data;
using Git.Models;
using Git.Services.Contracts;

namespace Git.Services
{
    using static DataConstants;
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

        public ICollection<string> ValidateRepo(RepoFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < RepoNameMinLength || model.Name.Length > RepoNameMaxLength)
            {
                errors.Add($"Repository name's length should be between {RepoNameMinLength} and {RepoNameMaxLength} symbols");
            }

            if (model.RepositoryType != PublicRepoType && model.RepositoryType != PrivateRepoType)
            {
                errors.Add($"Invalid repository type. Should be {PublicRepoType} or {PrivateRepoType}.");
            }

            return errors;
        }

        public ICollection<string> ValidateCommit(CommitFormModel model)
        {
            var errors = new List<string>();

            if (model.Description.Length < CommitDescriptionMinLength)
            {
                errors.Add($"Commit's description should be at least {CommitDescriptionMinLength} symbols long.");
            }

            return errors;
        }
    }
}
