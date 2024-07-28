using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Education
    {
        public Guid EducationId { get; set; }

        public Guid PortfolioUserId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Education Name")]
        public string EducationName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "School/College Name")]
        public string CollegeName { get; set; }

        [Range(0.1, 100)]
        [Display(Name = "Percentage/CGPA")]
        public double? PercentageOrCGPA { get; set; }

        [Required]
        [Range(1900, 2100)]
        [Display(Name = "Start Year")]
        public int? StartYear { get; set; }

        [Range(1900, 2100)]
        [Display(Name = "Passing Year")]
        public int? PassingYear { get; set; }
    }
}