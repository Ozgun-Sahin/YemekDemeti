namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTableScoreColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Score", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Score");
        }
    }
}
