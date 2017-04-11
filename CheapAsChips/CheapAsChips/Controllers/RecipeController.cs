using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheapAsChips.DAL;
using CheapAsChips.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace CheapAsChips.Controllers
{
    public class RecipeController : Controller
    {

        //testing 123
        private RecipeContext db = new RecipeContext();

        List<Ingredient> myIngredients = new List<Ingredient>();

        // GET: Recipe
        public ActionResult Index()
        {
            return View(db.Recipe.ToList());
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }
        //render photo from byte array
        public ActionResult RenderPhoto(/*int RecipeID*/)
        {
            //get image data
            RecipeImage image = db.Image.Find(2);
            //add to byte array
            Byte[] imageArray = image.imagedata;

            using (Image myimage = Image.FromStream(new MemoryStream(imageArray)))
            {
               
                //myimage.Save("output.jpg", ImageFormat.Jpeg);  // Or Png
                return View("myimage");
            }
            
            //convert to string
            //string myImagestring = Convert.ToBase64String(imageArray);

            //using (var ms = new MemoryStream(imageArray, 0, imageArray.Length))
            //{
            //    System.Drawing.Image myimage = System.Drawing.Image.FromStream(ms, true);
            //    return myimage;
            //}


        }
        

        // GET: Recipe/Create
        //[Authorize]
        public ActionResult Create()
        {
           

            return View();
        }

        // POST: Recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dateAdded,Title,MainIngredient,description,NumberOfServings,Notes,Tip,Blender,Method,MealType,FoodType,Spicy")] Recipe recipe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Recipe.Add(recipe);
                    db.SaveChanges();
                    //add recipe and call the FileUpload controller
                    return RedirectToAction("FileUpload", recipe);
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see call Niall.");
            }

            return View(recipe);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Search(Recipe rcp)
        {
            var recipes = from r in db.Recipe
                          select r;
            //TODO add logic to search by main ingredient
            if (rcp.MainIngredient != null)
            {

                recipes = db.Recipe.Where(s => s.MainIngredient.Contains(rcp.MainIngredient));
                //create a list of recipes and pass to displayresults
                List<Recipe> recipeList = new List<Recipe>();
                recipeList = recipes.ToList();
                //Recipe rec = new Recipe();
                //rec.MainIngredient = "cheese";
                //recipeList.Add(rec);

                return View("DisplayResults", recipeList);

            }

            return View("Index");
        }

        public ActionResult DisplayResults(List<Recipe> recipeList)
        {

            //check that list is not null
            if (recipeList != null)
            {
                return View(recipeList);
            }
            return View("NoResults");
        }
        public ActionResult NoResults()
        {
            return View();
        }

        //Upload Image
        [HttpGet]
        public ActionResult FileUpload(Recipe recipe)
        {


            return View(recipe);
        }
        public ActionResult FileUpload(HttpPostedFileBase file, Recipe recipe)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                //file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    //here we create a byte array from our photo
                    byte[] myImage = ms.GetBuffer();

                    RecipeImage image = new RecipeImage();
                    image.RecipeID = recipe.RecipeID;
                    image.imagedata = myImage;
                    db.Image.Add(image);
                    //save changes
                    db.SaveChanges();

                }

            }
            // after successfully uploading redirect the user
            //to add ingredients
           //recipe.RecipeID;

            return RedirectToAction("AddIngredients", recipe);
        }

        public ActionResult DisplayImage(int recipeid)
        {

            return View();
        }

        //add ingredients
        //this method is called initially by the create controller
        //not below is the second get method that takes an ingredient
        //and is redirected from the addIngredients post controller
        //[HttpGet]
        //public ActionResult AddIngredients(Recipe recipe)
        //{
        //    //create new ingredient
        //    Ingredient ing = new Ingredient();
        //    //assign recipe id
        //    ing.RecipeID = recipe.RecipeID;
            

        //    //display list of ingredients
        //    //TODO
        //    //Add Finish button to redirect to add instructions controller action
            
           
        //    ViewBag.theMessage = "Add your ingredients.";
                      
        //    return View(ing);
        //}
        [HttpGet]
        //not getting the rceipeid
        public ActionResult AddIngredients(Ingredient ing)
        {
            //create new ingredient
             Ingredient newIng = new Ingredient();
            //assign id from previous ingredient
            newIng.RecipeID = ing.RecipeID;
           



            //display list of ingredients
            //TODO
            //Add Finish button to redirect to add instructions controller action
            ViewBag.theMessage = "Add your ingredients.";
            //recipe id persists to here
            return View(newIng);
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("AddIngredients")]
        public ActionResult AddIngredientspost(Ingredient ing)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add ingredient

                    db.Ingredients.Add(ing);
                    db.SaveChanges();
                    //add ingredient to list
                    myIngredients.Add(ing);
                    //when finshed is called iterate over list and add to database

                    //return to add ingredients view
                    //recipeid persists first time to here
                    int recipeid = ing.RecipeID;
                    return RedirectToAction("AddIngredients",ing);
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists call Niall.");
            }

            return View(ing);
        }

        [HttpGet]
        //not recieving the recipeId
        public ActionResult AddInstructions(Instructions ins)
        {

            //create new ingredient
            ins.RecipeID = ViewBag.id;
            Instructions newIns = new Instructions();
            //assign id from previous instruction
            newIns.RecipeID = ins.RecipeID;
            
            //Add Finish button to redirect to add instructions controller action
            ViewBag.theMessage = "Add your instructions.";
            //recipe id persists to here
            ;
           
            return View(newIns);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("AddInstructions")]
        public ActionResult AddInstructionsPost(Instructions ins)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add ingredient

                    db.Instructions.Add(ins);
                    db.SaveChanges();
                    //add ingredient to list
                    //myIngredients.Add(ins);
                    //when finshed is called iterate over list and add to database

                    //return to add ingredients view
                    //recipeid persists first time to here
                    int recipeid = ins.RecipeID;
                    return RedirectToAction("AddIngredients", ins);
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists call Niall.");
            }

            return View(ins);
        }
        public ActionResult AddToDatabse()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add ingredients to databse
                    foreach (Ingredient i in myIngredients)
                    {

                        db.Ingredients.Add(i);
                        db.SaveChanges();
                    }
                    
                    
                   
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see call Niall.");
            }
            //code to add contents of our ingredient list to the database
           

            return View("index");
        }
        [HttpGet]
        public ActionResult AddMoreIngredients(int recipeid)
        {
            //create new ingredient
            Ingredient newIng = new Ingredient();
            //assign id from previous ingredient
            newIng.RecipeID = recipeid;
            //add ingredient to database
           

            
            //display list of ingredients
            //TODO
            //Add Finish button to redirect to add instructions controller action
            ViewBag.theMessage = "Add your ingredients.";
            

            return View(newIng);
        }

        [HttpPost]
        public ActionResult AddMoreIngredients(Ingredient ing)
        {
            //create new ingredient
            Ingredient newIng = new Ingredient();
            //assign id from previous ingredient
            newIng.RecipeID = ing.RecipeID;
            try
            {
                if (ModelState.IsValid)
                {
                    //add ingredient

                    //db.Ingredients.Add(newIng);
                    //db.SaveChanges();
                    //add ingredient to list
                    myIngredients.Add(newIng);
                    int recipeid = newIng.RecipeID;

                    //return to add ingredients view
                    //recipeid persists first time to here
                    return RedirectToAction("AddMoreIngredients", recipeid);
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see call Niall.");
            }




            //display list of ingredients
            //TODO
            //Add Finish button to redirect to add instructions controller action
            ViewBag.theMessage = "Add your ingredients.";

            return View(newIng);
        }
        //Add Instructions
        public ActionResult AddInstructions()
        {
            return View();
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "RecipeID,dateAdded,Title,MainIngredient,description,NumberOfServings,Notes,Tip,Blender,Method,MealType,FoodType,Spicy")] Recipe recipe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(recipe).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(recipe);
        //}

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recipeToUpdate = db.Recipe.Find(id);
            if (TryUpdateModel(recipeToUpdate, "",
               new string[] { "Title", "MainIngredient", "description "}))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(recipeToUpdate);
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipe.Find(id);
            db.Recipe.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
