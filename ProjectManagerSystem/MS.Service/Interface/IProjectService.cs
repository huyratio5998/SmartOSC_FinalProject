using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IProjectService
    {
        Project AddProject(Project item);
        Project DeleteProject(Project item);
        bool UpdateProject(Project item);
        Project GetProject(int ID);
        Project GetProject(string ID);
        IEnumerable<Project> GetAll();
        void SaveChange();
    }
}
