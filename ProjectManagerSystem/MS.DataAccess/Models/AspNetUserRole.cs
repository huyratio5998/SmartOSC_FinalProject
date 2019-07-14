using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.DataAccess.Models
{
    public class AspNetUserRole: IdentityUserRole
    {
        public AspNetUserRole()
        {
        }
        public AspNetUserRole(string userId,string roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

    }
}
