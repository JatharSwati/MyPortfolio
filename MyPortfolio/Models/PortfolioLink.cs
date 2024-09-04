using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class PortfolioLink
    {
        public Guid PortfolioLinkId { get; set; }

        public Guid PortfolioUserId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Link Type")]
        public string LinkType { get; set; }

        [Required]
        [StringLength(100)]
        [Url]
        public string Link { get; set; }
    }
}