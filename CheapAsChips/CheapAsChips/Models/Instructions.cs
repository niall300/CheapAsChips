﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheapAsChips.Models
{
    public class Instructions
    {
        public int RecipeId { get; set; }
        public string[] Steps { get; set; }
    }
}