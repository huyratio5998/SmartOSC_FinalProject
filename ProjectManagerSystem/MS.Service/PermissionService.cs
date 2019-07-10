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
    public class PermissionService : IPermissionService
    {
        public IPermissionRepository _permissionRepository;
        public IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork, IPermissionRepository permissionRepository)
        {
            _unitOfWork = unitOfWork;
            _permissionRepository = permissionRepository;          
        }

        public Permission AddPermission(Permission item)
        {
            var result = _unitOfWork.PermissionRepository.Add(item);
     
            return result;
        }

        public Permission AddPermission(Permission item, string Role, string Pass)
        {
            throw new NotImplementedException();
        }

        public Permission DeletePermission(Permission item)
        {
            var result = _unitOfWork.PermissionRepository.Delete(item);
            return result;
        }

        public IEnumerable<Permission> GetAll()
        {
            var result = _unitOfWork.PermissionRepository.GetAll();
            return result;
        }

        public Permission GetPermission(int ID)
        {
            var result = _unitOfWork.PermissionRepository.Get(ID);
            return result;
        }

        public Permission GetPermission(string ID)
        {
            var result = _unitOfWork.PermissionRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdatePermission(Permission item)
        {
            bool result = _unitOfWork.PermissionRepository.Update(item);
            return result;
        }
    }
}
