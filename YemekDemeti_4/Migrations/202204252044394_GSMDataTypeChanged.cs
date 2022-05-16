namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GSMDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "GSM", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "GSM", c => c.Int(nullable: false));
        }
    }
}
