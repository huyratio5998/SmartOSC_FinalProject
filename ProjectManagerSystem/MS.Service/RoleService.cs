using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using MS.Repository;
using MS.Repository.Interface;
using MS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Service
{
    public class RoleService : IRoleService
    {
        public IRoleRepository _roleRepository;
        public IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;          
        }

        public IdentityRole AddAspNetRole(IdentityRole item)
        {
            var result = _unitOfWork.RoleRepository.Add(item);
     
            return result;
        }

        public IdentityRole AddAspNetRole(IdentityRole item, string Role, string Pass)
        {
            throw new NotImplementedException();
        }

        public IdentityRole DeleteAspNetRole(IdentityRole item)
        {
            var result = _unitOfWork.RoleRepository.Delete(item);
            return result;
        }

        public IEnumerable<IdentityRole> GetAll()
        {
            var result = _unitOfWork.RoleRepository.GetAll();
            return result;
        }

        public IdentityRole GetAspNetRole(int ID)
        {
            var result = _unitOfWork.RoleRepository.Get(ID);
            return result;
        }

        public IdentityRole GetAspNetRole(string ID)
        {
            var result = _unitOfWork.RoleRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateAspNetRole(IdentityRole item)
        {
            bool result = _unitOfWork.RoleRepository.Update(item);
            return result;
        }
    }
}
