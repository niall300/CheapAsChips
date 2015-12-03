using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheapAsChips.Models
{
    public class IngredientViewModel
    {
        public int IngredientViewModelID{get; set; }

        public Ingredient Ingredient { get; set; }
        public IList<Ingredient> IngredientsList { get; set; }

       
    }
}