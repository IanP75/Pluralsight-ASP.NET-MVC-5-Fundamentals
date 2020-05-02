using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // ignores e.g. /trace.axd/1/2/3/4
            // fills variables {resource}
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            
            routes.MapRoute(
                name: "Default",
                // /home/contact/1
                // so controller='hame, action=contact, id=1
                url: "{controller}/{action}/{id}",
                // action is the method in the controller class
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
