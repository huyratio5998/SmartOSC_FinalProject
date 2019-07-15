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
    public class ProjectMemberService : IProjectMemberService
    {
        public readonly IProjectMemberRepository _ProjectMemberRepository;
        public IUnitOfWork _unitOfWork;

        public ProjectMemberService(IUnitOfWork unitOfWork, IProjectMemberRepository ProjectMemberRepository)
        {
            _unitOfWork = unitOfWork;
            _ProjectMemberRepository = ProjectMemberRepository;
        }

        public ProjectMember AddProjectMember(ProjectMember item)
        {
            var result = _unitOfWork.ProjectMemberRepository.Add(item);
     
            return result;
        }

        public ProjectMember DeleteProjectMember(ProjectMember item)
        {
            var result = _unitOfWork.ProjectMemberRepository.Delete(item);
            return result;
        }

        public IEnumerable<ProjectMember> GetAll()
        {
            var result = _unitOfWork.ProjectMemberRepository.GetAll();
            return result;
        }

        public ProjectMember GetProjectMember(int ID)
        {
            var result = _unitOfWork.ProjectMemberRepository.Get(ID);
            return result;
        }

        public ProjectMember GetProjectMember(string ID)
        {
            var result = _unitOfWork.ProjectMemberRepository.Get(ID);
            return result;
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateProjectMember(ProjectMember item)
        {
            bool result = _unitOfWork.ProjectMemberRepository.Update(item);
            return result;
        }
    }
}