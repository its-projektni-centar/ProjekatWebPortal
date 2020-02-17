namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForumMessage3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SmerModels", "nazivFajlIts", c => c.String());
            AddColumn("dbo.SmerModels", "nazivFajlNs", c => c.String());
            AddColumn("dbo.SmerModels", "nazivFajlMs", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SmerModels", "nazivFajlMs");
            DropColumn("dbo.SmerModels", "nazivFajlNs");
            DropColumn("dbo.SmerModels", "nazivFajlIts");
        }
    }
}
