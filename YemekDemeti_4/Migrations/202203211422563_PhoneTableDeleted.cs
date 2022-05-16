namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneTableDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Phones", new[] { "CustomerID" });
            DropTable("dbo.Phones");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Phones", "CustomerID");
            AddForeignKey("dbo.Phones", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
        }
    }
}
