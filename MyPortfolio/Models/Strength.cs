using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Strength
    {
        public Guid StrengthId { get; set; }

        public Guid PortfolioUserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}