using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.Models
{
    public class PermissionViewModel
    {
        public int Id { get; set; }                

        public bool CanCreate { set; get; }

        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }

        public bool CanDelete { set; get; }

        public IdentityRole IdentityRole { get; set; }

        public FunctionViewModel Function { get; set; }
    }
}