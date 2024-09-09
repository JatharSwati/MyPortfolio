using MyPortfolio.Models;
using MyPortfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult GetPortfolio(string id)
        {
            PortfolioViewModel model = new PortfolioViewModel();
            model.Init(db, id);

            if (model.PortfolioUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
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