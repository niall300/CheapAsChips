using CheapAsChips.DAL;
using CheapAsChips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheapAsChips.Controllers
{
    //this would only allowlogged in users access the class
    //[Authorize]
    public class NewRecipeController : Controller
    {
        private RecipeContext db = new RecipeContext();

       //[AllowAnonoymous] would allow this action if the rest of the class was restricted
        // GET: NewRecipe
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewRecipe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewRecipe/Create
        public ActionResult Create()
        {
           NewRecipe myNewRecipe = new NewRecipe();
            return View(myNewRecipe);
        }

        // POST: NewRecipe/Create
       //only certain people can add recipes
        //[Authorize(Roles = "Admin, Super User",Users = "Betty, Johnny")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewRecipe/Edit/5
        [Authorize]//allows any logged in user
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewRecipe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NewRecipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewRecipe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
