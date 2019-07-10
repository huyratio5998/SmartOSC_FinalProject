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
        AspNetRole AddAspNetRole(AspNetRole item,string Role,string Pass);
        AspNetRole DeleteAspNetRole(AspNetRole item);
        bool UpdateAspNetRole(AspNetRole item);
        AspNetRole GetAspNetRole(int ID);
        AspNetRole GetAspNetRole(string ID);
        IEnumerable<AspNetRole> GetAll();        
      //  Task<AspNetRole> addUserAsync(AspNetRole AspNetRole, string Role, string Pass);
    }
}
