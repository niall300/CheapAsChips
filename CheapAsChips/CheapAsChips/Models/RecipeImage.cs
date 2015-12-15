using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Drawing;


namespace CheapAsChips.Models
{
    public class RecipeImage
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
        //convert byte array to image
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        //convert byte array to image
        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);

            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms, false);

            
            return returnImage;
        }
    }
}