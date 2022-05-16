namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodsTableNameUnitPriceImagesColumsDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Foods", "Name");
            DropColumn("dbo.Foods", "UnicPrice");
            DropColumn("dbo.Foods", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "image", c => c.String());
            AddColumn("dbo.Foods", "UnicPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Foods", "Name", c => c.String());
        }
    }
}
