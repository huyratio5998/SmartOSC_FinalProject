using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using MS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service
{
    
    public class AspNetUserRolesService : IAspNetUserRolesService
    {
        private readonly IAspNetUserRolesRepository _aspNetUserRolesRepository;
        private readonly IUnitOfWork _IunitOfWork;
        //public StatusService(int ID)
        //{
        //    var result = _statusRepository.Get(ID);
        //    return result;
        //}
        public AspNetUserRolesService(IAspNetUserRolesRepository aspNetUserRolesRepository, IUnitOfWork IunitOfWork)
        {
            _aspNetUserRolesRepository = aspNetUserRolesRepository;
            _IunitOfWork = IunitOfWork;
        }

        public IdentityUserRole AddStatus(IdentityUserRole item)
        {
            var result = _IunitOfWork.AspNetUserRolesRepository.Add(item);
            return result;
        }

        public IdentityUserRole DeleteStatus(IdentityUserRole item)
        {
            var result = _IunitOfWork.AspNetUserRolesRepository.Delete(item);
            return result;
        }

        public IEnumerable<IdentityUserRole> GetAll()
        {
            var result = _IunitOfWork.AspNetUserRolesRepository.GetAll();
            return result;
        }

        public IdentityUserRole GetStatus(int ID)
        {
            var result = _IunitOfWork.AspNetUserRolesRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _IunitOfWork.Commit();
        }

        public bool UpdateStatus(IdentityUserRole item)
        {
            bool result = _IunitOfWork.AspNetUserRolesRepository.Update(item);
            return result;
        }
    }
}
