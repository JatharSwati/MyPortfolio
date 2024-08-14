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
    public class MyCoursesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Guid portfolioUserId = Helpers.GetPortfolioUserId(User);

            List<Courses> coursesList = db.Courses.Where(m => m.PortfolioUserId == portfolioUserId)
                                                           .OrderBy(m => m.StartDate).ToList();

            return View(coursesList);
        }

        public ActionResult SaveCourses(Guid? coursesId)
        {
            Courses courses = new Courses();

            if (coursesId != null)
            {
                courses = db.Courses.Where(m => m.CoursesId == coursesId).FirstOrDefault();
            }

            return View(courses);
        }

        [HttpPost]
        public ActionResult SaveCourses(Courses courses)
        {
            if (ModelState.IsValid)
            {
                if (courses.CoursesId == Guid.Empty)
                {
                    // Add Courses

                    courses.CoursesId = Guid.NewGuid();
                    courses.PortfolioUserId = Helpers.GetPortfolioUserId(User);

                    db.Courses.Add(courses);
                    db.SaveChanges();
                }
                else
                {
                    // Edit Courses

                    db.Entry(courses).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "MyCourses");
            }

            return View(courses);
        }

        public ActionResult DeleteCourses(Guid coursesId)
        {
            Courses courses = db.Courses.Where(e => e.CoursesId == coursesId).FirstOrDefault();

            if (courses != null)
            {
                db.Courses.Remove(courses);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "MyCourses");
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