namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoranaOzguYemekDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Foods", "RestoranaOzguIsim");
            DropColumn("dbo.Foods", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Foods", "RestoranaOzguIsim", c => c.Int());
        }
    }
}
