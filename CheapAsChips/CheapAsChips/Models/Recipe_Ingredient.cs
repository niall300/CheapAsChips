using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheapAsChips.Models
{
    //this class allows us to maintain
    //a many to many relationship between recipe and ingredient
    //this is an association class or table
    public class Recipe_Ingredient
    {

        public int Recipe_IngredientID { get; set; }
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
       
        //navigation proerties
        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}