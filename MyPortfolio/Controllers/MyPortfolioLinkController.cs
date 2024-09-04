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
    public class MyPortfolioLinkController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<PortfolioLink> portfolioLinkList = db.PortfolioLink.Where(m => m.PortfolioUserId == portfolioUserId)
                                                           .OrderBy(m => m.LinkType).ToList();

            return View(portfolioLinkList);
        }

        [HttpGet]
        public ActionResult SavePortfolioLink(Guid? portfolioLinkId)
        {
            PortfolioLink portfolioLink = new PortfolioLink();

            if (portfolioLinkId != null)
            {
                portfolioLink = db.PortfolioLink.Where(m => m.PortfolioLinkId == portfolioLinkId).FirstOrDefault();
            }
            return View(portfolioLink);
        }

        [HttpPost]
        public ActionResult SavePortfolioLink(PortfolioLink portfolioLink)
        {
            if (ModelState.IsValid)
            {
                if (portfolioLink.PortfolioLinkId == Guid.Empty)
                {
                    // Add PortfolioLink

                    portfolioLink.PortfolioLinkId = Guid.NewGuid();
                    portfolioLink.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.PortfolioLink.Add(portfolioLink);
                    db.SaveChanges();
                }
                else
                {
                    // Edit PortfolioLink

                    db.Entry(portfolioLink).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyPortfolioLink");
            }

            return View(portfolioLink);
        }

        public ActionResult DeletePortfolioLink(Guid portfolioLinkId)
        {
            PortfolioLink portfolioLink = db.PortfolioLink.Where(e => e.PortfolioLinkId == portfolioLinkId).FirstOrDefault();

            if (portfolioLink != null)
            {
                db.PortfolioLink.Remove(portfolioLink);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyPortfolioLink");
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