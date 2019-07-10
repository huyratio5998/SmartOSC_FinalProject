using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IPermissionService
    {
        Permission AddPermission(Permission item,string Role,string Pass);
        Permission DeletePermission(Permission item);
        bool UpdatePermission(Permission item);
        Permission GetPermission(int ID);
        Permission GetPermission(string ID);
        IEnumerable<Permission> GetAll();        
      //  Task<Permission> addUserAsync(Permission Permission, string Role, string Pass);
    }
}
