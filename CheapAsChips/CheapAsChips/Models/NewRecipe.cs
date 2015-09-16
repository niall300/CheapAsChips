using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace CheapAsChips.Models
{
    public class NewRecipe
    {

        public int NewRecipeID { get; set; }
        public DateTime dateAdded { get; set; }
        public string Title { get; set; }
        public string MainIngredient { get; set; }
        public string description { get; set; }
        public int NumberOfServings { get; set; }

        //public Images Pictures { get; set; }
        //public NutritionInformation NutriInfo { get; set; }
        public string Notes { get; set; }
        public string Tip { get; set; }
        public Boolean Blender { get; set; }

        //The '?' allows our enum to be null
        public Method? Method { get; set; }
        public MealType MealType { get; set; }
        public FoodType FoodType { get; set; }
        public Boolean Spicy { get; set; }
        //public CookingTime Time { get; set; }

       // public List<String> MyStrings { get; set; }


        public List <Ingredient> Ingredients { get; set; }
       
       
        

        

        
    }
}