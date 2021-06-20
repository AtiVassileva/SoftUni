using System.Collections.Generic;
using Git.Models;

namespace Git.Services.Contracts
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserModel model);

        ICollection<string> ValidateRepo(RepoFormModel model);

        ICollection<string> ValidateCommit(CommitFormModel model);
    }
}
