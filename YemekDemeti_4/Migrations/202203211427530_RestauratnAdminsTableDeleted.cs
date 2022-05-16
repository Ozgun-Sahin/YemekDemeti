namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestauratnAdminsTableDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestaurantAdmins", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.RestaurantAdmins", new[] { "RestaurantID" });
            DropTable("dbo.RestaurantAdmins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RestaurantAdmins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.RestaurantAdmins", "RestaurantID");
            AddForeignKey("dbo.RestaurantAdmins", "RestaurantID", "dbo.Restaurants", "ID", cascadeDelete: true);
        }
    }
}
