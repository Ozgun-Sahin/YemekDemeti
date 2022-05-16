namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodRestaurantJointTableDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodRestaurantJoints", "FoodID", "dbo.Foods");
            DropForeignKey("dbo.FoodRestaurantJoints", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.FoodRestaurantJoints", new[] { "FoodID" });
            DropIndex("dbo.FoodRestaurantJoints", new[] { "RestaurantID" });
            DropTable("dbo.FoodRestaurantJoints");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FoodRestaurantJoints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.FoodRestaurantJoints", "RestaurantID");
            CreateIndex("dbo.FoodRestaurantJoints", "FoodID");
            AddForeignKey("dbo.FoodRestaurantJoints", "RestaurantID", "dbo.Restaurants", "ID", cascadeDelete: true);
            AddForeignKey("dbo.FoodRestaurantJoints", "FoodID", "dbo.Foods", "ID", cascadeDelete: true);
        }
    }
}
