using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IAspNetUsersService
    {
        AspNetUser AddStatus(AspNetUser item);
        AspNetUser DeleteStatus(AspNetUser item);
        bool UpdateStatus(AspNetUser item);
        AspNetUser GetStatus(int ID);
        IEnumerable<AspNetUser> GetAll();
        void SaveChange();
    }
}
