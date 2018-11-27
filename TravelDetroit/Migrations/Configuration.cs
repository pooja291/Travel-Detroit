namespace TravelDetroit.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TravelDetroit.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TravelDetroit.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TravelDetroit.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Users.Any(x => x.UserName == "tuser@example.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "tuser@example.com", Email = "tuser@example.com" };

                manager.Create(user, "Password123@");

                var userProfile = new UserProfile();
                userProfile.Name = "Test User";
                userProfile.ApplicationUser = user;

                context.UserProfiles.Add(userProfile);
                context.SaveChanges();
            }
        }
    }
}
