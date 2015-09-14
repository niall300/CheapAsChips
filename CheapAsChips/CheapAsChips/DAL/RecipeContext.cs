using CheapAsChips.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CheapAsChips.DAL
{
    public class RecipeContext: DbContext
    {
        //we pass the name of the connection string to the base constructor
        public RecipeContext(): base("recipeContext")
        {
        }

            public DbSet<Recipe> Students { get; set; }
            public DbSet<Recipe_Ingredient> recipe_Ingredient { get; set; }
            public DbSet<Ingredient> Ingredients { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //this line of code prevents the database pluralising table names
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
 }
