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
    public class MyHobbyController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<Hobby> hobbyList = db.Hobby.Where(m => m.PortfolioUserId == portfolioUserId)
                                                     .OrderBy(m => m.Name).ToList();

            return View(hobbyList);
        }

        [HttpGet]
        public ActionResult SaveHobby(Guid? hobbyId)
        {
            Hobby hobby = new Hobby();

            if (hobbyId != null)
            {
                hobby = db.Hobby.Where(m => m.HobbyId == hobbyId).FirstOrDefault();
            }

            return View(hobby);
        }

        [HttpPost]
        public ActionResult SaveHobby(Hobby hobby)
        {
            if (ModelState.IsValid)
            {
                if (hobby.HobbyId == Guid.Empty)
                {
                    // Add Hobby

                    hobby.HobbyId = Guid.NewGuid();
                    hobby.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Hobby.Add(hobby);
                    db.SaveChanges();
                }
                else
                {
                    // Edit Hobby

                    db.Entry(hobby).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyHobby");
            }

            return View(hobby);
        }

        public ActionResult DeleteHobby(Guid hobbyId)
        {
            Hobby hobby = db.Hobby.Where(e => e.HobbyId == hobbyId).FirstOrDefault();

            if (hobby != null)
            {
                db.Hobby.Remove(hobby);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyHobby");
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