﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(250)]
        [DefaultValue("No description")]
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}