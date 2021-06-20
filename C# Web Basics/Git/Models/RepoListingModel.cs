using System;

namespace Git.Models
{
    public class RepoListingModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string CreatedOn { get; set; }

        public int CommitsCount { get; set; }
    }
}
