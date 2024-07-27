using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class BasicInfo
    {
        public Guid BasicInfoId { get; set; }

        public Guid PortfolioUserId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Designation { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Profile { get; set; }

    }
}