using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service.Interface
{
    public interface IProjectMemberService
    {
        ProjectMember AddProjectMember(ProjectMember item);
        ProjectMember DeleteProjectMember(ProjectMember item);
        bool UpdateProjectMember(ProjectMember item);
        ProjectMember GetProjectMember(int ID);
        ProjectMember GetProjectMember(string ID);
        IEnumerable<ProjectMember> GetAll();
        void SaveChange();
    }
}
