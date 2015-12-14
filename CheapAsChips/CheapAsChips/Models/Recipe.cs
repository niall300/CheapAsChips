using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;


namespace CheapAsChips.Models
{
    public enum Method { Boil, Fry, Bake, Microwave }
    public enum FoodType { Vegetarian, Meat, Vegan, Pescatarian }
    public enum MealType { Snack, Main, Dessert, Side }

    public class Recipe
    {


        [Key]
        public int RecipeID { get; set; }

       


        //this tells the view how to display the data
        [DataType(DataType.Date)]
         [Display(Name = "Uploaded on: ")]
        public DateTime dateAdded { get; set; }

        [Required]
        [Display(Name = "Recipe Title: ")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

         [Required]
         [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Main Ingredient: ")]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string MainIngredient { get; set; }

        [Required]
         [StringLength(50, ErrorMessage = "The {0} can only be {1} characters long.")]
        [Display(Name = "Description: ")]
        public string description { get; set; }
       

        [Display(Name="Serves: ")]
        [RegularExpression(@"\d{1,20}", ErrorMessage = "Number must be between {0} and {1}")]
        public int? NumberOfServings { get; set; }
       
        //public Images Pictures { get; set; }
        //public NutritionInformation NutriInfo { get; set; }

         [StringLength(50, ErrorMessage = "The {0} can only be {1} characters long.")]
        [Display(Name = "Notes: ")]
        public string Notes { get; set; }

         [StringLength(50, ErrorMessage = "The {0} can only be {1} characters long.")]
        [Display(Name = "Tip: ")]
        public string Tip { get; set; }

        [Required]
        [Display(Name = "Do I need a Blender ")]
        public Boolean Blender { get; set; }
        
        //The '?' allows our enum to be null
        [Display(Name = "Cooking Method: ")]
        public Method? Method { get; set; }

         [Required]
         [Display(Name = "Meal Type: ")]
        public MealType MealType { get; set; }

         [Required]
        [Display(Name = "Food Type: ")]
        public FoodType FoodType { get; set; }

         [Required]
        [Display(Name = "Is It Spicy: ")]
        public Boolean Spicy { get; set; }
        //public CookingTime Time { get; set; }

        //Navigation Properties
        public virtual ICollection<Ingredient> ingreds { get; set; }
        // [Display(Name = "Ingredients: ")]
        //public virtual ICollection<Recipe_Ingredient> Recipe_Ingredients { get; set; }

         public Recipe()
        {
            dateAdded = DateTime.UtcNow;
            ingreds = new Collection<Ingredient>();
        }

    }
}