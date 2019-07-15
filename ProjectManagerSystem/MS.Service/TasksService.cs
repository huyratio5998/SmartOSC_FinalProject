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
    public class TasksService : ITasksService
    {
        public ITasksRepository _tasksRepository;
        public IUnitOfWork _unitOfWork;

        public TasksService(IUnitOfWork unitOfWork, ITasksRepository tasksRepository)
        {
            _unitOfWork = unitOfWork;
            _tasksRepository = tasksRepository;          
        }

        public Tasks AddTasks(Tasks item)
        {
            var result = _unitOfWork.TasksRepository.Add(item);
     
            return result;
        }

        public Tasks DeleteTasks(Tasks item)
        {
            var result = _unitOfWork.TasksRepository.Delete(item);
            return result;
        }

        public IEnumerable<Tasks> GetAll()
        {
            var result = _unitOfWork.TasksRepository.GetAll().ToList();
            return result;
        }

        public Tasks GetTasks(int ID)
        {
            var result = _unitOfWork.TasksRepository.Get(ID);
            return result;
        }

        public Tasks GetTasks(string ID)
        {
            var result = _unitOfWork.TasksRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
        public Tasks DeleteTasksbyId(int ID)
        {
            var result = _unitOfWork.TasksRepository.Delete(ID);
            return result;
        }
        public bool UpdateTasks(Tasks item)
        {
            bool result = _unitOfWork.TasksRepository.Update(item);
            return result;
        }
    }
}
