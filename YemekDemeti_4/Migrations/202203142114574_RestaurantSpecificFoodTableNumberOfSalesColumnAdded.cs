namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantSpecificFoodTableNumberOfSalesColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "NumberOfSales", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "NumberOfSales");
        }
    }
}
