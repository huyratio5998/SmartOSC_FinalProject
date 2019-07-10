using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IFunctionService
    {
        Function AddFunction(Function item,string Role,string Pass);
        Function DeleteFunction(Function item);
        bool UpdateFunction(Function item);
        Function GetFunction(int ID);
        Function GetFunction(string ID);
        IEnumerable<Function> GetAll();        
      //  Task<Function> addUserAsync(Function Function, string Role, string Pass);
    }
}
