namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantTableRoleColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Role");
        }
    }
}
