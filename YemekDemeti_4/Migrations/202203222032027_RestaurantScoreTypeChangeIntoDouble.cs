namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantScoreTypeChangeIntoDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Restaurants", "Score", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Score", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
