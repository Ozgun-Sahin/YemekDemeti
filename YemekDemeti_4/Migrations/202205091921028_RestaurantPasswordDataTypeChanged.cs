namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantPasswordDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Password", c => c.Int(nullable: false));
        }
    }
}
