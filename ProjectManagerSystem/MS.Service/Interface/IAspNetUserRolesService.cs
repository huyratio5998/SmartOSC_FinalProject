using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    
    public interface IAspNetUserRolesService
    {
        IdentityUserRole AddStatus(IdentityUserRole item);
        IdentityUserRole DeleteStatus(IdentityUserRole item);
        bool UpdateStatus(IdentityUserRole item);
        IdentityUserRole GetStatus(int ID);
        IEnumerable<IdentityUserRole> GetAll();
        void SaveChange();
    }
}
