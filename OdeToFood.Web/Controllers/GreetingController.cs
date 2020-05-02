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
        public ActionResult Index(string name) // parameter automatically passed from query string
        {
            // right click Add View...

            var model = new GreetingViewModel();
            model.Name = name ?? "no name";
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model); //stored in views/Greeting/Index
        }
    }
}