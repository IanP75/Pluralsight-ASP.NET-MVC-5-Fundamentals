using Autofac;
using Autofac.Integration.Mvc;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        // Invoked from Global.asax Application_Start()
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            // Register all controllers from the assembly (MvcApplication is the global.asax class)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // When asked for IRestaurantData use InMemoryRestaurantData
            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance(); //Singleton (same for all requests)

            var container = builder.Build();
            // Tell it to use our container for any dependency resolution
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}