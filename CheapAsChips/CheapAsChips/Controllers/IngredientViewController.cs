using CheapAsChips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheapAsChips.Controllers
{
    public class IngredientViewController : Controller
    {
        // GET: IngredientView
        public ActionResult Index()
        {
            return View();
        }

        // GET: IngredientView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IngredientView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientView/Create
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

        // GET: IngredientView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngredientView/Edit/5
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

        // GET: IngredientView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngredientView/Delete/5
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

        //method to add ingreients to ingredient list
        [HttpPost]
        public ActionResult Add(IngredientViewModel viewModel)
        {
            try
            {
                viewModel.IngredientsList.Add(viewModel.Ingredient);
                return PartialView("_AddIngredients");
            }
            catch
            {
                return View();
            }

        }
       

        }

    }

