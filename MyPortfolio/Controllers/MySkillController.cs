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
    public class MySkillController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<Skill> skillList = db.Skill.Where(m => m.PortfolioUserId == portfolioUserId)
                                                           .OrderBy(m => m.Name).ToList();

            return View(skillList);
        }

        [HttpGet]
        public ActionResult SaveSkill(Guid? skillId)
        {
            Skill skill = new Skill();

            if (skillId != null)
            {
                skill = db.Skill.Where(m => m.SkillId == skillId).FirstOrDefault();
            }

            return View(skill);
        }

        [HttpPost]
        public ActionResult SaveSkill(Skill skill)
        {
            if (ModelState.IsValid)
            {
                if (skill.SkillId == Guid.Empty)
                {
                    // Add Skill

                    skill.SkillId = Guid.NewGuid();
                    skill.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Skill.Add(skill);
                    db.SaveChanges();
                }
                else
                {
                    // Edit Skill

                    db.Entry(skill).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MySkill");
            }

            return View(skill);
        }

        public ActionResult DeleteSkill(Guid skillId)
        {
            Skill skill = db.Skill.Where(e => e.SkillId == skillId).FirstOrDefault();

            if (skill != null)
            {
                db.Skill.Remove(skill);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MySkill");
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