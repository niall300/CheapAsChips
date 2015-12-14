using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace CheapAsChips.Models
{
    public class Ingredient 
    {



        // this attribute lets you enter the primary key for the course rather than having the database generate it?
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public String Name { get; set; }
        public String Measure { get; set; }
        public Double Quantity { get; set; }

        //Navigation Properties
        

       
        public override string ToString()
        {
            return Quantity + " " + Measure + " " + "  " + Name;
        }



       

      
    }
}