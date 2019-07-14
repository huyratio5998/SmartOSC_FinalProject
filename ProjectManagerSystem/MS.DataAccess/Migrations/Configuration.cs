namespace MS.DataAccess.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MS.DataAccess.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MS.DataAccess.MsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MS.DataAccess.MsContext context)
        {
            //  This method will be called after migrating to the latest version.
            // Huyratio
            // Thêm quyền
            if (!context.Roles.Any(p => p.Name == "Admin"))
            {
                var store = new RoleStore<AspNetRole>(context);
                var manager = new RoleManager<AspNetRole>(store);
                var role = new AspNetRole { Name = "Admin" };
                manager.Create(role);
            }
            //
          
            //Tạo account và Thêm quyền cho account đó.
            if (!context.Users.Any(p => p.UserName == "Admin"))
            {
                var store = new UserStore<AspNetUser>(context);
                var manager = new UserManager<AspNetUser>(store);
                var user = new AspNetUser {
                    UserName = "Admin",
                    FullName = "Administrator",
                    Email="admin@gmail.com"
                };
                manager.Create(user, "!Admin1");
                manager.AddToRole(user.Id, "Admin");
            }

           
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
