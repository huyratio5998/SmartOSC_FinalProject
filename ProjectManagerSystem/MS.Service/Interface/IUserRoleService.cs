using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MS.Service.Interface
{
    public interface IUserRoleService
    {
        IdentityUserRole AddAspNetUserRole(IdentityUserRole item);
        IdentityUserRole DeleteAspNetUserRole(IdentityUserRole item);
        bool UpdateAspNetUserRole(IdentityUserRole item);
        IdentityUserRole GetAspNetUserRole(int ID);
        IdentityUserRole GetAspNetUserRole(string ID);
        IEnumerable<IdentityUserRole> GetAll();
        void SaveChange();
    }
}
