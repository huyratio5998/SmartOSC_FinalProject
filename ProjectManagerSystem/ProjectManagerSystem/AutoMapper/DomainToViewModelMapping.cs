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
            CreateMap<AspNetUser, AspNetUsersViewModel>();
            CreateMap<AspNetRole, AspNetRolesViewModel>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<Permission, PermissionViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Status, StatusViewModel>();
            CreateMap<Tasks, TasksViewModel>();
            CreateMap<AspNetUser,MyAccountViewModels>();
        }
        
    }
}