using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;

        public HomeController(IRestaurantData db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            // View stored in the folder Controller\Method.cshtml
            // So this is the view Home\About.cshtml
            return View();
            // Note that View() is a method
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // RouteConfig gives route as url: "{controller}/{action}/{id}"
        // So this url is /Home/Hello
        public string Hello()
        {
            //NB doesn't return ActionResult
            return "Hello, World!";
        }
    }
}