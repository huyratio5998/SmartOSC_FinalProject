using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    
    public interface IAspNetRolesService
    {
        IdentityRole AddStatus(IdentityRole item);
        IdentityRole DeleteStatus(IdentityRole item);
        bool UpdateStatus(IdentityRole item);
        IdentityRole GetStatus(int ID);
        IEnumerable<IdentityRole> GetAll();
        void SaveChange();
    }
}
