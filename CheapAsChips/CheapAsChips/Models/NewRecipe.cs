using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace CheapAsChips.Models
{
    public class NewRecipe : IEnumerable<Ingredient>
    {
        

        public int NewRecipeID { get; set; }


        public DateTime dateAdded { get; set; }

        [Required]
        [StringLength(15, MinimumLength=3)]
        public string Title { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string MainIngredient { get; set; }

        [Required(ErrorMessage="You really need to add a description. ")]
       
        [StringLength(40, MinimumLength = 3)]
        public string description { get; set; }

        [Required]
        [Range(1,12)]
        public int NumberOfServings { get; set; }

        //public Images Pictures { get; set; }
        //public NutritionInformation NutriInfo { get; set; }
        [Required]
        public string Notes { get; set; }

        [Required]
        public string Tip { get; set; }

        [Required]
        public Boolean Blender { get; set; }

        //The '?' allows our enum to be null
        public Method? Method { get; set; }

        [Required]
        public MealType MealType { get; set; }

        [Required]
        public FoodType FoodType { get; set; }

        [Required]
        public Boolean Spicy { get; set; }
        //public CookingTime Time { get; set; }

       // public List<String> MyStrings { get; set; }
        //Ingredients = new List <Ingredient>(15);

        public virtual Ingredient Ingredients { get; set; }
        //constructor
        public NewRecipe()
        {
            this.Ingredients = new Ingredient();
        }








        public IEnumerator GetEnumerator()
        {

            foreach(Ingredient i in Ingredients)
            {
                yield return i;
            }
           
        }

        IEnumerator<Ingredient> IEnumerable<Ingredient>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}