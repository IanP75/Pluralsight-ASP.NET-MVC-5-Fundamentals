using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        // Invoked from Global.asax Application_Start()
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            // Register all controllers from the assembly (MvcApplication is the global.asax class)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Register API controllers too
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            // When asked for IRestaurantData use InMemoryRestaurantData
            //builder.RegisterType<InMemoryRestaurantData>()
            //    .As<IRestaurantData>()
            //    .SingleInstance(); //Singleton (same for all requests)

            //change to sql database
            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData>()
                .InstancePerRequest();

            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build();
            // Tell it to use our container for any dependency resolution
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // API needs separate configuration (via httpConfiguration passed in above)
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}