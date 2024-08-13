using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Experience
    {
        public Guid ExperienceId { get; set; }

        public Guid PortfolioUserId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Experience Type")]
        public string ExperienceType { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Required]
        [Display(Name = "Joining Date")]
        public DateTime? JoiningDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Skills { get; set; }
    }
}