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
        private readonly ProjectRepository _ProjectRepository;
        private IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork, ProjectRepository ProjectRepository)
        {
            _unitOfWork = unitOfWork;
            _ProjectRepository = ProjectRepository;          
        }

        public Project AddProject(Project item)
        {
            var result = _ProjectRepository.Add(item);
     
            return result;
        }

        public Project DeleteProject(Project item)
        {
            var result = _ProjectRepository.Delete(item);
            return result;
        }

        public IEnumerable<Project> GetAll()
        {
            var result = _ProjectRepository.GetAll();
            return result;
        }

        public Project GetProject(int ID)
        {
            var result = _ProjectRepository.Get(ID);
            return result;
        }

        public Project GetProject(string ID)
        {
            var result = _ProjectRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateProject(Project item)
        {
            bool result = _ProjectRepository.Update(item);
            return result;
        }
    }
}
