namespace CrawlerDataProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "Source_Id", "dbo.Sources");
            DropIndex("dbo.Links", new[] { "Source_Id" });
            AddColumn("dbo.Links", "Source_Id1", c => c.Int());
            AlterColumn("dbo.Links", "Source_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Links", "Source_Id1");
            AddForeignKey("dbo.Links", "Source_Id1", "dbo.Sources", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "Source_Id1", "dbo.Sources");
            DropIndex("dbo.Links", new[] { "Source_Id1" });
            AlterColumn("dbo.Links", "Source_Id", c => c.Int());
            DropColumn("dbo.Links", "Source_Id1");
            CreateIndex("dbo.Links", "Source_Id");
            AddForeignKey("dbo.Links", "Source_Id", "dbo.Sources", "Id");
        }
    }
}
