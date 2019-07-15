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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;        
        public IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        

        public AspNetUser AddAspNetUser(AspNetUser item, string Role, string Pass)
        {
            var result = _unitOfWork.UserRepository.Add(item, Role, Pass);
            return result;
        }

        //public async Task<AspNetUser> addUserAsync(AspNetUser aspNetUser, string Pass, string Role)
        //{

        //    await _userManager.CreateAsync(aspNetUser, Pass);
        //    await _userManager.AddToRoleAsync(aspNetUser.Id, Role);
        //    return aspNetUser;
        //}

        public AspNetUser DeleteAspNetUser(AspNetUser item)
        {
            var result = _unitOfWork.UserRepository.Delete(item);
            return result;
        }

        public IEnumerable<AspNetUser> GetAll()
        {
            var result = _unitOfWork.UserRepository.GetAll();
            return result;
        }

        public AspNetUser GetAspNetUser(int ID)
        {
            var result = _unitOfWork.UserRepository.Get(ID);
            return result;
        }

        public AspNetUser GetAspNetUser(string ID)
        {
            var result = _unitOfWork.UserRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateAspNetUser(AspNetUser item)
        {
            bool result = _unitOfWork.UserRepository.Update(item);
            return result;
        }
       
    }
}
