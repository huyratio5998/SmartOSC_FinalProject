using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IRoleService
    {
        IdentityRole AddAspNetRole(IdentityRole item,string Role,string Pass);
        IdentityRole DeleteAspNetRole(IdentityRole item);
        bool UpdateAspNetRole(IdentityRole item);
        IdentityRole GetAspNetRole(int ID);
        IdentityRole GetAspNetRole(string ID);
        IEnumerable<IdentityRole> GetAll();        
      //  Task<AspNetRole> addUserAsync(AspNetRole AspNetRole, string Role, string Pass);
    }
}
