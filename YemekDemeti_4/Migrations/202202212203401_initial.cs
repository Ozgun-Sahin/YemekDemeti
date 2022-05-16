namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Image = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        _Comment = c.String(),
                        Confirm = c.Boolean(nullable: false),
                        Submitted = c.Boolean(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        RestaurantName = c.String(),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FoodRestaurantJoints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Foods", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.FoodID)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UnicPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        image = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        FoodID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.FoodID })
                .ForeignKey("dbo.Foods", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.FoodID);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.RestaurantAdmins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantAdmins", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Phones", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "FoodID", "dbo.Foods");
            DropForeignKey("dbo.FoodRestaurantJoints", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.FoodRestaurantJoints", "FoodID", "dbo.Foods");
            DropForeignKey("dbo.Foods", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Comments", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Comments", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Addresses", "CustomerID", "dbo.Customers");
            DropIndex("dbo.RestaurantAdmins", new[] { "RestaurantID" });
            DropIndex("dbo.Phones", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "FoodID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Foods", new[] { "CategoryID" });
            DropIndex("dbo.FoodRestaurantJoints", new[] { "RestaurantID" });
            DropIndex("dbo.FoodRestaurantJoints", new[] { "FoodID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Comments", new[] { "OrderID" });
            DropIndex("dbo.Comments", new[] { "RestaurantID" });
            DropIndex("dbo.Addresses", new[] { "CustomerID" });
            DropTable("dbo.RestaurantAdmins");
            DropTable("dbo.Phones");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodRestaurantJoints");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Orders");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
