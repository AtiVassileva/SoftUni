using System.Collections.Generic;

namespace CarShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        [Required]
        [MaxLength(DataConstants.IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        [Required] 
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; } 
            = new HashSet<Issue>();
    }
}