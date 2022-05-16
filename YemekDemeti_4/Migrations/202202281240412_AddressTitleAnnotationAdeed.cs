namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressTitleAnnotationAdeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "AdressTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "AdressTitle", c => c.String());
        }
    }
}
