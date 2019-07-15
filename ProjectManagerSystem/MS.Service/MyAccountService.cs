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
    public class MyAccountService : IMyAccountService
    {
        private readonly IMyAccountRepository _myAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MyAccountService(IMyAccountRepository myAccountRepository, IUnitOfWork IunitOfWork)
        {
            _myAccountRepository = myAccountRepository;
            _unitOfWork = IunitOfWork;
        }

        public AspNetUser AddAspNetUser(AspNetUser item)
        {
            var result = _unitOfWork.MyAccountRepository.Add(item);
            return result;
        }

        public AspNetUser DeleteAspNetUser(AspNetUser item)
        {
            var result = _unitOfWork.MyAccountRepository.Delete(item);
            return result;
        }

        public IEnumerable<AspNetUser> GetAll()
        {
            var result = _unitOfWork.MyAccountRepository.GetAll();
            return result;
        }

        public AspNetUser GetAspNetUser(string ID)
        {
            var result = _unitOfWork.MyAccountRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateAspNetUser(AspNetUser item)
        {
            bool result = _unitOfWork.MyAccountRepository.Update(item);
            return result;
        }
    }
}