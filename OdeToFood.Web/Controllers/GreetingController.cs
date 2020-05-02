using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    //right click Controllers folder to create
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index()
        {
            // right click Add View...

            var model = new GreetingViewModel();
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model);
        }
    }
}