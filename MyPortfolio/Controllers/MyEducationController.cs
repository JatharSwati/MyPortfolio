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
                    // Add basic info

                    education.EducationId = Guid.NewGuid();
                    education.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Education.Add(education);
                    db.SaveChanges();
                }
                else
                {
                    // Edit basic info

                    db.Entry(education).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "CreatePortfolio");
            }

            return View(education);
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