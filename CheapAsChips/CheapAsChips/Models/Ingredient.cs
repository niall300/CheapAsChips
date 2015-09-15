using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheapAsChips.Models
{
    public class Ingredient
    {



        // this attribute lets you enter the primary key for the course rather than having the database generate it?
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientID { get; set; }
        public String Name { get; set; }
        public String Measure { get; set; }
        public Double Quantity { get; set; }

        //Navigation Properties
        public virtual ICollection<Recipe_Ingredient> RecipeIngredient { get; set; }

        


    }
}