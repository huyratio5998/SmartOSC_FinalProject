using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IUserService 
    {
        AspNetUser AddAspNetUser(AspNetUser item,string Role,string Pass);
        AspNetUser DeleteAspNetUser(AspNetUser item);
        bool UpdateAspNetUser(AspNetUser item);
        AspNetUser GetAspNetUser(int ID);
        AspNetUser GetAspNetUser(string ID);
        IEnumerable<AspNetUser> GetAll();        
      //  Task<AspNetUser> addUserAsync(AspNetUser aspNetUser, string Role, string Pass);
    }
}
