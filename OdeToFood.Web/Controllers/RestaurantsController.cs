using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id) // id extracted from route
        {
            var model = db.Get(id);
            if (model == null)
            {
                //redirect to other action
                //return RedirectToAction("Index");

                // Go to explicitly named view
                return View("NotFound");
            }
            return View(model);
        }

        // This is still a Get, it returns the html needed to create a restaurant.
        [HttpGet] // Only respond to Get
        public ActionResult Create()
        {
            return View();
        }

        // This is the method that responds to the post and creates the restaurant
        // Browser posts form values with names matching restaurant properties
        // MVC creates a Restaurant with these values (this is model binding)
        [HttpPost] // Only respond to Post
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            // ModelState contains what happened when the model binding happened 
            // (when creating the restaurant object parameter from the post) e.g.
            //ModelState["Name"].Value

            // Replaced with data annotation
            //if (string.IsNullOrEmpty(restaurant.Name))
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            //}

            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id }); //pass anonymous type as route values
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant!";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form) // use FormCollection as a throwaway parameter to ensure the method signature is different from above
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}