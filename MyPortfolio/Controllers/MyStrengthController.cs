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
    public class MyStrengthController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<Strength> strengthList = db.Strength.Where(m => m.PortfolioUserId == portfolioUserId)
                                                     .OrderBy(m => m.Name).ToList();

            return View(strengthList);
        }

        [HttpGet]
        public ActionResult SaveStrength(Guid? strengthId)
        {
            Strength strength = new Strength();

            if (strengthId != null)
            {
                strength = db.Strength.Where(m => m.StrengthId == strengthId).FirstOrDefault();
            }

            return View(strength);
        }

        [HttpPost]
        public ActionResult SaveStrength(Strength strength)
        {
            if (ModelState.IsValid)
            {
                if (strength.StrengthId == Guid.Empty)
                {
                    // Add Strength

                    strength.StrengthId = Guid.NewGuid();
                    strength.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Strength.Add(strength);
                    db.SaveChanges();
                }
                else
                {
                    // Edit Strength

                    db.Entry(strength).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyStrength");
            }

            return View(strength);
        }

        public ActionResult DeleteStrength(Guid strengthId)
        {
            Strength strength = db.Strength.Where(e => e.StrengthId == strengthId).FirstOrDefault();

            if (strength != null)
            {
                db.Strength.Remove(strength);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyStrength");
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