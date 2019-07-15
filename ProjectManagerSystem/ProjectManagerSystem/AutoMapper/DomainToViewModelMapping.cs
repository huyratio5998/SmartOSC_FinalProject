using AutoMapper;
using MS.DataAccess.Models;
using ProjectManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.AutoMapper
{
    public  class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<AspNetUser, AspNetUsersViewModel>().ConstructUsing(p=>new AspNetUsersViewModel(p.Id,p.FullName,p.Email,p.PasswordHash,p.UserName,p.UrlAvatar));
            CreateMap<AspNetUser, RegisterViewModel>().ConstructUsing(p => new RegisterViewModel(p.Id, p.FullName, p.Email, p.PasswordHash,p.PasswordHash, p.UserName, p.UrlAvatar));
            CreateMap<AspNetRole, AspNetRolesViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Permission, PermissionViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<ProjectMember, ProjectMemberViewModel>();
            CreateMap<Status, StatusViewModel>();
            CreateMap<Tasks, TasksViewModel>();
            CreateMap<AspNetUser,MyAccountViewModels>();
            
        }
        
    }
}