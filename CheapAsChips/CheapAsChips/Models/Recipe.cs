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
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string MainIngredient { get; set; }
        public string description { get; set; }
        public int NumberOfServings { get; set; }
        public Ingredient IngredientList { get; set; }
        public Instructions InstructionList { get; set; }
        //public Images Pictures { get; set; }
        //public NutritionInformation NutriInfo { get; set; }
        public string Notes { get; set; }
        public string Tip { get; set; }
        public Boolean Blender { get; set; }
        public Method Method { get; set; }
        public MealType MealType { get; set; }
        public FoodType FoodType { get; set; }
        public Boolean Spicy { get; set; }
        //public CookingTime Time { get; set; }
    }
}