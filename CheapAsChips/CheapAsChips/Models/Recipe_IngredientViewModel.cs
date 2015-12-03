using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheapAsChips.Models
{
    public class Recipe_IngredientViewModel

    {
        [Key]
        public int  Recipe_IngredientViewModelID{get; set; }

        public Ingredient  Recipe_Ingredient { get; set; }
        public IList<Ingredient>  Recipe_IngredientsList { get; set; }

        public Recipe_IngredientViewModel()
        {
            this.Recipe_IngredientsList = new List<Ingredient>();
        }

       
    }
}


    
