using System;
using System.Collections.Generic;

namespace Git.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class User
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Repository> Repositories { get; set; } 
        = new HashSet<Repository>();

        public ICollection<Commit> Commits { get; set; }
        = new HashSet<Commit>();
    }
}
