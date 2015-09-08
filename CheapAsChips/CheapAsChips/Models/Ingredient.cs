using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheapAsChips1.Models
{
    public class Ingredient
    {
        public int recipeId { get; set; }
        public String Name { get; set; }
        public String Measure { get; set; }
        public Double Quantity { get; set; }


    }
}