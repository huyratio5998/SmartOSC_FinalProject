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
        Status AddTasks(Status item);
        Status DeleteTasks(Status item);
        bool UpdateTasks(Status item);
        Status GetTasks(int ID);
        Status GetTasks(string ID);
        //  IEnumerable<Tasks> GetAll();
        IEnumerable<Status> GetAll(string UserId, int projectId);
        void SaveChange();
    }
}
