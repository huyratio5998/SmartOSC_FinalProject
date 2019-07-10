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
    public class FunctionService : IFunctionService
    {
        public IFunctionRepository _functionRepository;
        public IUnitOfWork _unitOfWork;

        public FunctionService(IUnitOfWork unitOfWork, IFunctionRepository functionRepository)
        {
            _unitOfWork = unitOfWork;
            _functionRepository = functionRepository;          
        }

        public Function AddFunction(Function item)
        {
            var result = _unitOfWork.FunctionRepository.Add(item);
     
            return result;
        }

        public Function AddFunction(Function item, string Role, string Pass)
        {
            throw new NotImplementedException();
        }

        public Function DeleteFunction(Function item)
        {
            var result = _unitOfWork.FunctionRepository.Delete(item);
            return result;
        }

        public IEnumerable<Function> GetAll()
        {
            var result = _unitOfWork.FunctionRepository.GetAll();
            return result;
        }

        public Function GetFunction(int ID)
        {
            var result = _unitOfWork.FunctionRepository.Get(ID);
            return result;
        }

        public Function GetFunction(string ID)
        {
            var result = _unitOfWork.FunctionRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateFunction(Function item)
        {
            bool result = _unitOfWork.FunctionRepository.Update(item);
            return result;
        }
    }
}
