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
        private bool disposed = false;



        public UnitOfWork(MsContext context, IProjectRepository projectRepository)
        {
            _context = context;
            _projectRepository = projectRepository;
        }
        public IProjectRepository ProjectRepository
        {
            get { return _projectRepository ?? (_projectRepository = new ProjectRepository(_context)); }
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
