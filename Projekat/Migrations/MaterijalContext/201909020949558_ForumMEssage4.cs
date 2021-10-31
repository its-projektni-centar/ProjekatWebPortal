namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForumMEssage4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SmerModels", "fajlIts", c => c.Binary());
            AddColumn("dbo.SmerModels", "fileMimeTypeIts", c => c.String());
            AddColumn("dbo.SmerModels", "fileEkstenzijaIts", c => c.String());
            AddColumn("dbo.SmerModels", "fajlNs", c => c.Binary());
            AddColumn("dbo.SmerModels", "fileMimeTypeNs", c => c.String());
            AddColumn("dbo.SmerModels", "fileEkstenzijaNs", c => c.String());
            AddColumn("dbo.SmerModels", "fajlMs", c => c.Binary());
            AddColumn("dbo.SmerModels", "fileMimeTypeMs", c => c.String());
            AddColumn("dbo.SmerModels", "fileEkstenzijaMs", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SmerModels", "fileEkstenzijaMs");
            DropColumn("dbo.SmerModels", "fileMimeTypeMs");
            DropColumn("dbo.SmerModels", "fajlMs");
            DropColumn("dbo.SmerModels", "fileEkstenzijaNs");
            DropColumn("dbo.SmerModels", "fileMimeTypeNs");
            DropColumn("dbo.SmerModels", "fajlNs");
            DropColumn("dbo.SmerModels", "fileEkstenzijaIts");
            DropColumn("dbo.SmerModels", "fileMimeTypeIts");
            DropColumn("dbo.SmerModels", "fajlIts");
        }
    }
}
