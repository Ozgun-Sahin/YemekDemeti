namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodsTableRestaurantIDAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "RestaurantID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "RestaurantID");
        }
    }
}
