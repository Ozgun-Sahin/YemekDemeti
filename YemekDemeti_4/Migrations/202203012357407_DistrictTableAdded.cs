namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistrictTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Districts", "CityID", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "CityID" });
            DropTable("dbo.Districts");
        }
    }
}
