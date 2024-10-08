﻿using MyPortfolio.Models;
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

        public int ExperienceCount { get; set; }

        public int CoursesCount { get; set; }

        public int SkillCount { get; set; }

        public int LanguageCount { get; set; }

        public int StrengthCount { get; set; }

        public int HobbyCount { get; set; }

        public int PortfolioLinkCount { get; set; }

        public Guid ProfileImageId { get; set; }

        public void Init(ApplicationDbContext db, Guid portfolioUserId)
        {
            this.BasicInfoId = db.BasicInfo.Where(m => m.PortfolioUserId == portfolioUserId).Select(m => m.BasicInfoId).FirstOrDefault();

            this.EducationCount = db.Education.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.ExperienceCount = db.Experience.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.CoursesCount = db.Courses.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.SkillCount = db.Skill.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.LanguageCount = db.Language.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.StrengthCount = db.Strength.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.HobbyCount = db.Hobby.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.PortfolioLinkCount = db.PortfolioLink.Where(m => m.PortfolioUserId == portfolioUserId).Count();

            this.ProfileImageId = db.ProfileImage.Where(m => m.PortfolioUserId == portfolioUserId).Select(m => m.ProfileImageId).FirstOrDefault();
        }
    }
}