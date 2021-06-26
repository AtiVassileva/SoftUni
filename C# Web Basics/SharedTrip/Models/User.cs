﻿namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System;

    using static Data.DataConstants;

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

        public ICollection<UserTrip> UserTrips { get; set; }
        = new HashSet<UserTrip>();
    }
}
