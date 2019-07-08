using MS.DataAccess;
using MS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private  MsContext _context;
        public IProjectRepository _projectRepository;

        public UnitOfWork(MsContext context)
        {
            _context = context;
        }  
        
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
