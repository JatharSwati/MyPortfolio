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
    [Authorize]
    public class MyBasicInfoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyBasicInfo

        [HttpGet]
        public ActionResult SaveBasicInfo(Guid? basicInfoId)
        {
            BasicInfo basicInfo = new BasicInfo();

            if (basicInfoId != null)
            {
                basicInfo = db.BasicInfo.Where(m => m.BasicInfoId == basicInfoId).FirstOrDefault();
            }

            return View(basicInfo);
        }


        [HttpPost]
        public ActionResult SaveBasicInfo(BasicInfo basicInfo)
        {
            if (ModelState.IsValid)
            {
                if (basicInfo.BasicInfoId == Guid.Empty)
                {
                    // Add basic info

                    basicInfo.BasicInfoId = Guid.NewGuid();
                    basicInfo.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.BasicInfo.Add(basicInfo);
                    db.SaveChanges();
                }
                else
                {
                    // Edit basic info

                    db.Entry(basicInfo).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "CreatePortfolio");
            }

            return View(basicInfo);
        }


        public ActionResult DeleteBasicInfo(Guid basicInfoId)
        {
            BasicInfo basicInfo = db.BasicInfo.Where(e => e.BasicInfoId == basicInfoId).FirstOrDefault();

            if(basicInfo != null)
            {
                db.BasicInfo.Remove(basicInfo);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "CreatePortfolio");
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