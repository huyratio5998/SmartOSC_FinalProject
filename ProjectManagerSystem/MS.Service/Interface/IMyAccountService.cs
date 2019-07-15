using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IMyAccountService
    {
        AspNetUser AddAspNetUser(AspNetUser item);
        AspNetUser DeleteAspNetUser(AspNetUser item);
        bool UpdateAspNetUser(AspNetUser item);
        AspNetUser GetAspNetUser(string ID);
        IEnumerable<AspNetUser> GetAll();
        void SaveChange();
    }
}