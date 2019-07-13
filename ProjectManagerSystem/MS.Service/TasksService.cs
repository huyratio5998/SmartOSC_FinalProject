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
    public class TasksService : ITasksService
    {
        // gọi đến tầng Repository
        private readonly ITasksRepository _TasksRepository;
        private readonly IUnitOfWork _unitOfWork;

        //khai báo constructor
        public TasksService(ITasksRepository tasksRepository, IUnitOfWork iunitOfWork)
        {
            _TasksRepository = tasksRepository;
            _unitOfWork = iunitOfWork;
        }

        // thêm tasks
        public Tasks AddTasks(Tasks item)
        {
            var result = _TasksRepository.Add(item);
            return result;
        }

        //xóa tasks
        public Tasks DeleteTasks(Tasks item)
        {
            var result = _TasksRepository.Delete(item);
            return result;
        }

        public Tasks DeleteTasksbyId(int ID)
        {
            var result = _TasksRepository.Delete(ID);
            return result;
        }

        //Lấy tất cả tasks
        public IEnumerable<Tasks> GetAll()
        {
            var result = _TasksRepository.GetAll().ToList();
            return result;
        }

        // Lấy nhiều taskso ID kiểu int
        public Tasks GetTasks(int ID)
        {
            var result = _TasksRepository.Get(ID);
            return result;
        }

        //Lấy tasks theo ID kiểu string
        public Tasks GetTasks(string ID)
        {
            var result = _TasksRepository.Get(ID);
            return result;
        }
        //Luu lai
        public void SaveChange()
        {
            _TasksRepository.Save();
        }
        

        // Update
        public bool UpdateTasks(Tasks item)
        {
            bool result = _TasksRepository.Update(item);
            return result;
        }
        
    }
}
