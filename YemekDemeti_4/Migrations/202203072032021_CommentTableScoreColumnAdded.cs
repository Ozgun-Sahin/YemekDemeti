namespace YemekDemeti_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentTableScoreColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Score", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Score");
        }
    }
}
