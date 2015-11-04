using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CheapAsChips.Models
{
    public enum Method { Boil, Fry, Bake, Microwave }
    public enum FoodType { Vegetarian, Meat, Vegan }
    public enum MealType { Snack, Main, Dessert, Side }

    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }

        //this tells the view how to display the data
         [DataType(DataType.Date)]
         [Display(Name = "Uploaded on: ")]
        public DateTime dateAdded { get; set; }

        [Display(Name = "Recipe Title: ")]
        public string Title { get; set; }

        [Display(Name = "Main Ingredient: ")]
        public string MainIngredient { get; set; }

       [Display(Name = "Description: ")]
        public string description { get; set; }
       
        [Display(Name="Serves: ")]
        public int NumberOfServings { get; set; }
       
        //public Images Pictures { get; set; }
        //public NutritionInformation NutriInfo { get; set; }
        [Display(Name = "Notes: ")]
        public string Notes { get; set; }

        [Display(Name = "Tip: ")]
        public string Tip { get; set; }

        [Display(Name = "Do I need a Blender ")]
        public Boolean Blender { get; set; }
        
        //The '?' allows our enum to be null
        [Display(Name = "Cooking Method: ")]
        public Method? Method { get; set; }

         [Display(Name = "Meal Type: ")]
        public MealType MealType { get; set; }

        [Display(Name = "Food Type: ")]
        public FoodType FoodType { get; set; }

        [Display(Name = "Is It Spicy: ")]
        public Boolean Spicy { get; set; }
        //public CookingTime Time { get; set; }

        //Navigation Properties
         [Display(Name = "Ingredients: ")]
        public virtual ICollection<Recipe_Ingredient> Recipe_Ingredients { get; set; }



    }
}