namespace CrawlerDataProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Thumbnail", c => c.String());
            AddColumn("dbo.Articles", "Url", c => c.String());
            AddColumn("dbo.Articles", "Description", c => c.String());
            AddColumn("dbo.Articles", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Sources", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Sources", "LinksSelector");
            DropColumn("dbo.Sources", "CreatedAt");
            DropColumn("dbo.Sources", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sources", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sources", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sources", "LinksSelector", c => c.String());
            DropColumn("dbo.Sources", "Type");
            DropColumn("dbo.Articles", "Status");
            DropColumn("dbo.Articles", "Description");
            DropColumn("dbo.Articles", "Url");
            DropColumn("dbo.Accounts", "Thumbnail");
        }
    }
}
