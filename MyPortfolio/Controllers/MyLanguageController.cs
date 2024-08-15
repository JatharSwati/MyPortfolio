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
    public class MyLanguageController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<Language> languageList = db.Language.Where(m => m.PortfolioUserId == portfolioUserId)
                                                           .OrderBy(m => m.Name).ToList();

            return View(languageList);
        }

        [HttpGet]
        public ActionResult SaveLanguage(Guid? languageId)
        {
            Language language = new Language();

            if (languageId != null)
            {
                language = db.Language.Where(m => m.LanguageId == languageId).FirstOrDefault();
            }

            return View(language);
        }

        [HttpPost]
        public ActionResult SaveLanguage(Language language)
        {
            if (ModelState.IsValid)
            {
                if (language.LanguageId == Guid.Empty)
                {
                    // Add Language

                    language.LanguageId = Guid.NewGuid();
                    language.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Language.Add(language);
                    db.SaveChanges();
                }
                else
                {
                    // Edit Language

                    db.Entry(language).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyLanguage");
            }

            return View(language);
        }

        public ActionResult DeleteLanguage(Guid languageId)
        {
            Language language = db.Language.Where(e => e.LanguageId == languageId).FirstOrDefault();

            if (language != null)
            {
                db.Language.Remove(language);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyLanguage");
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