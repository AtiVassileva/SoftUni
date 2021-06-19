using System.Collections.Generic;

namespace CarShop.Models
{
    public class CarIssueModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public ICollection<IssueListingViewModel> Issues { get; set; }
        = new List<IssueListingViewModel>();
    }
}
