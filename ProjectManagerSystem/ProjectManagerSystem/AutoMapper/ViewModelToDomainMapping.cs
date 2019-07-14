using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using ProjectManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSystem.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<ProjectViewModel, Project>().ConstructUsing(p => new Project(p.Id, p.Name, p.SortNameProject, p.StartDate, p.EndDate, p.isDeleted));
            CreateMap<AspNetUsersViewModel, AspNetUser>().ConstructUsing(p => new AspNetUser(p.Id,p.UserName,p.FullName,p.Password,p.Email,p.UserName));
            CreateMap<AspNetRolesViewModel, IdentityRole>().ConstructUsing(p => new IdentityRole(p.Name));
            CreateMap<FunctionViewModel, Function>().ConstructUsing(p => new Function(p.Id,p.Name,p.URL,p.ParentId,p.IconCss,p.SortOrder));
            CreateMap<PermissionViewModel, Permission>().ConstructUsing(p => new Permission(p.Id,p.AspNetRolesViewModel.Id,p.Function.Id,p.CanRead,p.CanCreate,p.CanUpdate,p.CanDelete));
            CreateMap<StatusViewModel, Status>().ConstructUsing(p => new Status(p.Id,p.Name));

            CreateMap<TasksViewModel, Tasks>().ConstructUsing(p => new Tasks(p.Id, p.ProjectId, p.UserId, p.StatusId, p.SortNameTask, p.Name, p.Description));

            CreateMap<MyAccountViewModels, AspNetUser>().ConstructUsing(p => new AspNetUser(p.Id, p.UserName, p.FullName, p.Password, p.Email, p.UrlAvatar));
            CreateMap<AspNetUserRolesViewModel, IdentityUserRole>().ConstructUsing(p => new IdentityUserRole());
        }   
    }
}