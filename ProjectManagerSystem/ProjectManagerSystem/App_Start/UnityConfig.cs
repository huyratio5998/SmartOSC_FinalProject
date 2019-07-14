using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Repository;
using MS.Repository.Interface;
using MS.Service;
using MS.Service.Interface;
using ProjectManagerSystem.Controllers;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;

using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace ProjectManagerSystem
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

        
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //var UnityContainer = new UnityContainer();
            // container.RegisterType<IMapper, Mapper>();
            container.RegisterType<IUserStore<AspNetUser>, UserStore<AspNetUser>>();
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            //container.RegisterType<IUserStore<AspNetRole>, UserStore<AspNetRole>>();
            container.RegisterType<UserManager<AspNetUser>>();            
            container.RegisterType<ApplicationUserManager>();
            
           

            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<RoleController>(new InjectionConstructor());
            container.RegisterType<DbContext, MsContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            
                //container.RegisterType<IRoleStore, RoleStore>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<IProjectRepository, ProjectRepository>();
            container.RegisterType<IProjectMemberRepository, ProjectMemberRepository>();
            container.RegisterType<IProjectMemberService, ProjectMemberService>();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<ITasksRepository, TasksRepository>();
            container.RegisterType<ITasksService, TasksService>();

            container.RegisterType<IUserRoleService, UserRoleService>();
            container.RegisterType<IUserRoleRepository, UserRoleRepository>();

            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IRoleRepository, RoleRepository>();

            container.RegisterType<IMyAccountService, MyAccountService>();
            container.RegisterType<IMyAccountRepository, MyAccountRepository>();
            container.RegisterType<IStatusRepository, StatusRepository>();
            container.RegisterType<IStatusService, StatusService>();
            //   container.RegisterType<ApplicationUserStore>().RegisterType<IUserStore<AspNetUser>>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        }
    }
}