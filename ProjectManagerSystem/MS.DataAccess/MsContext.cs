using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.DataAccess
{  
        public class MsContext : IdentityDbContext
        {
        // 1. Enable-Migrations
        // 2. Add-Migration
        // 3. Update-Database
        public MsContext() : base("ManageProjectDB")
        {
        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public static MsContext Create()
        {
            return new MsContext();
        }
       
    }
}
