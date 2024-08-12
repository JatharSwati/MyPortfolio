using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.ViewModels
{
    public class CreatePortfolioViewModel
    {
        public Guid BasicInfoId { get; set; }

        public int EducationCount { get; set; }

        public void Init(ApplicationDbContext db, Guid portfolioUserId)
        {
            this.BasicInfoId = db.BasicInfo.Where(m => m.PortfolioUserId == portfolioUserId).Select(m => m.BasicInfoId).FirstOrDefault();

            this.EducationCount = db.Education.Where(m => m.PortfolioUserId == portfolioUserId).Count();
        }
    }
}