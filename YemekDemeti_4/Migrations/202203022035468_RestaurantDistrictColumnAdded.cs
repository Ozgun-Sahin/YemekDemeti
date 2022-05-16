namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantDistrictColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "DistrictID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "DistrictID");
        }
    }
}
