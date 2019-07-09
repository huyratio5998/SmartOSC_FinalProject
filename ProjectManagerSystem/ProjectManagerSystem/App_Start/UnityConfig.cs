using AutoMapper;
using MS.Repository;
using MS.Repository.Interface;
using MS.Service;
using MS.Service.Interface;
using ProjectManagerSystem.Controllers;
using System;
using Unity;
using Unity.Injection;

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
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<AccountController>(new InjectionConstructor());
            
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<IProjectRepository, ProjectRepository>();

            container.RegisterType<IMyAccountService, MyAccountService>();
            container.RegisterType<IMyAccountRepository, MyAccountRepository>();
            container.RegisterType<IStatusService, StatusService>();
            container.RegisterType<IStatusRepository, StatusRepository>();
            container.RegisterType<ITasksService, TasksService>();
            container.RegisterType<ITasksRepository, TasksRepository>();


        }
    }
}