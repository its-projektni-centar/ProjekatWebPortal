namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forum3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Forum_Posts", "imgTema", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Forum_Posts", "imgTema");
        }
    }
}
