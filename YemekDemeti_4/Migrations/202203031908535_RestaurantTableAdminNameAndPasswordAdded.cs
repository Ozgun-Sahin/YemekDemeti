namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantTableAdminNameAndPasswordAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "AdminName", c => c.String());
            AddColumn("dbo.Restaurants", "Password", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Password");
            DropColumn("dbo.Restaurants", "AdminName");
        }
    }
}
