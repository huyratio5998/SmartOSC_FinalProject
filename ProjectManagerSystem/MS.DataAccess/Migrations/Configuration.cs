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
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }
            //
            //Thêm PM
            if (!context.Roles.Any(p => p.Name == "ProjectManager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "ProjectManager" };
                manager.Create(role);
            }
            //
            // Them User
            if (!context.Roles.Any(p => p.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };
                manager.Create(role);
            }
            //
            //Tạo account và Thêm quyền cho account đó.
            if (!context.Users.Any(p => p.UserName == "Admin"))
            {
                var store = new UserStore<AspNetUser>(context);
                var manager = new UserManager<AspNetUser>(store);
                var user = new AspNetUser { UserName = "Admin", FullName = "Administrator" };
                manager.Create(user, "!Admin");
                manager.AddToRole(user.Id, "Admin");
            }

            //Thêm quyền cho account đó.
            if (!context.Users.Any(p => p.UserName == "PM"))
            {
                var store = new UserStore<AspNetUser>(context);
                var manager = new UserManager<AspNetUser>(store);
                var user = new AspNetUser { UserName = "PM", FullName = "Project Manager" };
                manager.Create(user, "!ProjectManager");
                manager.AddToRole(user.Id, "ProjectManager");
            }

            //Thêm quyền cho account đó.
            if (!context.Users.Any(p => p.UserName == "User"))
            {
                var store = new UserStore<AspNetUser>(context);
                var manager = new UserManager<AspNetUser>(store);
                var user = new AspNetUser { UserName = "User", FullName = "Nomal User" };
                manager.Create(user, "!NomalUser");
                manager.AddToRole(user.Id, "User");
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
