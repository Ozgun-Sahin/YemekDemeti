namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GSMDataAnnotationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "GSM", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "GSM", c => c.String());
        }
    }
}
