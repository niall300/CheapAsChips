using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using CheapAsChips.Models;

namespace CheapAsChips.DAL
{
    public class RecipeInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<RecipeContext>
    {
        protected override void Seed(RecipeContext context)
        {
            //create a list of recipes 
            var recipes = new List<Recipe>
            {
                new Recipe{ Title ="Cheese Sandwich", MainIngredient = "Cheese", Blender= false,
                    description= " some cheese and some bread", FoodType = Models.FoodType.Vegetarian,
                    NumberOfServings = 1, Notes = "Delicious Toasted", MealType = Models.MealType.Snack,
                    Tip = " try using toaster bags if you have no grill.", Method = Models.Method.Bake, Spicy = false,
                    dateAdded=DateTime.Parse("2012-07-15")},

                new Recipe{   Title ="Ham Sandwich", MainIngredient = "Ham", Blender= false,
                    description= " some Ham Between some bread", FoodType = Models.FoodType.Meat,
                    NumberOfServings = 1, Notes = "Try with english mustard", MealType = Models.MealType.Snack,
                    Tip = " try using toaster bags if you have no grill.", Method = Models.Method.Bake, Spicy = false,
                    dateAdded=DateTime.Parse("2015-09-01")}
            };

           //itrerate through the list and add to database table "Recipe"
            recipes.ForEach(s => context.Recipe.Add(s));
            context.SaveChanges();

            //do the same for ingredients table
            var ingredients = new List<Ingredient>
            {
                new Ingredient{   Measure = "piece", Name = "Sliced Bread", Quantity = 2 },
                new Ingredient{   Measure = "grams", Name = "Cheddar Cheese", Quantity = 200 },
                new Ingredient{   Measure = "grams", Name = "Butter", Quantity = 30 }

           
            };

            ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();


            //***here we add our association table data. This allows us to connect
            //recipe ID=1 (cheese sandwich) with its relevant ingredients
           var recipe_Ingredients = new List<Recipe_Ingredient>
            {
                
                new Recipe_Ingredient{  RecipeID= 1, IngredientID = 1},
                new Recipe_Ingredient{ RecipeID=1, IngredientID= 2},
                new Recipe_Ingredient{ RecipeID=1, IngredientID= 3},
                new Recipe_Ingredient{  RecipeID= 2, IngredientID = 1},
                new Recipe_Ingredient{ RecipeID=2, IngredientID= 2}
               

            };

           recipe_Ingredients.ForEach(s => context.Recipe_Ingredient.Add(s));
           context.SaveChanges();
        }
    }
}