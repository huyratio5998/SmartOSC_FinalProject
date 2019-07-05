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
        private readonly UserRepository _userRepository;
        private readonly IUnitOfWork _IunitOfWork;

        public UserService(UserRepository userRepository, IUnitOfWork IunitOfWork)
        {
            _userRepository = userRepository;
            _IunitOfWork = IunitOfWork;
        }

        public AspNetUser AddAspNetUser(AspNetUser item)
        {
            var result = _userRepository.Add(item);
            return result;
        }

        public AspNetUser DeleteAspNetUser(AspNetUser item)
        {
            var result = _userRepository.Delete(item);
            return result;
        }

        public IEnumerable<AspNetUser> GetAll()
        {
            var result = _userRepository.GetAll();
            return result;
        }

        public AspNetUser GetAspNetUser(int ID)
        {
            var result = _userRepository.Get(ID);
            return result;
        }

        public AspNetUser GetAspNetUser(string ID)
        {
            var result = _userRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _IunitOfWork.Save();
        }

        public bool UpdateAspNetUser(AspNetUser item)
        {
            bool result = _userRepository.Update(item);
            return result;
        }
    }
}
