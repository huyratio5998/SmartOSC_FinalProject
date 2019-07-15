using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository
{
    public class UnitOfWork : IUnitOfWork, System.IDisposable
    {
        
        private readonly MsContext _context;
        private IProjectRepository _projectRepository;
        private IProjectMemberRepository _projectMemberRepository;
        private IFunctionRepository _functionRepository;
        private IPermissionRepository _permissionRepository;        
        private ITasksRepository _tasksRepository;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;
        private IMyAccountRepository _myAccountRepository;
        private IStatusRepository _statusRepository;

        private IAspNetRolesRepository _aspNetRolesRepository;
        private IAspNetUserRolesRepository _aspNetUserRolesRepository;
        private bool disposed = false;



        public UnitOfWork(MsContext context)
        {
            _context = context;
          
        }
        public IAspNetRolesRepository AspNetRolesRepository
        {
            get { return _aspNetRolesRepository ?? (_aspNetRolesRepository = new AspNetRolesRepository(_context)); }
        }
        public IAspNetUserRolesRepository AspNetUserRolesRepository
        {
            get { return _aspNetUserRolesRepository ?? (_aspNetUserRolesRepository = new AspNetUserRolesRepository(_context)); }
        }

        public IStatusRepository StatusRepository
        {
            get { return _statusRepository ?? (_statusRepository = new StatusRepository(_context)); }
        }
        public IMyAccountRepository MyAccountRepository
        {
            get { return _myAccountRepository ?? (_myAccountRepository = new MyAccountRepository(_context)); }
        }
        public IProjectRepository ProjectRepository
        {
            get { return _projectRepository ?? (_projectRepository = new ProjectRepository(_context)); }
        }
        public IProjectMemberRepository ProjectMemberRepository
        {
            get { return _projectMemberRepository ?? (_projectMemberRepository = new ProjectMemberRepository(_context)); }
        }
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }
        public IFunctionRepository FunctionRepository
        {
            get { return _functionRepository ?? (_functionRepository = new FunctionRepository(_context)); }
        }
        public IPermissionRepository PermissionRepository
        {
            get { return _permissionRepository ?? (_permissionRepository = new PermissionRepository(_context)); }
        }
        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }
        public ITasksRepository TasksRepository
        {
            get { return _tasksRepository ?? (_tasksRepository = new TasksRepository(_context)); }
        }
        public IUserRoleRepository UserRoleRepository
        {
            get { return _userRoleRepository ?? (_userRoleRepository = new UserRoleRepository(_context)); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
