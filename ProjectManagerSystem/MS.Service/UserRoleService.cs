using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using MS.Repository;
using MS.Repository.Interface;
using MS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MS.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;        
        public IUnitOfWork _unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork, IUserRoleRepository userRoleRepository)
        {
            _unitOfWork = unitOfWork;
            _userRoleRepository = userRoleRepository;
        }

        public IdentityUserRole AddAspNetUserRole(IdentityUserRole item)
        {
            var result=_unitOfWork.UserRoleRepository.Add(item);
            return result;
        }

        public IdentityUserRole DeleteAspNetUserRole(IdentityUserRole item)
        {
            var result = _unitOfWork.UserRoleRepository.Delete(item);
            return result;
        }

        public IEnumerable<IdentityUserRole> GetAll()
        {
            var result = _unitOfWork.UserRoleRepository.GetAll();
            return result;
        }

        public IdentityUserRole GetAspNetUserRole(int ID)
        {
            var result = _unitOfWork.UserRoleRepository.Get(ID);
            return result;
        }

        public IdentityUserRole GetAspNetUserRole(string ID)
        {
            var result = _unitOfWork.UserRoleRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateAspNetUserRole(IdentityUserRole item)
        {
            bool result = _unitOfWork.UserRoleRepository.Update(item);
            return result;
        }
    }
}
