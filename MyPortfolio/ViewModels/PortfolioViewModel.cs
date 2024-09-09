using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.ViewModels
{
    public class PortfolioViewModel
    {
        public PortfolioUser PortfolioUser { get; set; }

        public BasicInfo BasicInfo { get; set; }

        public List<Education> EducationList { get; set; }

        public List<Experience> ExperienceList { get; set; }

        public List<Courses> CoursesList { get; set; }

        public List<Skill> SkillList { get; set; }

        public List<Language> LanguageList { get; set; }

        public List<Strength> StrengthList { get; set; }

        public List<Hobby> HobbyList { get; set; }

        public List<PortfolioLink> PortfolioLinkList { get; set; }


        public void Init(ApplicationDbContext db, string id)
        {
            this.PortfolioUser = db.PortfolioUser.Where(m => m.UserName == id).FirstOrDefault();

            if (this.PortfolioUser != null)
            {
                {
                    this.BasicInfo = db.BasicInfo.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).FirstOrDefault();

                    this.EducationList = db.Education.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).OrderBy(m => m.StartYear).ToList();

                    this.ExperienceList = db.Experience.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).OrderBy(m => m.JoiningDate).ToList();

                    this.CoursesList = db.Courses.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).OrderBy(m => m.StartDate).ToList();

                    this.SkillList = db.Skill.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).OrderBy(m => m.Name).ToList();

                    this.LanguageList = db.Language.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).OrderBy(m => m.Name).ToList();

                    this.StrengthList = db.Strength.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).OrderBy(m => m.Name).ToList();

                    this.HobbyList = db.Hobby.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).OrderBy(m => m.Name).ToList();

                    this.PortfolioLinkList = db.PortfolioLink.Where(m => m.PortfolioUserId == this.PortfolioUser.PortfolioUserId).OrderBy(m => m.LinkType).ToList();
                }
            }
        }

    }
}