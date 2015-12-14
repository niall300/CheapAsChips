namespace CheapAsChips.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        imagedata = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        Name = c.String(),
                        Measure = c.String(),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientID)
                .ForeignKey("dbo.Recipe", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.Instructions",
                c => new
                    {
                        InstructionId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InstructionId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        dateAdded = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 30),
                        MainIngredient = c.String(nullable: false, maxLength: 30),
                        description = c.String(nullable: false, maxLength: 50),
                        NumberOfServings = c.Int(),
                        Notes = c.String(maxLength: 50),
                        Tip = c.String(maxLength: 50),
                        Blender = c.Boolean(nullable: false),
                        Method = c.Int(),
                        MealType = c.Int(nullable: false),
                        FoodType = c.Int(nullable: false),
                        Spicy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredient", "RecipeID", "dbo.Recipe");
            DropIndex("dbo.Ingredient", new[] { "RecipeID" });
            DropTable("dbo.Recipe");
            DropTable("dbo.Instructions");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Image");
        }
    }
}
