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
    public class MyEducationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<Education> educationList = db.Education.Where(m => m.PortfolioUserId == portfolioUserId)
                                                        .OrderBy(m => m.StartYear).ToList();

            return View(educationList);
        }


        [HttpGet]
        public ActionResult SaveEducation(Guid? educationId)
        {
            Education education = new Education();

            if(educationId != null)
            {
                education = db.Education.Where(m => m.EducationId == educationId).FirstOrDefault();
            }
            return View(education);
        }

        [HttpPost]
        public ActionResult SaveEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                if (education.EducationId == Guid.Empty)
                {
                    // Add Education

                    education.EducationId = Guid.NewGuid();
                    education.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Education.Add(education);
                    db.SaveChanges();
                }
                else
                {
                    // Edit Education

                    db.Entry(education).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyEducation");
            }

            return View(education);
        }

        public ActionResult DeleteEducation(Guid educationId)
        {
            Education education = db.Education.Where(e => e.EducationId == educationId).FirstOrDefault();

            if (education != null)
            {
                db.Education.Remove(education);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyEducation");
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