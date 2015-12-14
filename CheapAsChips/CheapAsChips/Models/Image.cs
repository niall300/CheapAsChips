using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheapAsChips.Models
{
    public class Image
    {
        
        [Key]
        public int ImageID { get; set; }
        public int RecipeID { get; set; }

        //this tells the view how to display the data
        [DataType(DataType.Date)]
        [Display(Name = "Uploaded on: ")]
        public DateTime dateAdded { get;}

        
        //[Display(Name = "Recipe Title: ")]
        //[StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        //public string Title { get; set; }

        public Byte[] imagedata { get; set; }
    }
}