namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTabelGSMColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "GSM", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "GSM");
        }
    }
}
