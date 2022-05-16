namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Comments", "_Comment", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Restaurants", "AdminName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Foods", "RestaurantSpecificName", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "RestaurantSpecificName", c => c.String());
            AlterColumn("dbo.Restaurants", "AdminName", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
            AlterColumn("dbo.Comments", "_Comment", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Name", c => c.String());
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String());
        }
    }
}
