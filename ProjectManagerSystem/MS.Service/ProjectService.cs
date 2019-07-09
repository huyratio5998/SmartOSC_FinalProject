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
    public class ProjectService : IProjectService
    {
        public IProjectRepository _projectRepository;
        public IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork, IProjectRepository projectRepository)
        {
            _unitOfWork = unitOfWork;
            _projectRepository = projectRepository;          
        }

        public Project AddProject(Project item)
        {
            var result = _unitOfWork.ProjectRepository.Add(item);
     
            return result;
        }

        public Project DeleteProject(Project item)
        {
            var result = _unitOfWork.ProjectRepository.Delete(item);
            return result;
        }

        public IEnumerable<Project> GetAll()
        {
            var result = _unitOfWork.ProjectRepository.GetAll();
            return result;
        }

        public Project GetProject(int ID)
        {
            var result = _unitOfWork.ProjectRepository.Get(ID);
            return result;
        }

        public Project GetProject(string ID)
        {
            var result = _unitOfWork.ProjectRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateProject(Project item)
        {
            bool result = _projectRepository.Update(item);
            return result;
        }
    }
}
