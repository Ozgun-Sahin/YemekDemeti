namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoranaOzguYemekDenemeTableAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "RestoranaOzguIsim", c => c.Int());
            AddColumn("dbo.Foods", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "Discriminator");
            DropColumn("dbo.Foods", "RestoranaOzguIsim");
        }
    }
}
