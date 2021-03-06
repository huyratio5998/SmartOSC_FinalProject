﻿using MS.DataAccess.Models;
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
        private readonly MyAccountRepository _myAccountRepository;
        private readonly IUnitOfWork _IunitOfWork;

        public MyAccountService(MyAccountRepository myAccountRepository, IUnitOfWork IunitOfWork)
        {
            _myAccountRepository = myAccountRepository;
            _IunitOfWork = IunitOfWork;
        }

        public AspNetUser AddAspNetUser(AspNetUser item)
        {
            var result = _myAccountRepository.Add(item);
            return result;
        }

        public AspNetUser DeleteAspNetUser(AspNetUser item)
        {
            var result = _myAccountRepository.Delete(item);
            return result;
        }

        public IEnumerable<AspNetUser> GetAll()
        {
            var result = _myAccountRepository.GetAll();
            return result;
        }

        public AspNetUser GetAspNetUser(string ID)
        {
            var result = _myAccountRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _IunitOfWork.Commit();
        }

        public bool UpdateAspNetUser(AspNetUser item)
        {
            bool result = _myAccountRepository.Update(item);
            return result;
        }
    }
}