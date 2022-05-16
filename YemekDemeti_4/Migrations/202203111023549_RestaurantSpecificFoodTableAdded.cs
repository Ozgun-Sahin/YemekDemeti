namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantSpecificFoodTableAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "RestaurantSpecificName", c => c.String());
            AddColumn("dbo.Foods", "RestaurantSpecificUnicPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Foods", "RestaurantSpecificImage", c => c.String());
            AddColumn("dbo.Foods", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "Discriminator");
            DropColumn("dbo.Foods", "RestaurantSpecificImage");
            DropColumn("dbo.Foods", "RestaurantSpecificUnicPrice");
            DropColumn("dbo.Foods", "RestaurantSpecificName");
        }
    }
}
