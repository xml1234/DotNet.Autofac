using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Autofac.Mvc.ITest;
using Autofac.Mvc.Test;

//using AutofacDemo.MovieFinder;

namespace Autofac.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ////Autofac初始化过程
            //var builder = new ContainerBuilder();
            ////builder.RegisterControllers(typeof(MvcApplication).Assembly);//注册所有的Controller
            //builder.RegisterFilterProvider();


            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(UserRepositories)).As(typeof(IUserRepositories));
            builder.RegisterControllers(typeof(MvcApplication).Assembly);//注册所有的Controller
            // builder.RegisterModule<AutofacWebTypesModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
