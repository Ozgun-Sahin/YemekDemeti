namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressTableDistrictColumnAddedCityColumnChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "CityID", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "DistrictID", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String());
            CreateIndex("dbo.Addresses", "CityID");
            CreateIndex("dbo.Addresses", "DistrictID");
            AddForeignKey("dbo.Addresses", "CityID", "dbo.Cities", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Addresses", "DistrictID", "dbo.Districts", "ID", cascadeDelete: false);
            DropColumn("dbo.Addresses", "City");
            DropColumn("dbo.Addresses", "AddressLine2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "AddressLine2", c => c.String());
            AddColumn("dbo.Addresses", "City", c => c.String(nullable: false));
            DropForeignKey("dbo.Addresses", "DistrictID", "dbo.Districts");
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "DistrictID" });
            DropIndex("dbo.Addresses", new[] { "CityID" });
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String(nullable: false));
            DropColumn("dbo.Addresses", "DistrictID");
            DropColumn("dbo.Addresses", "CityID");
        }
    }
}
