using MyPortfolio.CommonFiles;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MyExperienceController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<Experience> experienceList = db.Experience.Where(m => m.PortfolioUserId == portfolioUserId)
                                                           .OrderBy(m => m.JoiningDate).ToList();

            return View(experienceList);
        }

        [HttpGet]
        public ActionResult SaveExperience(Guid? experienceId)
        {
            Experience experience = new Experience();

            if (experienceId != null)
            {
                experience = db.Experience.Where(m => m.ExperienceId == experienceId).FirstOrDefault();
            }
            return View(experience);
        }

        [HttpPost]
        public ActionResult SaveExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                if (experience.ExperienceId == Guid.Empty)
                {
                    // Add basic info

                    experience.ExperienceId = Guid.NewGuid();
                    experience.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Experience.Add(experience);
                    db.SaveChanges();
                }
                else
                {
                    // Edit basic info

                    db.Entry(experience).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyExperience");
            }

            return View(experience);
        }

        public ActionResult DeleteExperience(Guid experienceId)
        {
            Experience experience = db.Experience.Where(e => e.ExperienceId == experienceId).FirstOrDefault();

            if (experience != null)
            {
                db.Experience.Remove(experience);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyExperience");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}