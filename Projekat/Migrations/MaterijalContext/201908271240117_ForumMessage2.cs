namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForumMessage2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Forum_Message", "odobrenje", c => c.String());
            AddColumn("dbo.MaterijalModels", "datumMaterijali", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaterijalModels", "datumMaterijali");
            DropColumn("dbo.Forum_Message", "odobrenje");
        }
    }
}
