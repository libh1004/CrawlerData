namespace CrawlerDataProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "Source_Id1", "dbo.Sources");
            DropIndex("dbo.Links", new[] { "Source_Id1" });
            DropColumn("dbo.Links", "Source_Id");
            RenameColumn(table: "dbo.Links", name: "Source_Id1", newName: "Source_Id");
            AlterColumn("dbo.Links", "Source_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Links", "Source_Id");
            AddForeignKey("dbo.Links", "Source_Id", "dbo.Sources", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "Source_Id", "dbo.Sources");
            DropIndex("dbo.Links", new[] { "Source_Id" });
            AlterColumn("dbo.Links", "Source_Id", c => c.Int());
            RenameColumn(table: "dbo.Links", name: "Source_Id", newName: "Source_Id1");
            AddColumn("dbo.Links", "Source_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Links", "Source_Id1");
            AddForeignKey("dbo.Links", "Source_Id1", "dbo.Sources", "Id");
        }
    }
}
