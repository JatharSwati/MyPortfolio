using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyPortfolio.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IdentityConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database initializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Remove default pluralization
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public DbSet<PortfolioUser> PortfolioUser { get; set; }

        public DbSet<BasicInfo> BasicInfo { get; set; }

        public DbSet<Education> Education { get; set; }

        public DbSet<Experience> Experience { get; set; }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<Skill> Skill { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<Strength> Strength { get; set; }

        public DbSet<Hobby> Hobby { get; set; }

        public DbSet<PortfolioLink> PortfolioLink { get; set; }
    }
}