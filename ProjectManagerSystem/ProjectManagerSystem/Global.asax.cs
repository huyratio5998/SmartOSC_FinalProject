﻿using AutoMapper;

using ProjectManagerSystem.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace ProjectManagerSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // khởi tạo mapping
           // MappingConfig.RegisterMaps();
          
           
            Mapper.Initialize(p =>
            {
                p.AddProfile(new DomainToViewModelMapping());
                p.AddProfile(new ViewModelToDomainMapping());
            });

            UnityConfig.RegisterTypes(new UnityContainer());
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }
    }
}
