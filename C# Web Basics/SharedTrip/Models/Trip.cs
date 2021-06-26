namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System;
    
    using static Data.DataConstants;

    public class Trip
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; set; }
        
        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        [Range(MinimumSeats, MaximumSeats)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
        = new HashSet<UserTrip>();
    }
}
