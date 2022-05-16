namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersAddressIDColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "AddressID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "AddressID");
        }
    }
}
