using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.DataAccess.Models
{
    public class AspNetRole : IdentityRole
    {
        public AspNetRole()
        {
        }

        public AspNetRole(string roleName) : base(roleName)
        {
        }
    }
}
