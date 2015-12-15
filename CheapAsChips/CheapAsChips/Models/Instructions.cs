using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheapAsChips.Models
{
    public class Instructions
    {
        [Primary Key]
        public int InstructionID { get; set; }
        public int RecipeID { get; set; }
        public string myInstruction { get; set; }
    }
}