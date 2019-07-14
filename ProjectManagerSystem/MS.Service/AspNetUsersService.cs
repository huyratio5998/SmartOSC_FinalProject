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
    public class AspNetUsersService : IAspNetUsersService
    {
        private readonly IAspNetUsersRepository _aspNetUsersRepository;
        private readonly IUnitOfWork _IunitOfWork;
        //public StatusService(int ID)
        //{
        //    var result = _statusRepository.Get(ID);
        //    return result;
        //}
        public AspNetUsersService(IAspNetUsersRepository aspNetUsersRepository, IUnitOfWork IunitOfWork)
        {
            _aspNetUsersRepository = aspNetUsersRepository;
            _IunitOfWork = IunitOfWork;
        }

        public AspNetUser AddStatus(AspNetUser item)
        {
            var result = _aspNetUsersRepository.Add(item);
            return result;
        }

        public AspNetUser DeleteStatus(AspNetUser item)
        {
            var result = _aspNetUsersRepository.Delete(item);
            return result;
        }

        public IEnumerable<AspNetUser> GetAll()
        {
            var result = _aspNetUsersRepository.GetAll();
            return result;
        }

        public AspNetUser GetStatus(int ID)
        {
            var result = _aspNetUsersRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _aspNetUsersRepository.Save();
        }

        public bool UpdateStatus(AspNetUser item)
        {
            bool result = _aspNetUsersRepository.Update(item);
            return result;
        }
    }
}
