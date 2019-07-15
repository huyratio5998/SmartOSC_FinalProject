using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository.Interface
{
    public interface IUnitOfWork
    {
        void Commit();

        IProjectRepository ProjectRepository { get; }
        IProjectMemberRepository ProjectMemberRepository { get; }
        IUserRepository UserRepository { get; }
        IFunctionRepository FunctionRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IRoleRepository RoleRepository { get; }
        ITasksRepository TasksRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IMyAccountRepository MyAccountRepository { get; }
        IStatusRepository StatusRepository { get; }

        IAspNetRolesRepository AspNetRolesRepository { get; }
        IAspNetUserRolesRepository AspNetUserRolesRepository { get; }
    }
}
