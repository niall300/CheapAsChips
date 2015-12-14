using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheapAsChips.Models
{
    public class Instructions
    {
        [Key]
        public int InstructionId { get; set; }
        public int RecipeId { get; set; }
                public string[] Steps { get; set; }
    }
}