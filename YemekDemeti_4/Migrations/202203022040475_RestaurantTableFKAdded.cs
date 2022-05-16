namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantTableFKAdded : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Restaurants", "DistrictID");
            AddForeignKey("dbo.Restaurants", "DistrictID", "dbo.Districts", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "DistrictID", "dbo.Districts");
            DropIndex("dbo.Restaurants", new[] { "DistrictID" });
        }
    }
}
