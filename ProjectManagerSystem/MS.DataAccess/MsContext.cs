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
        public MsContext() : base("ManageProjectDB")
        {
        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public static MsContext Create()
        {
            return new MsContext();
        }
    }
}
