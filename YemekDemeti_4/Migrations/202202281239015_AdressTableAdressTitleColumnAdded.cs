namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdressTableAdressTitleColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "AdressTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "AdressTitle");
        }
    }
}
