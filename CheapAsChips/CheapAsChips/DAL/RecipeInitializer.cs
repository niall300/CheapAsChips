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
            //create two recipes 
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

           
           // recipes.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();

            //add some ingredients
            var ingredients = new List<Ingredient>
            {
            new Ingredient{   Measure = "piece", Name = "Sliced Bread", Quantity = 2 },
            new Ingredient{   Measure = "grams", Name = "Cheddar Cheese", Quantity = 200 },
            new Ingredient{   Measure = "grams", Name = "Butter", Quantity = 30 }

           
            };

            recipes.ForEach(s => context.Ingredients(s));
            context.SaveChanges();



            //var enrollments = new List<Enrollment>
            //{
            //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //new Enrollment{StudentID=3,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=1050,},
            //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //new Enrollment{StudentID=6,CourseID=1045},
            //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //};
            //enrollments.ForEach(s => context.Enrollments.Add(s));
            //context.SaveChanges();
        }
    }
}