using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IStatusService
    {

        //Status FindStatus(int ID);
        Status AddStatus(Status item);
        Status DeleteStatus(Status item);
        bool UpdateStatus(Status item);
        Status GetStatus(int ID);
        IEnumerable<Status> GetAll();
        void SaveChange();
    }
}
