namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTableConfirmedColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Confirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Confirmed");
        }
    }
}
