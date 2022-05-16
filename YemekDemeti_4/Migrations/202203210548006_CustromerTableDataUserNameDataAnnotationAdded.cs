namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustromerTableDataUserNameDataAnnotationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "UserName", c => c.String());
        }
    }
}
