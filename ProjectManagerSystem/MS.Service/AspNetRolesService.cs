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

    public class AspNetRolesService : IAspNetRolesService
    {
        private readonly IAspNetRolesRepository _aspNetRolesRepository;
        private readonly IUnitOfWork _IunitOfWork;
        //public StatusService(int ID)
        //{
        //    var result = _statusRepository.Get(ID);
        //    return result;
        //}
        public AspNetRolesService(IAspNetRolesRepository aspNetRolesRepository, IUnitOfWork IunitOfWork)
        {
            _aspNetRolesRepository = aspNetRolesRepository;
            _IunitOfWork = IunitOfWork;
        }

        public IdentityRole AddStatus(IdentityRole item)
        {
            var result = _aspNetRolesRepository.Add(item);
            return result;
        }

        public IdentityRole DeleteStatus(IdentityRole item)
        {
            var result = _aspNetRolesRepository.Delete(item);
            return result;
        }

        public IEnumerable<IdentityRole> GetAll()
        {
            var result = _aspNetRolesRepository.GetAll();
            return result;
        }

        public IdentityRole GetStatus(int ID)
        {
            var result = _aspNetRolesRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _aspNetRolesRepository.Save();
        }

        public bool UpdateStatus(IdentityRole item)
        {
            bool result = _aspNetRolesRepository.Update(item);
            return result;
        }
    }
}
