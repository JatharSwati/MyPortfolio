using Microsoft.AspNet.Identity;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MyPortfolio.CommonFiles
{
    public class Helpers
    {
        public static Guid GetPortfolioUserId(IPrincipal user)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Guid userId = new Guid(user.Identity.GetUserId());

                PortfolioUser portfolioUser = db.PortfolioUser.Where(m => m.UserId == userId).FirstOrDefault();

                return portfolioUser.PortfolioUserId;
            }
        }
    }
}