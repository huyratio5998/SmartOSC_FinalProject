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
    public class StatusService:IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IUnitOfWork _IunitOfWork;
        //public StatusService(int ID)
        //{
        //    var result = _statusRepository.Get(ID);
        //    return result;
        //}
        public StatusService(IStatusRepository statusRepository, IUnitOfWork IunitOfWork)
        {
            _statusRepository = statusRepository;
            _IunitOfWork = IunitOfWork;
        }

        public Status AddStatus(Status item)
        {
            var result = _statusRepository.Add(item);
            return result;
        }

        public Status DeleteStatus(Status item)
        {
            var result = _statusRepository.Delete(item);
            return result;
        }

        public IEnumerable<Status> GetAll()
        {
            var result = _statusRepository.GetAll();
            return result;
        }

        public Status GetStatus(int ID)
        {
            var result = _statusRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _IunitOfWork.Commit();
        }

        public bool UpdateStatus(Status item)
        {
            bool result = _statusRepository.Update(item);
            return result;
        }
    }
}
